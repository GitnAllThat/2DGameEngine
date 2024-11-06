using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using Global_Data;
using Things;
using CustomControls;

namespace Tools
{


    public class SelectionToolObjects : SelectionTool
    {
        public enum SelectionMode : int { Objects, Segment, SegmentStartEnd };
        public SelectionMode selectionMode;


        public List<object> selectedObjects = new List<object>();



        public delegate bool SelectTest(object o);
        public SelectTest selectTest = null;





        public virtual void UpdateSelectionFunctions()
        {
            if (this.selectionMode == SelectionMode.Objects) this.selectTest = ObjectSelectTest;
            if (this.selectionMode == SelectionMode.Segment) this.selectTest = SegmentSelectTest;
            if (this.selectionMode == SelectionMode.SegmentStartEnd) this.selectTest = SegmentStartEndSelectTest;
        }


        public override void UseSelectionTool(GameInput gameInput, ManipulationTool manipulationTool)
        {
              //Monogame Reimplement
            if (gameInput.xnaWindow.Focused && !manipulationTool.IsToolInUse())
            {
                SelectionBox.UpdateSelectionBox(gameInput);
                manipulationTool.IsToolInUse();
                if (this.selectionMode == SelectionMode.Objects) Select(gameInput, Globals.list_AllObjects.ToList<object>());
                if (this.selectionMode == SelectionMode.Segment) Select(gameInput, Globals.list_Segments.ToList<object>());

                if (this.selectionMode == SelectionMode.SegmentStartEnd)
                {
                    List<object> list = new List<object>();
                    for (int iCount = 0; iCount < Globals.list_Segments.Count; ++iCount)
                    {
                        list.Add(Globals.list_Segments[iCount].segmentStart);
                        list.Add(Globals.list_Segments[iCount].segmentEnd);
                    }
                    Select(gameInput, list);
                }
            }
            
        }









        public void Select(GameInput gameInput, List<object> oList)
        {
            if (gameInput.MouseLeftReleased)
            {
                if (!gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) this.selectedObjects.Clear();

                for (int iCount = 0, iCountMax = oList.Count; iCount < iCountMax; ++iCount)
                {
                    if (this.selectTest(oList[iCount]))
                    {
                        Add(oList[iCount], gameInput);
                        if (SelectionBox.selectionBox.CalculateArea() <= 0.025f) break; //Only Select 1 Object
                    }
                }


                UpdateOtherThings();
                UpdateThing2DSelection();
            }
        }

        public bool ObjectSelectTest(object o)
        {
            if (o is Thing2D_Rb<RigidBody> && (this.SelectionBox.selectionBox.GetCollisionSolver(((Thing2D_Rb<RigidBody>)o).rigidBody))[0].distance <= 0)
                    return true;
            else return false;
        }

        public bool SegmentSelectTest(object o)
        {
            if (o is Segment && AABB.AABBIntersectAABB(this.SelectionBox.selectionBox.aabb, ((Segment)o).aabb))
                return true;
            else return false;
        }

        public bool SegmentStartEndSelectTest(object o)
        {
            if (o is Thing2D_NonRb && (this.SelectionBox.selectionBox.GetCollisionSolver(new OBB(((Thing2D_NonRb)o).Transform, new Motion(), Vector3.Zero, 2, 2, 0, true)))[0].distance <= 0)
                return true;
            else return false;
        }

        /// <summary>
        /// Will add to the selection based upon various kebourd modifiers.
        /// Shift       : Will be added, unless it already exists, in which case it will be removed from the selection.
        /// Ctrl        : Will removed from the current selection.
        /// No Modifier : Will be added to the selection.
        /// </summary>
        public void Add(object addThis, GameInput gameInput)
        {
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftShift) || gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl))
            {
                bool hasAlready = false;
                for (int iCount = this.selectedObjects.Count - 1; iCount >= 0; --iCount)
                {
                    if (this.selectedObjects[iCount] == addThis)
                    {
                        this.selectedObjects.RemoveAt(iCount);
                        hasAlready = true;
                    }
                }
                if (!hasAlready && !gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) this.selectedObjects.Add(addThis);
            }
            else
            {
                this.selectedObjects.Add(addThis);
            }
        }




        public void UpdateThing2DSelection()
        {
            if (Program.mainForm.thingEditorForm == null) return;

            Program.mainForm.thingEditorForm.Thing2DSelection.Clear();
            Program.mainForm.thingEditorForm.selectionTool.selectedVertices.Clear();

            foreach (var item in this.selectedObjects.OfType<Thing2D_Rb<RigidBody>>())
            {
                bool exists = false;
                for (int jCount = 0, jCountMax = Program.mainForm.thingEditorForm.Thing2DSelection.Count; jCount < jCountMax; ++jCount)
                {
                    if (item.Thing2D_ID.Index == Program.mainForm.thingEditorForm.Thing2DSelection[jCount].ID.Index)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists) Program.mainForm.thingEditorForm.Thing2DSelection.Add(Thing2D.Thing2D_List[item.Thing2D_ID.Index]);
            }

        }



        //Code to display all of an objects properties on the right side bar.
        public void UpdateOtherThings()
        {

            Program.mainForm.manipulationTool.UpdateToolTransformations();           //MonoGame Reimplement DIRTY

            PropertyUpdater.ClearThisControl(Program.mainForm.flpRightSidebar);

            if (this.selectedObjects.Count > 0)
                { object o = (object)this.selectedObjects[0]; PropertyUpdater.DisplayProperties(ref o, Program.mainForm.flpRightSidebar); }


            foreach (var item in this.selectedObjects.OfType<Thing2D_Rb<RigidBody>>())
            {
                if(Program.mainForm.rigidThingEditorForm != null) Program.mainForm.rigidThingEditorForm.Thing2D_RbSelection = item;      //MonoGame Reimplement DIRTY
                break;
            }
            
        }





        #region Get (Objects:Segments:Thing2DNonRbs) From The Object List
        public List<Thing2D_Rb<RigidBody>> GetObjects()
        {
            List<Thing2D_Rb<RigidBody>> list = new List<Thing2D_Rb<RigidBody>>();
            foreach (var item in this.selectedObjects.OfType<Thing2D_Rb<RigidBody>>())
                list.Add(item);

            return list;
        }
        public List<Segment> GetSegments()
        {
            List<Segment> list = new List<Segment>();
            foreach (var item in this.selectedObjects.OfType<Segment>())
                list.Add(item);

            return list;
        }
        public List<Thing2D_NonRb> GetThing2DNonRb()
        {
            List<Thing2D_NonRb> list = new List<Thing2D_NonRb>();
            foreach (var item in this.selectedObjects.OfType<Thing2D_NonRb>())
                list.Add(item);

            return list;
        }
        #endregion


        public override void FocusSelection(XnaWindow xnaWindow)
        {
            if (xnaWindow.camera.CameraPosition.Z < 0) xnaWindow.camera.CameraPosition = new Vector3(xnaWindow.camera.CameraPosition.X, xnaWindow.camera.CameraPosition.Y, -xnaWindow.camera.CameraPosition.Z);

            Vector3 center = Thing2D_Rb<RigidBody>.GetCenter(this.GetObjects());
            xnaWindow.camera.FocusOnPosition(center, xnaWindow, center.Z);
        }



        public override void DrawSelection(XnaWindow xnaWindow) 
        {

            foreach (var item in this.selectedObjects.OfType<Thing2D_Rb<RigidBody>>())
            {
                item.rigidBody.HighLight(xnaWindow);
                item.rigidBody.DrawObjectCenter(xnaWindow);
                item.rigidBody.DrawCentroid(xnaWindow);
                item.Highlight(xnaWindow);
            }
            foreach (var item in this.selectedObjects.OfType<Thing2D_Rb<RigidBody>>())
            {
                item.Highlight(xnaWindow); //Gives the first selection a double highlight.
                break;
            }

            foreach (var item in this.selectedObjects.OfType<Segment>())
            {
                item.DrawHighlight(xnaWindow);
                VectorHelper.DrawVertex(item.Transform.vPosition, xnaWindow, Color.Pink);
            }


            foreach (var item in this.selectedObjects.OfType<Thing2D_NonRb>())
            {
                item.Highlight(xnaWindow);
            }
        }
    }
}
