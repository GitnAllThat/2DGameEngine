using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2DLevelCreator;
using CustomControls;


namespace Tools
{


    public class SelectionToolVPT : SelectionTool
    {
        public List<VertexPositionTextureWrapper> selectedVertices = new List<VertexPositionTextureWrapper>();
        
        public bool pivotToolUsedLastFrame = false;




        public override void UseSelectionTool(GameInput gameInput, ManipulationTool manipulationTool)
        {

            if ((!pivotToolUsedLastFrame && !Program.mainForm.thingEditorForm.manipulationTool.IsToolInUse()) || (selectedVertices.Count == 0))
            {
                SelectionBox.UpdateSelectionBox(gameInput);
                Select_Vertices(this.SelectionBox, gameInput);
            }
            pivotToolUsedLastFrame = Program.mainForm.thingEditorForm.manipulationTool.IsToolInUse();

        }




        public void Select_Vertices(Selectionbox selectionBox, GameInput gameInput)
        {

            if (gameInput.MouseLeftReleased && Program.mainForm.thingEditorForm.Thing2DSelection != null)
            {
                if (!gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) selectedVertices.Clear();
                for (int jCount = 0, jCountMax = Program.mainForm.thingEditorForm.Thing2DSelection.Count; jCount < jCountMax; ++jCount)
                {
                    for (int iCount = Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.Length - 1; iCount >= 0; --iCount)
                    {
                        

                        if ((Program.mainForm.thingEditorForm.TexCoordEditorMode && (selectionBox.selectionBox.GetCollisionSolver(VectorHelper.CreateVertexCollider(VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate), gameInput.xnaWindow.camera.CameraPosition.Z)))[0].distance <= 0)
                            || (Program.mainForm.thingEditorForm.VertexEditorMode && (selectionBox.selectionBox.GetCollisionSolver(VectorHelper.CreateVertexCollider(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position, gameInput.xnaWindow.camera.CameraPosition.Z)))[0].distance <= 0))
                        {
                            Add(Program.mainForm.thingEditorForm.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount], gameInput);
                            if (SelectionBox.selectionBox.CalculateArea() <= 0.025f) { jCount = jCountMax;  break; } 
                        }
                    }
                }
                UpdateOtherThings();
            }

        }



        public void Add(VertexPositionTextureWrapper addThis, GameInput gameInput)
        {
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) || gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl))
            {
                bool hasAlready = false;
                for (int iCount = selectedVertices.Count - 1; iCount >= 0; --iCount)
                {
                    if (selectedVertices[iCount] == addThis)
                    {
                        selectedVertices.RemoveAt(iCount);
                        hasAlready = true;
                    }
                }
                if (!hasAlready && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) selectedVertices.Add(addThis);
            }
            else
            {
                selectedVertices.Add(addThis);
            }
        }








        public void UpdateOtherThings()
        {

            Vector3 pivotPos = Program.mainForm.thingEditorForm.manipulationTool.CenterPivot();
            Program.mainForm.thingEditorForm.manipulationTool.UpdateTransformation(pivotPos, 0);
 
        }











        public override void FocusSelection(XnaWindow xnaWindow)
        {

            Vector3 center = Vector3.Zero;
            if (selectedVertices.Count > 0)
            {
                if (Program.mainForm.thingEditorForm.TexCoordEditorMode) center = new Vector3(VertexPositionTextureArray.GetTexCoordCenter(selectedVertices), 0);
                if (Program.mainForm.thingEditorForm.VertexEditorMode) center = VertexPositionTextureArray.GetVertexPosCenter(selectedVertices);
            }
            else if (Program.mainForm.thingEditorForm.Thing2DSelection.Count > 0)
            {
                for (int iCount = 0, iCountMax = Program.mainForm.thingEditorForm.Thing2DSelection.Count; iCount < iCountMax; ++iCount)
                {
                    if (Program.mainForm.thingEditorForm.TexCoordEditorMode) center += new Vector3(VertexPositionTextureArray.GetTexCoordCenter(Program.mainForm.thingEditorForm.Thing2DSelection[iCount].vertexPositionTextureArray), 0);
                    if (Program.mainForm.thingEditorForm.VertexEditorMode) center = VertexPositionTextureArray.GetVertexPosCenter(Program.mainForm.thingEditorForm.Thing2DSelection[iCount].vertexPositionTextureArray);
                }
                center /= Program.mainForm.thingEditorForm.Thing2DSelection.Count;
            }

            if (Program.mainForm.thingEditorForm.TexCoordEditorMode) center = new Vector3(VertexPositionTextureArray.ConvertToTextureCoordSpace(center),0);

            if (xnaWindow.camera.CameraPosition.Z < 0) xnaWindow.camera.CameraPosition = new Vector3(xnaWindow.camera.CameraPosition.X, xnaWindow.camera.CameraPosition.Y, -xnaWindow.camera.CameraPosition.Z);
            xnaWindow.camera.FocusOnPosition(center, xnaWindow, center.Z);

        }




        public override void DrawSelection(XnaWindow xnaWindow)
        {


        }

    }
}
