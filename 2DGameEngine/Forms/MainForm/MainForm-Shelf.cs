using _2d_Objects;
using CommonWinFormsFunctions;
using Global_Data;
using LevelCreator.EditorForms;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Things;
using Tools;

namespace _2DLevelCreator
{
    public partial class MainForm : Form
    {
        private void PrepareThingEditorForm()
        {
            if (thingEditorForm == null)
                thingEditorForm = new ThingEditorForm();

            thingEditorForm.Show();
            thingEditorForm.Focus();
            thingEditorForm.thingEditorWindow.Focus();
        }

        #region Opens Thing2D Editor: Texture Editor Mode

        private void tsbTexCoordEditor_Click(object sender, EventArgs e)
        {
            PrepareThingEditorForm();

            //MonoGame Reimplement :I think i need to swap the false and true
            thingEditorForm.VertexEditorMode = true;
            thingEditorForm.TexCoordEditorMode = false;
        }


        #endregion

        #region Opens Thing2D Editor: Vertex Editor Mode

        private void tsbVertexEditor_Click(object sender, EventArgs e)
        {
            PrepareThingEditorForm();

            thingEditorForm.VertexEditorMode = true;
            thingEditorForm.TexCoordEditorMode = false;

        }

        #endregion

        #region Planar Maps To Object Space

        private void tsbPlanarMapObjectSpace_Click(object sender, EventArgs e)
        {
            PrepareThingEditorForm();

            thingEditorForm.VertexEditorMode = true;
            thingEditorForm.TexCoordEditorMode = false;
            thingEditorForm.PlanarMapObjectSpace(new Vector3(0.5f, 0.5f, 0));

        }

        #endregion


        #region Planar Maps To World Space
        private void tsbPlanarMapWorldSpace_Click(object sender, EventArgs e)
        {
            if (thingEditorForm == null)
                thingEditorForm = new ThingEditorForm();

            thingEditorForm.Hide();     //monogame reimplement. not sure i need this. original xnawindow didnt bother showing the editor when this button pressed

            MakeSeparateInstancesForSelectedThing2Ds();

            thingEditorForm.Thing2DSelection.Reverse();
            List<Thing2D_Rb<RigidBody>> list = this.selectionTool.GetObjects();
            for (int iCount = list.Count - 1; iCount >= 0; --iCount)
            {
                thingEditorForm.PlanarMapWorldSpace(Thing2D.Thing2D_List[list[iCount].Thing2D_ID.Index], list[iCount].Position, list[iCount].Scale, list[iCount].Rotation);
            }

        }

        #endregion

        public void MakeSeparateInstancesForSelectedThing2Ds()
        {


            thingEditorForm.Thing2DSelection.Clear();
            List<Thing2D_Rb<RigidBody>> list = this.selectionTool.GetObjects();
            for (int iCount = list.Count - 1; iCount >= 0; --iCount)
            {
                int numFound = 0;
                int index = -1;
                for (int jCount = Globals.list_AllObjects.Count - 1; jCount >= 0; --jCount)
                {
                    if (list[iCount].Thing2D_ID.UniqueID == Globals.list_AllObjects[jCount].Thing2D_ID.UniqueID)
                    {
                        numFound++;
                        index = list[iCount].Thing2D_ID.Index;
                    }
                }

                if (numFound > 1)
                {
                    Thing2D newThing2D = new Thing2D(Thing2D.Thing2D_List[index], Thing2D.Thing2D_List);
                    list[iCount].Thing2D_ID.Index = newThing2D.ID.Index;
                    thingEditorForm.Thing2DSelection.Add(newThing2D);

                    thingEditorForm.FillList_Things();
                }
                else if (numFound == 1)
                {
                    thingEditorForm.Thing2DSelection.Add(Thing2D.Thing2D_List[index]);
                }
            }

        }

        #region Match Alignment

        private void tsbMatchAlignment_Click(object sender, EventArgs e)
        {
            if (thingEditorForm == null)
                thingEditorForm = new ThingEditorForm();

            thingEditorForm.Hide();     //monogame reimplement. not sure i need this. original xnawindow didnt bother showing the editor when this button pressed


            List<Thing2D_Rb<RigidBody>> list = this.selectionTool.GetObjects();
            if (list.Count < 2) return;
            MakeSeparateInstancesForSelectedThing2Ds();
            thingEditorForm.Thing2DSelection.Reverse();

            //Calculate scale of first
            Thing2D tempThing2D = new Thing2D(list[0].GetThing2D(), new List<Thing2D>());

            thingEditorForm.PlanarMapWorldSpace(tempThing2D, list[0].Position, list[0].Scale, list[0].Rotation);



            //Work out how the first selection was positioned and scaled relative to how its planar map world space is positioned and scaled
            //
            //
            Vector3 tempCenter = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(VertexPositionTextureArray.GetTexCoordCenter(tempThing2D.vertexPositionTextureArray));
            Vector3 selectionCenter = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(VertexPositionTextureArray.GetTexCoordCenter(list[0].GetThing2D().vertexPositionTextureArray));



            Vector3 tex00NonRot = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(list[0].GetThing2D().vertexPositionTextureArray.VertexPositionTextureWrapper[0].TextureCoordinate);
            Vector3 temp00N = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(tempThing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[0].TextureCoordinate);
            Vector3 tex01NonRot = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(list[0].GetThing2D().vertexPositionTextureArray.VertexPositionTextureWrapper[1].TextureCoordinate);
            Vector3 temp01N = VertexPositionTextureArray.ConvertTextureCoordSpaceToWorld(tempThing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[1].TextureCoordinate);



            Vector3 edge1 = temp00N - temp01N; edge1.Normalize();
            Vector3 edge2 = tex00NonRot - tex01NonRot; edge2.Normalize();
            float angle = VectorHelper.GetAngleBetweenVectorDirections(edge2, edge1);


            tex00NonRot = Vector3.Transform(tex00NonRot - selectionCenter, Matrix.CreateRotationZ(MathHelper.ToRadians(-angle)));



            float x1Distance = tex00NonRot.X;
            float y1Distance = tex00NonRot.Y;

            float x2Distance = temp00N.X - tempCenter.X;
            float y2Distance = temp00N.Y - tempCenter.Y;

            Vector3 scale = new Vector3(x1Distance / x2Distance, y1Distance / y2Distance, 1);
            Vector3 position = selectionCenter - tempCenter;

            position = Vector3.Transform(position, Matrix.CreateRotationZ(MathHelper.ToRadians(-angle)));



            for (int iCount = list.Count - 1; iCount >= 1; --iCount)
            {
                Vector3 objectWorldDistance = (list[iCount].Position - list[0].Position) * scale;
                Vector3 distance = selectionCenter + Vector3.Transform(objectWorldDistance, Matrix.CreateRotationZ(MathHelper.ToRadians(angle)));

                thingEditorForm.PlanarMapWorldSpace(Thing2D.Thing2D_List[list[iCount].Thing2D_ID.Index], distance, list[iCount].Scale * scale, MathHelper.ToRadians(angle));
            }

        }

        #endregion



        private void tscbSelection_TextChanged(object sender, EventArgs e)
        {
            if (this.tscbSelection.Text == "Object") this.selectionTool.selectionMode = SelectionToolObjects.SelectionMode.Objects;
            if (this.tscbSelection.Text == "Segment") this.selectionTool.selectionMode = SelectionToolObjects.SelectionMode.Segment;
            if (this.tscbSelection.Text == "Segment StartEnd") this.selectionTool.selectionMode = SelectionToolObjects.SelectionMode.SegmentStartEnd;
            this.selectionTool.UpdateSelectionFunctions();
        }

        #region Segment Code


        private void txtSegmentIndex_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(((ToolStripTextBox)sender).Text, out int index))
            {
                if (index > (Globals.list_Segments.Count - 1) || index < 0)
                {
                    index = 0;
                    ((ToolStripTextBox)sender).Text = "0";
                }
                if (Globals.list_Segments.Count == 0) ((ToolStripTextBox)sender).Text = "";


                Segment.GlobalIndex = index;
            }
        }

        private void tsbNewSegment_Click(object sender, EventArgs e)
        {
            new Segment("newSegment", new Transform(), 0, Globals.list_Segments);

            if (Globals.list_Segments.Count > 1)
                Segment.AttatchToSegmentEnd(Globals.list_Segments[Globals.list_Segments.Count - 1], Globals.list_Segments[Globals.list_Segments.Count - 2]);

            Globals.list_Segments[Globals.list_Segments.Count - 1].Transform.vPosition += new Vector3(2, 0, 0);

            this.txtSegmentIndex.Text = (Globals.list_Segments.Count - 1).ToString();
        }

        private void tsbDeleteSegment_Click(object sender, EventArgs e)
        {
            if (this.txtSegmentIndex.Text == "") return;

            int index = int.Parse(this.txtSegmentIndex.Text);

            for (int iCount = Globals.list_Segments[index].list_Objects.Count - 1; iCount >= 0; --iCount)
            {
                for (int jCount = Globals.list_AllObjects.Count - 1; jCount >= 0; --jCount)
                {
                    if (Globals.list_AllObjects[jCount] == Globals.list_Segments[index].list_Objects[iCount])
                    {
                        Globals.list_AllObjects.RemoveAt(jCount);
                    }
                }
            }
            Globals.list_Segments[index].list_Objects.Clear();
            Globals.list_Segments.RemoveAt(index);
            this.txtSegmentIndex.Text = (index - 1).ToString();
        }

        private void tsbAddToSegment_Click(object sender, EventArgs e)
        {
            if (this.txtSegmentIndex.Text == "") return;

            int index = int.Parse(this.txtSegmentIndex.Text);

            //Remove selected objects from any other segments if present.

            List<Thing2D_Rb<RigidBody>> list = this.selectionTool.GetObjects();
            for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
            {
                for (int jCount = 0, jCountMax = Globals.list_Segments.Count; jCount < jCountMax; ++jCount)
                {
                    for (int kCount = Globals.list_Segments[jCount].list_Objects.Count - 1; kCount >= 0; --kCount)
                    {
                        if (Globals.list_Segments[jCount].list_Objects[kCount] == list[iCount])
                            Globals.list_Segments[jCount].list_Objects.RemoveAt(kCount);
                    }
                }
            }


            //Now add it to this segment
            for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
            {
                Globals.list_Segments[index].list_Objects.Add(list[iCount]);
            }

            Globals.list_Segments[index].BuildAABB();
        }

        private void tsbRemoveFromSegment_Click(object sender, EventArgs e)
        {
            if (this.txtSegmentIndex.Text == "") return;

            int index = int.Parse(this.txtSegmentIndex.Text);

            List<Thing2D_Rb<RigidBody>> list = this.selectionTool.GetObjects();

            for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
            {
                for (int kCount = Globals.list_Segments[index].list_Objects.Count - 1; kCount >= 0; --kCount)
                {
                    if (Globals.list_Segments[index].list_Objects[kCount] == list[iCount])
                        Globals.list_Segments[index].list_Objects.RemoveAt(kCount);
                }
            }
            Globals.list_Segments[index].BuildAABB();
        }


        private void tsbLinkSegments_Click(object sender, EventArgs e)
        {
            //I never got around to writing code for this
        }
        private void tsbInspectSegment_Click(object sender, EventArgs e)
        {
            if (this.txtSegmentIndex.Text == "") return;

            int index = int.Parse(this.txtSegmentIndex.Text);

            PropertyUpdater.ClearThisControl(this.flpRightSidebar);
            object TEMPO = (object)Globals.list_Segments[index]; PropertyUpdater.DisplayProperties(ref TEMPO, this.flpRightSidebar);
        }

        #endregion


        #region Plays The Game
        private void tsbPlay_Click(object sender, EventArgs e)
        {

            //if (gameWindowForm == null)
            { 
                gameWindowForm = new GameWindowForm();
                //gameWindowForm.GameInitiate();  //monogame reimplement?
            }


            gameWindowForm.Show();
            gameWindowForm.Focus();
            gameWindowForm.gameWindow.Focus();
        }
        #endregion


        private void tsbRigidBodyEditor_Click(object sender, EventArgs e)
        {
            if (rigidThingEditorForm == null)
                rigidThingEditorForm = new RigidThingEditorForm();


            rigidThingEditorForm.Show();
            rigidThingEditorForm.Focus();
            rigidThingEditorForm.rigidThingEditorWindow.Focus();
        }
    }
}
