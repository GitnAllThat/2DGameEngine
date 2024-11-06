using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using _2d_Objects;
using _2DLevelCreator;
using Things;
using CustomControls;

namespace Tools
{
    public class ManipulationToolObjects: ManipulationTool
    {
        public  List<Thing2D_Rb<RigidBody>> oldObjects = new List<Thing2D_Rb<RigidBody>>();


        public override Vector3 CenterPivot()
        {
             //Monogame Reimplement DIRTY
            if (Program.mainForm.selectionTool.selectionMode == SelectionToolObjects.SelectionMode.Objects)
            {
                return Thing2D_Rb<RigidBody>.GetCenter(Program.mainForm.selectionTool.GetObjects());
            }

            return Vector3.Zero;
        }


        public override void UpdateToolTransformations()
        {
            //Monogame Reimplement DIRTY
            if (Program.mainForm.selectionTool.selectionMode == SelectionToolObjects.SelectionMode.Objects)
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();
                Vector3 center = Thing2D_Rb<RigidBody>.GetCenter(list);
                if (list.Count == 1)
                    Program.mainForm.manipulationTool.UpdateTransformation(center, list[0].Rotation);
                else if (list.Count > 1)
                    Program.mainForm.manipulationTool.UpdateTransformation(center, 0);
            }

        }



        public override void Draw(XnaWindow xnaWindow)
        {
            //Monogame Reimplement DIRTY
            if (Program.mainForm.selectionTool.selectedObjects.Count != 0)
            {
                if (this.ToolID == 1) DrawMoveTool(xnaWindow);
                if (this.ToolID == 2) DrawRotateTool(xnaWindow);
                if (this.ToolID == 3) DrawScaleTool(xnaWindow);
            }
        }








        /// <summary>
        /// Some manipulations require the use of previous old properties before any 
        /// manipulation was taken place. Stores current selectedObjects in a temp list
        /// called oldObjects.
        /// </summary>
        public void StoreOldObjects(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (gameInput.MouseLeftPressed)
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();
                oldObjects.Clear();
                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    new Thing2D_Rb<RigidBody>(list[iCount], oldObjects);
                }
            }
        }






        public override void NoTool(GameInput gameInput)
        {
            ToolID = 0;
        }


        public override void MoveTool(GameInput gameInput)
        {
            ToolID = 1;

            MoveObjects(gameInput);
        }



        public void MoveObjects(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (IsMoveToolInUse())
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();
                Vector3 pivotPos = Thing2D_Rb<RigidBody>.GetCenter(list);

                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    list[iCount].Position += (position - pivotPos);
                    list[iCount].rigidBody.Update();
                }
            }
        }














        public override void ScaleTool(GameInput gameInput)
        {
            ToolID = 3;

            StoreOldObjects(gameInput);

            if (TRANSFORMASGROUP)
                ScaleObjectsAsAGroup(gameInput);
            else
                ScaleObjects(gameInput);
        }




        public void ScaleObjects(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (IsScaleToolInUse())
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();
                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    list[iCount].rigidBody.RescaleTo(MinScaleValue(RoundToGridSnapScale(GetScale() * oldObjects[iCount].Scale)));
                    list[iCount].rigidBody.Update();
                }
            }
        }



        public void ScaleObjectsAsAGroup(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (IsScaleToolInUse())
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();
                Vector3 scale = MinScaleValue(RoundToGridSnapScale(GetScale()));
                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    list[iCount].rigidBody.RescaleTo(scale * oldObjects[iCount].Scale);
                    list[iCount].Position = position + ((oldObjects[iCount].Position - position) * scale);
                    list[iCount].rigidBody.Update();
                }
            }
        }























        public override void RotateTool(GameInput gameInput)
        {
            ToolID = 2;

            StoreOldObjects(gameInput);


            if(TRANSFORMASGROUP)
                RotateObjectsAsAGroup(gameInput);
            else
                RotateObjects(gameInput);
        }


        public void RotateObjects(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (gameInput.MouseLeftIsDown && IsRotateToolInUse())
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();

                float angle = MathHelper.ToRadians(GetRotation());

                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    float rotation = (GRIDSNAPROTATE) ? (RoundToGridSnap(oldObjects[iCount].Rotation + angle, MathHelper.ToRadians(GRIDSNAPROTATEVAL))) : (oldObjects[iCount].Rotation + angle);

                    list[iCount].Rotation = rotation;
                }
            }
        }

        public void RotateObjectsAsAGroup(GameInput gameInput)
        {
            //Monogame Reimplement DIRTY
            if (gameInput.MouseLeftIsDown && IsRotateToolInUse())
            {
                List<Thing2D_Rb<RigidBody>> list = Program.mainForm.selectionTool.GetObjects();

                float angle = MathHelper.ToRadians(GetRotation());
                if (GRIDSNAPROTATE) angle = RoundToGridSnap(angle, MathHelper.ToRadians(GRIDSNAPROTATEVAL));

                for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                {
                    float rotation = oldObjects[iCount].Rotation + angle;

                    //Have to modify the object center. Example: To reposition the centroid of the Anchor     
                    list[iCount].Rotation = rotation;
                    list[iCount].Position = position + Vector3.Transform(oldObjects[iCount].Position - position, Matrix.CreateRotationZ(angle));
                }
            }
        }


    }
}
