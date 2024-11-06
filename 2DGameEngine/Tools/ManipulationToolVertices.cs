using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using CustomControls;



namespace Tools
{
    public class ManipulationToolVertices: ManipulationTool
    {
        public List<Vector3> oldVerticeIndexs = new List<Vector3>();
        public float oldRadius = 0;
        public float oldHalfHeight = 0;
        public float oldHalfWidth = 0;


        public override Vector3 CenterPivot()
        {
            Vector3 center = Vector3.Zero;

            
            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon)
            {
                if (Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count > 0)
                {
                    Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                    for (int iCount = Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                        {center += verts[Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs[iCount]];}

                    center /= Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count;
                }
            }
            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is OBB)
            {
                float halfwidth = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth;
                float halfheight = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight;

                if (Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected)
                    center.X = halfwidth;
                if (Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected)
                    center.Y = halfheight;
            }
            
            return center;
        }

        public override void Draw(XnaWindow xnaWindow)
        {

            if (Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count != 0 || Program.mainForm.rigidThingEditorForm.selectionTool.BcSelected ||
                Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected || Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected || Program.mainForm.rigidThingEditorForm.CENTROIDMODE)
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
        public void StoreOldVertices(GameInput gameInput)
        {

            if (gameInput.MouseLeftPressed)
            {
                oldVerticeIndexs.Clear();

                Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = 0, iCountMax = Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count; iCount < iCountMax; ++iCount)  //Note: Need to keep same vertex ordering
                {
                    oldVerticeIndexs.Add(verts[Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs[iCount]]);
                }
            }

        }

        public void StoreOldRadius(GameInput gameInput)
        {
  
            if (gameInput.MouseLeftPressed)
            {
                oldRadius = ((BoundingCircle)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).Radius;
            }

        }

        public void StoreOldHeightWidth(GameInput gameInput)
        {

            if (gameInput.MouseLeftPressed)
            {
                oldHalfHeight = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight;
                oldHalfWidth = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth;
            }

        }





        public override void NoTool(GameInput gameInput)
        {
            ToolID = 0;
        }


        public override void MoveTool(GameInput gameInput)
        {
            ToolID = 1;


            if (Program.mainForm.rigidThingEditorForm.RIGIDBODYMODE)
            {
                if (Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count != 0 ||
                    Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected || Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected)
                {
                    if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon) MoveVertices(gameInput);
                    if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is OBB) ModifyHeightWidth(gameInput);
                }
            }
            else if (Program.mainForm.rigidThingEditorForm.CENTROIDMODE)
            {
                MoveCenterOfMass(gameInput);
            }
 
        }

        public void MoveCenterOfMass(GameInput gameInput)
        {

            UpdateTransformation(position, 0);
            UpdateTool(gameInput);
            if (IsMoveToolInUse())
            {
                Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody.Centroid = position;
                Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody.UpdateRotatedCentroid();
            }

        }



        public void ModifyHeightWidth(GameInput gameInput)
        {

            UpdateTransformation(position, 0);
            UpdateTool(gameInput);
            
            if (IsMoveToolInUse())
            {
                if ((this.IconMoveX.IsIconClicked || this.IconMoveXY.IsIconClicked) && Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected) 
                    ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth = Math.Abs(this.position.X);
                
                if ((this.IconMoveY.IsIconClicked || this.IconMoveXY.IsIconClicked) && Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected) 
                    ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight = Math.Abs(this.position.Y);
            }

        }


        public void MoveVertices(GameInput gameInput)
        {
            UpdateTransformation(position, 0);
            UpdateTool(gameInput);

            bool hasSnapped = false;
            if (Keyboard.GetState()[Keys.V].Equals(KeyState.Down))
                hasSnapped = SnapToVertex(gameInput);

            Vector3 pivotPos = CenterPivot();

            if (IsMoveToolInUse() || hasSnapped)
            {
                Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                {
                    verts[Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs[iCount]] += (position - pivotPos);
                }
            }
        }



        public bool SnapToVertex(GameInput gameInput)
        {
            bool snap = false;
            Vector3 pos = new Vector3();


            Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;



            for (int iCount = verts.Length - 1; iCount >= 0; --iCount)
            {
                snap = false;

                if (gameInput.IsMouseHoveredOverVertex(verts[iCount]))
                {
                    pos = verts[iCount];
                    snap = true;
                }

                if (snap)
                {
                    if (Program.mainForm.rigidThingEditorForm.manipulationTool.IconMoveXY.IsIconClicked || gameInput.mouseStateCurrent.MiddleButton == ButtonState.Pressed) UpdateTransformation(pos, 0);
                    else if (Program.mainForm.rigidThingEditorForm.manipulationTool.IconMoveX.IsIconClicked) UpdateTransformation(new Vector3(pos.X, Program.mainForm.rigidThingEditorForm.manipulationTool.position.Y, 0), 0);
                    else if (Program.mainForm.rigidThingEditorForm.manipulationTool.IconMoveY.IsIconClicked) UpdateTransformation(new Vector3(Program.mainForm.rigidThingEditorForm.manipulationTool.position.X, pos.Y, 0), 0);
                    break;
                }
            }


            return snap;
        }










        public override void ScaleTool(GameInput gameInput)
        {
            ToolID = 3;



            if (Program.mainForm.rigidThingEditorForm.RIGIDBODYMODE)
            {
                if (Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count != 0 || Program.mainForm.rigidThingEditorForm.selectionTool.BcSelected ||
                    Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected || Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected)
                {
                    if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon) ScaleVertices(gameInput);
                    if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is OBB) ScaleHeightWidth(gameInput);
                    if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is BoundingCircle) ScaleRadius(gameInput);
                }
            }

        }







        public void ScaleHeightWidth(GameInput gameInput)
        {

            StoreOldHeightWidth(gameInput);
            UpdateTransformation(position, 0);
            UpdateTool(gameInput);
            if (IsScaleToolInUse())
            {
                Vector3 scale = MinScaleValue(RoundToGridSnapScale(GetScale()));

                if(Program.mainForm.rigidThingEditorForm.selectionTool.WidthSelected)((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth = oldHalfWidth * scale.X;
                if (Program.mainForm.rigidThingEditorForm.selectionTool.HeightSelected) ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight = oldHalfHeight * scale.Y;
            }

        }

        public void ScaleRadius(GameInput gameInput)
        {

            StoreOldRadius(gameInput);
            UpdateTransformation(position, 0);
            UpdateTool(gameInput);
            if (IsScaleToolInUse())
            {
                Vector3 s = MinScaleValue(RoundToGridSnapScale(GetScale()));
                float scale = 1;
                if (this.IconScaleX.IsIconClicked) scale = s.X;
                if (this.IconScaleY.IsIconClicked) scale = s.Y;
                if (this.IconScaleXY.IsIconClicked) scale = Math.Max(s.X, s.Y);


                ((BoundingCircle)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).Radius = oldRadius * scale;
            }

        }




        public void ScaleVertices(GameInput gameInput)
        {

            StoreOldVertices(gameInput);
            UpdateTransformation(position, 0);
            UpdateTool(gameInput);


            if (IsScaleToolInUse())
            {
                Vector3 scale = MinScaleValue(RoundToGridSnapScale(GetScale()));

                Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                {
                    Vector3 newPos = position + ((oldVerticeIndexs[iCount] - position) * scale);
                    verts[Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs[iCount]] = newPos;
                }

            }

        }























        public override void RotateTool(GameInput gameInput)
        {
            ToolID = 2;



            if (Program.mainForm.rigidThingEditorForm.RIGIDBODYMODE)
            {
                if (Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count > 1)
                {
                    StoreOldVertices(gameInput);
                    RotateVertices(gameInput);
                }
            }
   
        }





        public void RotateVertices(GameInput gameInput)
        {

            UpdateTransformation(position, 0);
            UpdateTool(gameInput);



            if (gameInput.MouseLeftIsDown && IsRotateToolInUse())
            {
                float angle = MathHelper.ToRadians(GetRotation());
                if (GRIDSNAPROTATE) angle = RoundToGridSnap(angle, MathHelper.ToRadians(GRIDSNAPROTATEVAL));


                Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                {
                    Vector3 newPos = (position + Vector3.Transform(oldVerticeIndexs[iCount] - position, Matrix.CreateRotationZ(angle)));
                    verts[Program.mainForm.rigidThingEditorForm.selectionTool.selectedVerticeIndexs[iCount]] = newPos;
                }

            }
        }


        public void PivotRotationTool()
        {
            
        }


    }
}
