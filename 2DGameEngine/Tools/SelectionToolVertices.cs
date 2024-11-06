using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using CustomControls;
using Shapes;

namespace Tools
{


    public class SelectionToolVertices : SelectionTool
    {
        public bool pivotToolUsedLastFrame = false;


        public List<int> selectedVerticeIndexs = new List<int>();
        
        public bool HeightSelected = false;
        public bool WidthSelected = false;

        public bool BcSelected = false;




        public override void UseSelectionTool(GameInput gameInput, ManipulationTool manipulationTool)
        {

            if ((!pivotToolUsedLastFrame && !Program.mainForm.rigidThingEditorForm.manipulationTool.IsToolInUse()) || (selectedVerticeIndexs.Count == 0 && !BcSelected && !HeightSelected && !WidthSelected))
            {
                if (Program.mainForm.rigidThingEditorForm.CENTROIDMODE) return;
                SelectionBox.UpdateSelectionBox(gameInput);
                Select_Rb_Componants(this.SelectionBox, gameInput);
            }
            pivotToolUsedLastFrame = Program.mainForm.rigidThingEditorForm.manipulationTool.IsToolInUse();

        }



        public void Select_Rb_Componants(Selectionbox selectionBox, GameInput gameInput)
        {

            if (gameInput.MouseLeftReleased && Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection != null)
            {
                if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is BoundingCircle) Select_BC(selectionBox, gameInput);
                if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is OBB) Select_HeightWidth(selectionBox, gameInput);
                if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon) Select_Vertices(selectionBox, gameInput);
            }

        }



        public void Select_BC(Selectionbox selectionBox, GameInput gameInput)
        {

            selectedVerticeIndexs.Clear();
            HeightSelected = false;
            WidthSelected = false;
            BcSelected = false;

            if (selectionBox.selectionBox.GetCollisionSolver(new BoundingCircle(new Transform(), new Motion(),Vector3.Zero,((BoundingCircle)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).Radius,0,true))[0].distance <= 0)
            {
                BcSelected = true;
            }

            UpdateOtherThings();
 
        }

        
        public void Select_HeightWidth(Selectionbox selectionBox, GameInput gameInput)
        {

            selectedVerticeIndexs.Clear();
            BcSelected = false;

            if (!gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) { WidthSelected = false; HeightSelected = false; }

            float halfwidth = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth;
            float halfheight = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight;

            if (selectionBox.selectionBox.GetCollisionSolver(new OBB(new Transform(new Vector3(0, halfheight, 0), 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, 0.02f, halfwidth * 2, 0, true))[0].distance <= 0 ||
                selectionBox.selectionBox.GetCollisionSolver(new OBB(new Transform(new Vector3(0, -halfheight, 0), 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, 0.02f, halfwidth * 2, 0, true))[0].distance <= 0)
            {
                HeightSelected = true;
            }
            if (selectionBox.selectionBox.GetCollisionSolver(new OBB(new Transform(new Vector3(halfwidth, 0, 0), 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, halfheight * 2, 0.02f, 0, true))[0].distance <= 0 ||
                selectionBox.selectionBox.GetCollisionSolver(new OBB(new Transform(new Vector3(-halfwidth, 0, 0), 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, halfheight * 2, 0.02f, 0, true))[0].distance <= 0)
            {
                WidthSelected = true;
            }

            UpdateOtherThings();

        }


        public void Select_Vertices(Selectionbox selectionBox, GameInput gameInput)
        {

            HeightSelected = false;
            WidthSelected = false;
            BcSelected = false;

            if (!gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) selectedVerticeIndexs.Clear();

            Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;



            for (int iCount = verts.Length - 1; iCount >= 0; --iCount)
            {

                if (selectionBox.selectionBox.GetCollisionSolver(new BoundingCircle(new Transform(verts[iCount], 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, 0.02f, 0, true))[0].distance <= 0)
                {
                    Add(iCount, gameInput);
                    if (SelectionBox.selectionBox.CalculateArea() <= 0.025f) { break; }
                }
            }

            UpdateOtherThings();

        }


        public void Add(int addThis, GameInput gameInput)
        {
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) || gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl))
            {
                bool hasAlready = false;
                for (int iCount = selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                {
                    if (selectedVerticeIndexs[iCount] == addThis)
                    {
                        selectedVerticeIndexs.RemoveAt(iCount);
                        hasAlready = true;
                    }
                }
                if (!hasAlready && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) selectedVerticeIndexs.Add(addThis);
            }
            else
            {
                selectedVerticeIndexs.Add(addThis);
            }
        }








        public void UpdateOtherThings()
        {

            Vector3 pivotPos = Program.mainForm.rigidThingEditorForm.manipulationTool.CenterPivot();
            Program.mainForm.rigidThingEditorForm.manipulationTool.UpdateTransformation(pivotPos, 0);

        }





        public void ClearAllSelections()
        {
            this.selectedVerticeIndexs.Clear();
            this.HeightSelected = false;
            this.WidthSelected = false;
            this.BcSelected = false;
        }


























        public override void FocusSelection(XnaWindow xnaWindow)
        {
            Vector3 center = Vector3.Zero;


            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection != null)
            {
                if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon)
                {
                    center = Program.mainForm.rigidThingEditorForm.manipulationTool.CenterPivot();
                }
            }

            if (xnaWindow.camera.CameraPosition.Z < 0) xnaWindow.camera.CameraPosition = new Vector3(xnaWindow.camera.CameraPosition.X, xnaWindow.camera.CameraPosition.Y, -xnaWindow.camera.CameraPosition.Z);
            xnaWindow.camera.FocusOnPosition(center, xnaWindow, center.Z);
 
        }






        public override void DrawSelection(XnaWindow xnaWindow) 
        {
            Color red = new Color(255, 0, 0, 150);
            Color green = new Color(0, 128, 0, 150);
   
            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection == null) return;

            

            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is BoundingCircle)
            {
                (new Circle(Vector3.Zero, ((BoundingCircle)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).Radius, 55, Circle.DrawStyle.Both, red, Color.White)).Draw(xnaWindow);

                if(this.BcSelected)
                    (new Circle(Vector3.Zero, ((BoundingCircle)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).Radius, 55, Circle.DrawStyle.Both, green, Color.White)).Draw(xnaWindow);
            }

            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is OBB)
            {
                float halfwidth = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfWidth;
                float halfheight = ((OBB)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).HalfHeight;

                (new Line(new Vector3(-halfwidth, halfheight, 0), new Vector3(halfwidth, halfheight, 0), red, 2)).Draw(xnaWindow);
                (new Line(new Vector3(halfwidth, halfheight, 0), new Vector3(halfwidth, -halfheight, 0), red, 2)).Draw(xnaWindow);
                (new Line(new Vector3(halfwidth, -halfheight, 0), new Vector3(-halfwidth, -halfheight, 0), red, 2)).Draw(xnaWindow);
                (new Line(new Vector3(-halfwidth, -halfheight, 0), new Vector3(-halfwidth, halfheight, 0), red, 2)).Draw(xnaWindow);

                if (this.WidthSelected)
                {
                    (new Line(new Vector3(halfwidth, halfheight, 0), new Vector3(halfwidth, -halfheight, 0), green, 2)).Draw(xnaWindow);
                    (new Line(new Vector3(-halfwidth, -halfheight, 0), new Vector3(-halfwidth, halfheight, 0), green, 2)).Draw(xnaWindow);
                }
                if (this.HeightSelected)
                {
                    (new Line(new Vector3(-halfwidth, halfheight, 0), new Vector3(halfwidth, halfheight, 0), green, 2)).Draw(xnaWindow);
                    (new Line(new Vector3(halfwidth, -halfheight, 0), new Vector3(-halfwidth, -halfheight, 0), green, 2)).Draw(xnaWindow);
                }

            }

            if (Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody is ConvexPolygon)
            {
                Vector3[] verts = ((ConvexPolygon)(Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = verts.Length - 1; iCount >= 0; --iCount)
                {
                    (new Line(verts[iCount], verts[(iCount + 1) % verts.Length], Color.Gray, 2)).Draw(xnaWindow);
                    VectorHelper.DrawVertex(verts[iCount], xnaWindow, red);
                }

                for (int iCount = this.selectedVerticeIndexs.Count - 1; iCount >= 0; --iCount)
                {
                    VectorHelper.DrawVertex(verts[this.selectedVerticeIndexs[iCount]], xnaWindow, green);
                }
            }

            if (Program.mainForm.rigidThingEditorForm.CENTROIDMODE)
            {
                Vector3 centerOfMass = Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection.rigidBody.Centroid;
                (new Circle(centerOfMass, 0.0018f * xnaWindow.camera.CameraPosition.Z, 111, Circle.DrawStyle.Both, Color.White, Color.White)).Draw(xnaWindow);
                (new Circle(centerOfMass, 0.0009f * xnaWindow.camera.CameraPosition.Z, 111, Circle.DrawStyle.Both, Color.Black, Color.Black)).Draw(xnaWindow);
            }

        }
    }
}
