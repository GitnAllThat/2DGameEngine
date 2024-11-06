
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Things;
using _2d_Objects;
using Global_Data;
using CustomControls;

namespace _2DLevelCreator
{
    public class Segment
    {
        public static int GlobalIndex = 0;

        #region Unique Identifier stuff

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

        #endregion

        public static void AttatchToSegmentEnd(Segment thisSeg, Segment segEnd)
        {
            thisSeg.Transform.vPosition = segEnd.Transform.vPosition + segEnd.segmentEnd.Transform.vPosition - thisSeg.segmentStart.Transform.vPosition;
        }
        public static void AttatchToSegmentStart(Segment thisSeg, Segment segStart)
        {
            thisSeg.Transform.vPosition = segStart.Transform.vPosition + segStart.segmentStart.Transform.vPosition - thisSeg.segmentEnd.Transform.vPosition;
        }






        public List<Segment> list;


        public UniqueIdentifier ID { get; set; }

        public Thing2D_NonRb segmentStart;
        public Thing2D_NonRb segmentEnd;
        public Transform Transform { get; set; }
        public int Difficulty { get; set; }
        public List<Thing2D_Rb<RigidBody>> list_Objects = new List<Thing2D_Rb<RigidBody>>();
        public AABB aabb { get; set; }


        #region Constructors

        //Constructor
        public Segment(string uniqueID, Transform transform, int difficulty, List<Segment> list)
        {
            this.Transform = transform;
            this.segmentStart = new Thing2D_NonRb("#UNIQUEID# seg_Start #/UNIQUEID# #THING2DINDEX# 12 #/THING2DINDEX# #Pos# 0, 0, 0 #/Pos# #Rot# 0 #/Rot# #Scale# 2, 2, 1 #/Scale#", new List<Thing2D_NonRb>());
            this.segmentEnd = new Thing2D_NonRb("#UNIQUEID# seg_End #/UNIQUEID# #THING2DINDEX# 13 #/THING2DINDEX# #Pos# 2, 0, 0 #/Pos# #Rot# 0 #/Rot# #Scale# 2, 2, 1 #/Scale#", new List<Thing2D_NonRb>());
            this.Difficulty = difficulty;
            this.aabb = new AABB(this.Transform.vPosition, 0, 0);
            this.BuildAABB();


            this.list = list;
            this.ID = new UniqueIdentifier(uniqueID, list.Count, this.GetMyIndex, this.FindID);
            this.list.Add(this);
        }

        //Load Constructor
        public Segment(string fileData, List<Segment> list)
        {
            this.list = list;
            this.Load(fileData);
            list.Add(this);

            this.aabb = new AABB(this.Transform.vPosition, 0, 0);
            this.BuildAABB();
        }

        #endregion



        #region Functions
        public void BuildAABB()
        {
            this.aabb.HalfHeight = 0;
            this.aabb.HalfWidth = 0;

            Vector3 oldPos = this.Transform.vPosition;

            if (this.list_Objects.Count > 0) this.aabb.vPosition = this.list_Objects[this.list_Objects.Count - 1].Position;
            for (int iCount = this.list_Objects.Count - 1; iCount >= 0; --iCount)
            {
                this.aabb = AABB.CombineAABBs(this.aabb, this.list_Objects[iCount].rigidBody.aabb);
            }


            this.Transform.vPosition = this.aabb.vPosition;

            this.segmentEnd.Transform.vPosition += oldPos - this.Transform.vPosition;
            this.segmentStart.Transform.vPosition += oldPos - this.Transform.vPosition;
        }
        #endregion


        #region Draw Functions
        public virtual void Draw(XnaWindow monoGameWindow)
        {
            for (int i = 0; i < this.list_Objects.Count; ++i) { this.list_Objects[i].Draw(monoGameWindow); }
        }

        public virtual void DrawStartEnd(XnaWindow monoGameWindow)
        {
            segmentStart.Draw(monoGameWindow);
            segmentEnd.Draw(monoGameWindow);
        }

        public virtual void DrawHighlight(XnaWindow monoGameWindow)
        {
            for (int iCount = 0, iCountMax = this.list_Objects.Count; iCount < iCountMax; ++iCount)
            {
                VectorHelper.DrawVertex(this.list_Objects[iCount].Position, monoGameWindow, Color.Purple);
            }
            this.aabb.Draw(monoGameWindow, Color.Pink);
        }

        #endregion

        #region Load Functions

        public virtual void Load(string location)
        {
            string line;
            StreamReader sr = new StreamReader(location);
            line = sr.ReadLine();

            this.ID = new UniqueIdentifier(StringMalarkey.ExtractString(line, "UNIQUEID"), list.Count, this.GetMyIndex, this.FindID);
            this.Difficulty = int.Parse(StringMalarkey.ExtractString(line, "Difficulty"));

            this.Transform = new Transform();
            this.Transform.vPosition = StringMalarkey.GetVector3FromString(line, "Pos");

            this.segmentStart = new Thing2D_NonRb("#UNIQUEID# seg_Start #/UNIQUEID# #THING2DINDEX# 12 #/THING2DINDEX# #Pos# 0, 0, 0 #/Pos# #Rot# 0 #/Rot# #Scale# 2, 2, 1 #/Scale#", new List<Thing2D_NonRb>());
            this.segmentEnd = new Thing2D_NonRb("#UNIQUEID# seg_End #/UNIQUEID# #THING2DINDEX# 13 #/THING2DINDEX# #Pos# 2, 0, 0 #/Pos# #Rot# 0 #/Rot# #Scale# 2, 2, 1 #/Scale#", new List<Thing2D_NonRb>());
            segmentStart.Transform.vPosition = StringMalarkey.GetVector3FromString(line, "SegmentStartPos");
            segmentEnd.Transform.vPosition = StringMalarkey.GetVector3FromString(line, "SegmentEndPos");



            while ((line = sr.ReadLine()) != null)
            {
                if (line == "") continue;
                new Thing2D_Rb<RigidBody>(line, this.list_Objects);
                this.list_Objects[this.list_Objects.Count - 1].Position += this.Transform.vPosition;
                this.list_Objects[this.list_Objects.Count - 1].rigidBody.Rebuild();
                Globals.list_AllObjects.Add(this.list_Objects[this.list_Objects.Count - 1]);
            }
            sr.Close();
        }

        #endregion

        #region Save Functions

        public virtual void Save(StreamWriter sw)
        {

        }

        #endregion
    }
}
