using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

using _2DLevelCreator;
using _2d_Objects;
using CustomControls;


namespace Things
{
    public class Thing2D_Rb<T> where T : RigidBody
    {
        public static Vector3 GetCenter(List<Thing2D_Rb<RigidBody>> list)
        {
            if (list.Count > 0)
            {
                Vector3 center = Vector3.Zero;
                for (int iCount = list.Count -1; iCount >= 0; --iCount)
                {
                    center += list[iCount].Position;
                }
                return center /= list.Count;
            }
            else return Vector3.Zero;
        }

        
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
        public List<Thing2D_Rb<T>> list;
        
        
        public UniqueIdentifier ID { get; set; }
        public UniqueIdentifier_Reference Thing2D_ID { get; set; } 





        public Transform Transform  { get { return this.rigidBody.transform; } set { this.rigidBody.transform = value; } }   //(WARNING) Set as reference?

        public Vector3 Position     { get { return this.rigidBody.transform.vPosition; } set { this.rigidBody.transform.vPosition = value; } }
        public float PositionX      { get { return this.rigidBody.transform.vPosition.X; } set { this.rigidBody.transform.vPosition.X = value; } }
        public float PositionY      { get { return this.rigidBody.transform.vPosition.Y; } set { this.rigidBody.transform.vPosition.Y = value; } }
        public float PositionZ      { get { return this.rigidBody.transform.vPosition.Z; } set { this.rigidBody.transform.vPosition.Z = value; } }

        public float Rotation       { get { return this.rigidBody.transform.zRotation; } set { this.rigidBody.transform.zRotation = value; this.rigidBody.Update(); } }
        public Matrix RotMatrix     { get { return this.rigidBody.rotMatrix; } set { this.rigidBody.rotMatrix = value; } }

        public Vector3 Scale { get { return this.rigidBody.transform.vScale; } set { this.rigidBody.transform.vScale = value; this.rigidBody.CreateMotionPathAABB(); this.rigidBody.Rebuild(); } }
        public float ScaleX { get { return this.rigidBody.transform.vScale.X; } set { this.rigidBody.RescaleTo(new Vector3(value, this.rigidBody.transform.vScale.Y, this.rigidBody.transform.vScale.Z)); } }
        public float ScaleY { get { return this.rigidBody.transform.vScale.Y; } set { this.rigidBody.RescaleTo(new Vector3(this.rigidBody.transform.vScale.X, value, this.rigidBody.transform.vScale.Z)); } }
        public float ScaleZ { get { return this.rigidBody.transform.vScale.Z; } set { this.rigidBody.RescaleTo(new Vector3(this.rigidBody.transform.vScale.X, this.rigidBody.transform.vScale.Y, value)); } }


        public Motion Motion        { get { return this.rigidBody.motion; } set { this.rigidBody.motion = value; } }        //(WARNING) Set as reference?

        public Vector3 Velocity     { get { return this.rigidBody.motion.vVelocityPS; } set { this.rigidBody.motion.vVelocityPS = value; } }
        public float VelocityX      { get { return this.rigidBody.motion.vVelocityPS.X; } set { this.rigidBody.motion.vVelocityPS.X = value; } }
        public float VelocityY      { get { return this.rigidBody.motion.vVelocityPS.Y; } set { this.rigidBody.motion.vVelocityPS.Y = value; } }
        public float VelocityZ      { get { return this.rigidBody.motion.vVelocityPS.Z; } set { this.rigidBody.motion.vVelocityPS.Z = value; } }

        public float RotationVelocity { get { return this.rigidBody.motion.zRotPS; } set { this.rigidBody.motion.zRotPS = value; } }

        public Vector3 Centroid { get { return this.rigidBody.Centroid; } set { this.rigidBody.Centroid = value; } }

        public T rigidBody { get; set; }        //Holds the Rigidbody Type








        //Constructor
        public Thing2D_Rb(UniqueIdentifier_Reference Thing2D_ID, T t, string uniqueID, List<Thing2D_Rb<T>> list)
        {
            this.rigidBody = t;                                                 //(WARNING) Need to deepcopy?

            this.Thing2D_ID = Thing2D_ID;



            this.list = list;
            this.ID = new UniqueIdentifier(uniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Copy Constructor
        public Thing2D_Rb(Thing2D_Rb<T> thing2D_Rb, List<Thing2D_Rb<T>> list)
        {
            this.rigidBody = (T)thing2D_Rb.rigidBody.DeepCopy<RigidBody>();     //DeepCopy

            this.Thing2D_ID = new UniqueIdentifier_Reference(thing2D_Rb.Thing2D_ID);


            this.list = list;
            this.ID = new UniqueIdentifier(thing2D_Rb.ID.UniqueID, list.Count, this.GetMyIndex, this.FindID);
            list.Add(this);
        }

        //Load Constructor
        public Thing2D_Rb(string fileData, List<Thing2D_Rb<T>> list)
        {
            this.list = list;
            this.Load(fileData);
            list.Add(this);
        }


        

        

        public void RescaleTo(Vector3 scale)
        {
            this.rigidBody.RescaleTo(scale);
        }

        public void ScaleBy(Vector3 scale)
        {
            this.rigidBody.ScaleBy(scale);
        }

        public Thing2D GetThing2D()
        {
            return Thing2D.Thing2D_List[this.Thing2D_ID.Index];
        }




        #region Draw Functions
        public virtual void Draw(XnaWindow xnaWindow)
        {
            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Draw(xnaWindow, this.Transform, this.RotMatrix);
        }

        public virtual void Highlight(XnaWindow xnaWindow)
        {
            Thing2D.Thing2D_List[this.Thing2D_ID.Index].Highlight(xnaWindow, this.Transform, this.RotMatrix);
        }
        #endregion


        #region Load Functions

        public virtual void Load(string fileData)
        {
            this.ID = new UniqueIdentifier(StringMalarkey.ExtractString(fileData, "UNIQUEID"), list.Count, this.GetMyIndex, this.FindID);

            this.Thing2D_ID = new UniqueIdentifier_Reference(Thing2D.Thing2D_List[0].FindID(Convert.ToInt32(StringMalarkey.ExtractString(fileData, "THING2DINDEX"))));


            switch (Convert.ToInt32(StringMalarkey.ExtractString(fileData, "RbID")))
            {
                case 0:
                    this.rigidBody = (T)(new BoundingCircle(fileData)).DeepCopy<RigidBody>();
                    break;

                case 1:
                    this.rigidBody = (T)(new OBB(fileData)).DeepCopy<RigidBody>();
                    break;

                case 2:
                    this.rigidBody = (T)(new ConvexPolygon(fileData)).DeepCopy<RigidBody>();
                    break;
            }
            this.Position = StringMalarkey.GetVector3FromString(fileData, "Pos");
            this.rigidBody.AddRotation(MathHelper.ToRadians(float.Parse(StringMalarkey.ExtractString(fileData, "Rot"))));
            this.RescaleTo(StringMalarkey.GetVector3FromString(fileData, "Scale") + new Vector3(0,0,1));
            this.Velocity = StringMalarkey.GetVector3FromString(fileData, "Vel");
            this.RotationVelocity = MathHelper.ToRadians(float.Parse(StringMalarkey.ExtractString(fileData, "RotPS")));
            
            this.rigidBody.Rebuild();
        }

        #endregion

        #region Save Functions

        public virtual void Save(StreamWriter sw)
        {
            sw.Write(" #UNIQUEID# " + this.ID.UniqueID + " #/UNIQUEID# ");
            sw.Write(" #THING2DINDEX# " + this.Thing2D_ID.Index + " #/THING2DINDEX# ");

            sw.Write(" #Pos# " + this.PositionX + ", " + this.PositionY + ", " + this.PositionZ + " #/Pos# ");
            sw.Write(" #Vel# " + this.VelocityX + ", " + this.VelocityY + ", " + this.VelocityZ + " #/Vel# ");
            sw.Write(" #Rot# " + MathHelper.ToDegrees(this.Rotation) % 360 + " #/Rot# ");
            sw.Write(" #RotPS# " + MathHelper.ToDegrees(this.RotationVelocity) % 360 + " #/RotPS# ");
            sw.Write(" #Scale# " + this.ScaleX + ", " + this.ScaleY + ", " + this.ScaleZ + " #/Scale# ");

            this.rigidBody.Save(sw);
        }

        #endregion
    }
}
