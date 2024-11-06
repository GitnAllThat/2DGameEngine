using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using CustomControls;



namespace Tools
{
    public class ManipulationToolVPT: ManipulationTool
    {
        public List<VertexPositionTextureWrapper> oldVertices = new List<VertexPositionTextureWrapper>();



        public override Vector3 CenterPivot()
        {
            Vector3 center = Vector3.Zero;

            if (Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count > 0)
            {
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count; iCount < iCountMax; ++iCount)
                { 
                    if(Program.mainForm.thingEditorForm.TexCoordEditorMode)
                        center += VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].TextureCoordinate); 
                    else if(Program.mainForm.thingEditorForm.VertexEditorMode)
                        center += Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].Position; 
                }

                center /= Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count;
            }

            return center;
        }

        public override void Draw(XnaWindow xnaWindow)
        {

            if (Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count != 0)
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
        public void StoreOldVPTA(GameInput gameInput)
        {

            if (gameInput.MouseLeftPressed)
            {
                oldVertices.Clear();
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count; iCount < iCountMax; ++iCount)
                {
                    oldVertices.Add(new VertexPositionTextureWrapper(Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount]));
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


            if (Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count > 0)
            {
                MoveVertices(gameInput);
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
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count; iCount < iCountMax; ++iCount)
                {
                    if (Program.mainForm.thingEditorForm.TexCoordEditorMode)
                    {
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].TextureCoordinate += VertexPositionTextureArray.ConvertToTextureCoordSpace(position - pivotPos);
                    }
                    else if (Program.mainForm.thingEditorForm.VertexEditorMode)
                    {
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].Position += (position - pivotPos);
                    }
                }
            }

        }



        public bool SnapToVertex(GameInput gameInput)
        {
            bool snap = false;

            Vector3 pos = new Vector3();
            for (int jCount = 0, jCountMax = Program.mainForm.thingEditorForm.Thing2DSelection.Count; jCount < jCountMax; ++jCount)
            {
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.Length; iCount < iCountMax; ++iCount)
                {
                    snap = false;

                    if (Program.mainForm.thingEditorForm.TexCoordEditorMode)
                    {
                        if ((gameInput.mouseBC.GetCollisionSolver(new BoundingCircle(new Transform(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate), 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, 0.02f, 0, true)))[0].distance <= 0)
                        {
                            pos = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate);
                            snap = true;
                        }
                    }
                    if (Program.mainForm.thingEditorForm.VertexEditorMode)
                    {
                        if ((gameInput.mouseBC.GetCollisionSolver(new BoundingCircle(new Transform(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position, 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, 0.02f, 0, true)))[0].distance <= 0)
                        {
                            pos = Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position;
                            snap = true;
                        }
                    }
                    if (snap)
                    {
                        if (Program.mainForm.thingEditorForm.manipulationTool.IconMoveXY.IsIconClicked || gameInput.mouseStateCurrent.MiddleButton == ButtonState.Pressed) UpdateTransformation(pos, 0);
                        else if (Program.mainForm.thingEditorForm.manipulationTool.IconMoveX.IsIconClicked) UpdateTransformation(new Vector3(pos.X, Program.mainForm.thingEditorForm.manipulationTool.position.Y, 0), 0);
                        else if (Program.mainForm.thingEditorForm.manipulationTool.IconMoveY.IsIconClicked) UpdateTransformation(new Vector3(Program.mainForm.thingEditorForm.manipulationTool.position.X, pos.Y, 0), 0);
                        break;
                    }
                }
            }

            return snap;
        }










        public override void ScaleTool(GameInput gameInput)
        {
            ToolID = 3;

            StoreOldVPTA(gameInput);


            if (Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count > 1)
            {
                ScaleVertices(gameInput);
            }

        }










        public void ScaleVertices(GameInput gameInput)
        {

            UpdateTransformation(position, 0);
            UpdateTool(gameInput);


            if (IsScaleToolInUse())
            {
                Vector3 scale = MinScaleValue(RoundToGridSnapScale(GetScale()));
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count; iCount < iCountMax; ++iCount)
                {
                    if (Program.mainForm.thingEditorForm.TexCoordEditorMode)
                    {
                        Vector3 newPos = position + ((VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(oldVertices[iCount].TextureCoordinate) - position) * scale);
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].TextureCoordinate = VertexPositionTextureArray.ConvertToTextureCoordSpace(newPos);
                    }
                    else if (Program.mainForm.thingEditorForm.VertexEditorMode)
                    {
                        Vector3 newPos = position + ((oldVertices[iCount].Position - position) * scale);
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].Position = newPos;
                    }
                }
            }

        }























        public override void RotateTool(GameInput gameInput)
        {
            ToolID = 2;


            StoreOldVPTA(gameInput);


            if (Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count > 1)
            {
                RotateVertices(gameInput);
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
                
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Count; iCount < iCountMax; ++iCount)
                {
                    if (Program.mainForm.thingEditorForm.TexCoordEditorMode)
                    {
                        Vector3 newPos = (position + Vector3.Transform(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(oldVertices[iCount].TextureCoordinate) - position, Matrix.CreateRotationZ(angle)));
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].TextureCoordinate = VertexPositionTextureArray.ConvertToTextureCoordSpace(newPos);
                    }
                    else if (Program.mainForm.thingEditorForm.VertexEditorMode)
                    {
                        Vector3 newPos = (position + Vector3.Transform(oldVertices[iCount].Position - position, Matrix.CreateRotationZ(angle)));
                        Program.mainForm.thingEditorForm.selectionTool.selectedVertices[iCount].Position = newPos;
                    }
                }
            }

        }


        public void PivotRotationTool()
        {
            
        }


    }
}
