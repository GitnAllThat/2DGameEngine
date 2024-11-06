using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;
using CustomControls;
using SharpDX.X3DAudio;
using System.ComponentModel;
using System.Security.Cryptography;


namespace Things
{
    public class Thing2D
    {
        //Static Properties
            public  static List<Thing2D> Thing2D_List = new List<Thing2D>();     //Static List to hold any created Thing2D's

            public static void DeleteFromList(Thing2D thing2D)
            {
                int index = thing2D.ID.GetIndexFunction();
                thing2D.list.RemoveAt(index);

                for (int iCount = thing2D.list.Count - 1; iCount >= 0; --iCount)
                { thing2D.list[iCount].ID.UpdateIndex(); }
            }

        //Static Properties



        public int GetMyIndex()
        {
            for (int iCount = this.list.Count - 1; iCount >= 0; --iCount)
                if (this.list[iCount] == this) return iCount;
            return 0;               // returns the default thing2D if no match.
        }
        public UniqueIdentifier FindID(int index)
        {
            if (index >= 0 && index < this.list.Count) return this.list[index].ID;
            return this.ID;    // returns current index.
        }
        public List<Thing2D> list;





        public UniqueIdentifier ID { get; set; }
        public UniqueIdentifier_Reference MaterialID { get; set; } 





        public float Transparency { get; set; } //(CHANGE) This is temporary. Put transparenct in the material class
        public int primitiveCount;                                                  //Number of triangles.(Saves recalculating each Draw function)
        public VertexPositionTextureArray vertexPositionTextureArray { get; set; }  //Holds the vertices and texture coordinates.



        //Constructor
        public Thing2D(string uniqueID, UniqueIdentifier_Reference MaterialID, VertexPositionTextureArray vertexPositionTexture, List<Thing2D> list)
        {
            this.vertexPositionTextureArray = new VertexPositionTextureArray(vertexPositionTexture.VertexPositionTextureWrapper);

            this.MaterialID = MaterialID;



            this.primitiveCount = this.vertexPositionTextureArray.VertexPositionTextureWrapper.Length/3;
            this.Transparency = 0;


            this.list = list;
            this.ID = new UniqueIdentifier(uniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Copy Constructor
        public Thing2D(Thing2D thing2D, List<Thing2D> list)
        {
            this.vertexPositionTextureArray = new VertexPositionTextureArray(thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper);
            this.MaterialID = thing2D.MaterialID;

            this.primitiveCount = this.vertexPositionTextureArray.VertexPositionTextureWrapper.Length/3;
            this.Transparency = 0;


            this.list = list;
            this.ID = new UniqueIdentifier(thing2D.ID.UniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Load Constructor
        public Thing2D(string fileData, List<Thing2D> list)
        {
            this.list = list;
            this.Load(fileData);
            list.Add(this);
        }


        #region Load Functions

        public virtual void Load(string fileData)
        {
            this.ID = new UniqueIdentifier(StringMalarkey.ExtractString(fileData, "UNIQUEID"), list.Count, this.GetMyIndex, this.FindID);
            this.MaterialID = new UniqueIdentifier_Reference(Material.list_Material[0].FindID(Convert.ToInt32(StringMalarkey.ExtractString(fileData, "MATERIAL"))));
            this.vertexPositionTextureArray = StringMalarkey.GetVertPosTexArrayFromString(fileData);

            this.primitiveCount = this.vertexPositionTextureArray.VertexPositionTextureWrapper.Length / 3;
            this.Transparency = 0;
        }

        #endregion




        public void Draw(XnaWindow xnaWindow, Transform transform, Matrix rotMatrix)
        {
            Matrix worldMatrix = Matrix.CreateTranslation(transform.vPosition);

            xnaWindow.effect.CurrentTechnique = xnaWindow.effect.Techniques["Technique_Textured"];
            xnaWindow.effect.Parameters["WorldViewProjMatrix"].SetValue(worldMatrix * xnaWindow.camera.ViewProjMatrix);
            xnaWindow.effect.Parameters["RotationMatrix"].SetValue(rotMatrix);
            xnaWindow.effect.Parameters["xTexture"].SetValue(Material.list_Material[this.MaterialID.Index].Texture2D);        // Was "xTexture" in old xna project(Basically the code inside MyHlsl.fx)
            xnaWindow.effect.Parameters["Scale"].SetValue(transform.vScale);
            xnaWindow.effect.Parameters["Transparency"].SetValue(this.Transparency);

            foreach (EffectPass pass in xnaWindow.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                xnaWindow.Editor.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, this.vertexPositionTextureArray.GetVertexPositionTextureArray(), 0, this.primitiveCount);
            }
        }
        public void DrawScreenSpace(XnaWindow xnaWindow, Transform transform, Matrix rotMatrix)
        {
            Matrix worldMatrix = Matrix.CreateTranslation(transform.vPosition);

            xnaWindow.effect.CurrentTechnique = xnaWindow.effect.Techniques["Technique_Textured"];
            xnaWindow.effect.Parameters["WorldViewProjMatrix"].SetValue(worldMatrix);
            xnaWindow.effect.Parameters["RotationMatrix"].SetValue(Matrix.Identity);
            xnaWindow.effect.Parameters["xTexture"].SetValue(Material.list_Material[this.MaterialID.Index].Texture2D);          //Was "xTexture" in old xna project (Basically the code inside MyHlsl.fx)
            xnaWindow.effect.Parameters["Scale"].SetValue(transform.vScale * new Vector3(1, xnaWindow.Editor.GraphicsDevice.Viewport.AspectRatio, 1));
            xnaWindow.effect.Parameters["Transparency"].SetValue(this.Transparency);

            foreach (EffectPass pass in xnaWindow.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                xnaWindow.Editor.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, this.vertexPositionTextureArray.GetVertexPositionTextureArray(), 0, this.primitiveCount);
            }
        }



        public void Highlight(XnaWindow xnaWindow, Transform transform, Matrix rotMatrix)
        {
            Matrix worldMatrix = Matrix.CreateTranslation(transform.vPosition);

            xnaWindow.effect.CurrentTechnique = xnaWindow.effect.Techniques["Technique_Colored"];
            xnaWindow.effect.Parameters["WorldViewProjMatrix"].SetValue(worldMatrix * xnaWindow.camera.ViewProjMatrix);
            xnaWindow.effect.Parameters["RotationMatrix"].SetValue(Matrix.CreateRotationZ(transform.zRotation));
            xnaWindow.effect.Parameters["Scale"].SetValue(transform.vScale);

            VertexPositionColor[] vpc = new VertexPositionColor[this.vertexPositionTextureArray.Length];
            for (int i = 0; i < this.vertexPositionTextureArray.Length; i++)     //Set Up Vertices
            {
                vpc[i].Position = this.vertexPositionTextureArray.VertexPositionTextureWrapper[i].Position;
                vpc[i].Color = new Color(0, 0, 128, 50);
            }


            foreach (EffectPass pass in xnaWindow.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                xnaWindow.Editor.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vpc, 0, vpc.Length /3);
            }
        }



    }
}
