using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Global_Data;


namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class GameWindow : XnaWindow
    {
        public void GameDraw()
        {
            this.Editor.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(60,60,60));

            this.Editor.GraphicsDevice.BlendState = BlendState.NonPremultiplied;    // Allows alpha


            Globals.background.Draw(this);



            #region Background
            VertexPositionColor[] vertices = new VertexPositionColor[6];
            vertices[0].Position = new Vector3(-1, -1, 0f);
            vertices[0].Color = Color.Red;
            vertices[1].Position = new Vector3(-1, 1, 0f);
            vertices[1].Color = Color.Green;
            vertices[2].Position = new Vector3(1, 1, 0f);
            vertices[2].Color = Color.Yellow;
            vertices[3].Position = new Vector3(1, 1, 0f);
            vertices[3].Color = Color.Yellow;
            vertices[4].Position = new Vector3(1, -1, 0f);
            vertices[4].Color = Color.Yellow;
            vertices[5].Position = new Vector3(-1, -1, 0f);
            vertices[5].Color = Color.Red;

            this.effect.CurrentTechnique = this.effect.Techniques["Pretransformed"];

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.Editor.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 2, VertexPositionColor.VertexDeclaration);
            }
            this.Editor.spriteBatch.Begin();
            this.Editor.spriteBatch.End();
            #endregion











            //for (int i = 0; i < this.list_AllObjects.Count; ++i) { this.list_AllObjects[i].Draw(this.XnaWindow); }

            for (int i = 0; i < this.list_AllObjects.Count; ++i) 
            {
                if (this.list_AllObjects[i] == eli)
                {
                    eli.Draw(this);
                }
                else
                    this.list_AllObjects[i].rigidBody.Draw(this);
            }



            /*
            this.XnaWindow.spriteBatch.Begin();

            float height = 10;

            this.XnaWindow.spriteBatch.DrawString(this.XnaWindow.font, "Path: " + Globals.Path, new Vector2(20, height), Color.White);

            if (this.eli != null) this.XnaWindow.spriteBatch.DrawString(this.XnaWindow.font, "Eli Rotation: " + this.eli.Rotation, new Vector2(20, height += 20), Color.White);

            this.XnaWindow.spriteBatch.End();
            */


            
            /*
            //Dont want it to be a surface if the normal is the negative dot of (0,1,0)
            //Find Surface Using Lowest Contact Point
            if (list_CD_Eli.Count > 0)
            {
                int[] indexAndAorB = new int[2] { 0,0 };
                if (eli.rigidBody == list_CD_Eli[0].rigidBody_B) indexAndAorB[1] = 1;





                float lowestCP = list_CD_Eli[0].vContactPointA.Y;

                for (int i = 0; i < list_CD_Eli.Count; ++i)
                {
                    VectorHelper.DrawVertex(list_CD_Eli[i].rigidBody_A.transform.vPosition + list_CD_Eli[i].vContactPointA, this.XnaWindow, Color.Red);
                    VectorHelper.DrawVertex(list_CD_Eli[i].rigidBody_B.transform.vPosition + list_CD_Eli[i].vContactPointB, this.XnaWindow, Color.Red);
                    (new Line(list_CD_Eli[i].rigidBody_A.transform.vPosition + list_CD_Eli[i].vContactPointA, list_CD_Eli[i].rigidBody_A.transform.vPosition + list_CD_Eli[i].vContactPointA + list_CD_Eli[i].vPerpCToCpA, Color.Red, 1)).Draw(this.XnaWindow);
                    (new Line(list_CD_Eli[i].rigidBody_A.transform.vPosition + list_CD_Eli[i].vContactPointA, list_CD_Eli[i].rigidBody_A.transform.vPosition + list_CD_Eli[i].vContactPointA - list_CD_Eli[i].vPerpCToCpA, Color.Red, 1)).Draw(this.XnaWindow);

                    if (list_CD_Eli[i].vContactPointA.Y < lowestCP)
                    {
                        float dot = 0;
                        int index = 0;
                        if (eli.rigidBody == list_CD_Eli[i].rigidBody_A)
                        {
                            dot = Vector3.Dot(new Vector3(0, -1, 0), list_CD_Eli[i].vContactPointA);
                        }
                        else
                        {
                            dot = Vector3.Dot(new Vector3(0, -1, 0), list_CD_Eli[i].vContactPointB);
                            index = 1;
                        }


                        if (dot >= 0)
                        {
                            lowestCP = list_CD_Eli[i].rigidBody_A.transform.vPosition.Y + list_CD_Eli[i].vContactPointA.Y;
                            indexAndAorB[0] = i;
                            indexAndAorB[1] = index;
                        }
                    }
                }

                Color c = Color.Red;
                if (indexAndAorB[1] == 0)
                {
                    if (Vector3.Dot(new Vector3(0, -1, 0), list_CD_Eli[indexAndAorB[0]].vContactPointA) >= 0) c = Color.Green;
                    (new Line(list_CD_Eli[indexAndAorB[0]].rigidBody_A.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointA, list_CD_Eli[indexAndAorB[0]].rigidBody_A.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointA + list_CD_Eli[indexAndAorB[0]].vPerpCToCpA, c, 1)).Draw(this.XnaWindow);
                    (new Line(list_CD_Eli[indexAndAorB[0]].rigidBody_A.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointA, list_CD_Eli[indexAndAorB[0]].rigidBody_A.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointA - list_CD_Eli[indexAndAorB[0]].vPerpCToCpA, c, 1)).Draw(this.XnaWindow);
                }
                if (indexAndAorB[1] == 1)
                {
                    if (Vector3.Dot(new Vector3(0, -1, 0), list_CD_Eli[indexAndAorB[0]].vContactPointB) >= 0) c = Color.Green;
                    (new Line(list_CD_Eli[indexAndAorB[0]].rigidBody_B.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointB, list_CD_Eli[indexAndAorB[0]].rigidBody_B.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointB + list_CD_Eli[indexAndAorB[0]].vPerpCToCpB, c, 1)).Draw(this.XnaWindow);
                    (new Line(list_CD_Eli[indexAndAorB[0]].rigidBody_B.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointB, list_CD_Eli[indexAndAorB[0]].rigidBody_B.transform.vPosition + list_CD_Eli[indexAndAorB[0]].vContactPointB - list_CD_Eli[indexAndAorB[0]].vPerpCToCpB, c, 1)).Draw(this.XnaWindow);
                }

            }
            */
            list_CD_Eli.Clear();










            this.userInterface.Draw(this);



        }
    }
}
