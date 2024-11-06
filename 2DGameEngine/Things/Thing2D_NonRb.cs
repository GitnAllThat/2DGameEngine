using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

using _2DLevelCreator;
using _2d_Objects;
using CustomControls;

namespace Things
{
    public class Thing2D_NonRb
    {
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
        public List<Thing2D_NonRb> list;


        public UniqueIdentifier ID { get; set; }
        public UniqueIdentifier_Reference Thing2D_ID { get; set; } 


        virtual public Transform Transform { get; set; }                //Position, Rotation and Scale Information
        virtual public Matrix RotMatrix{ get; set; }                    //Holds the rotation Matrix.(It is computationally expensive to create and is sometimes used more than once)




        //Constructor
        public Thing2D_NonRb(UniqueIdentifier_Reference Thing2D_ID, Transform transform, string uniqueID, List<Thing2D_NonRb> list)
        {
            this.Thing2D_ID = Thing2D_ID;
            this.Transform = new Transform(transform);
            this.RotMatrix = Matrix.CreateRotationZ(0);



            this.list = list;
            this.ID = new UniqueIdentifier(uniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Copy Constructor
        public Thing2D_NonRb(Thing2D_NonRb thing2D_NonRb, List<Thing2D_NonRb> list)
        {
            this.Thing2D_ID = new UniqueIdentifier_Reference(thing2D_NonRb.Thing2D_ID);
            this.Transform = new Transform(Transform);
            this.RotMatrix = thing2D_NonRb.RotMatrix;


            this.list = list;
            this.ID = new UniqueIdentifier(thing2D_NonRb.ID.UniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Load Constructor
        public Thing2D_NonRb(string fileData, List<Thing2D_NonRb> list)
        {
            this.list = list;
            this.Load(fileData);
            list.Add(this);
            this.RotMatrix = Matrix.CreateRotationZ(0);
        }


        public void RescaleTo(Vector3 scale)
        {
            //this.rigidBody.RescaleTo(scale);
        }
        public void ScaleBy(Vector3 scale)
        {
            //this.rigidBody.ScaleBy(scale);
        }




        #region Draw Functions
        public virtual void Draw(XnaWindow xnaWindow)
        {
            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Draw(xnaWindow, this.Transform, this.RotMatrix);
        }

        public virtual void Draw(XnaWindow xnaWindow, Vector3 position)
        {
            Transform newTransform = new Transform(this.Transform);
            newTransform.vPosition += position;

            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Draw(xnaWindow, newTransform, this.RotMatrix);
        }

        public virtual void Highlight(XnaWindow xnaWindow)
        {
            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Highlight(xnaWindow, this.Transform, this.RotMatrix);
        }

        public virtual void Highlight(XnaWindow xnaWindow, Vector3 position)
        {
            Transform newTransform = new Transform(this.Transform);
            newTransform.vPosition += position;

            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Highlight(xnaWindow, newTransform, this.RotMatrix);
        }
        #endregion

        #region Load Functions

        public virtual void Load(string fileData)
        {
            this.ID = new UniqueIdentifier(StringMalarkey.ExtractString(fileData, "UNIQUEID"), list.Count, this.GetMyIndex, this.FindID);
            this.Thing2D_ID = new UniqueIdentifier_Reference(Thing2D.Thing2D_List[0].FindID(Convert.ToInt32(StringMalarkey.ExtractString(fileData, "THING2DINDEX"))));

            this.Transform = new Transform();
            this.Transform.vPosition = StringMalarkey.GetVector3FromString(fileData, "Pos");
            this.Transform.zRotation = MathHelper.ToRadians(float.Parse(StringMalarkey.ExtractString(fileData, "Rot")));
            this.Transform.vScale = StringMalarkey.GetVector3FromString(fileData, "Scale"); this.Transform.vScale.Z = 1;
        }

        #endregion

        #region Save Functions

        public virtual void Save(StreamWriter sw)
        {
            sw.Write(" #UNIQUEID# " + this.ID.UniqueID + " #/UNIQUEID# ");
            sw.Write(" #THING2DINDEX# " + this.Thing2D_ID.Index + " #/THING2DINDEX# ");
            sw.Write(" #Pos# " + this.Transform.vPosition.X + ", " + this.Transform.vPosition.Y + ", " + this.Transform.vPosition.Z + " #/Pos# ");
            sw.Write(" #Rot# " + MathHelper.ToDegrees(this.Transform.zRotation) % 360 + " #/Rot# ");
            sw.Write(" #Scale# " + this.Transform.vScale.X + ", " + this.Transform.vScale.Y + ", " + this.Transform.vScale.Z + " #/Scale# ");
        }

        #endregion
    }
}
