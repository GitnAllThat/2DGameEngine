using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Things;
using Global_Data;
using Shapes;
using Tools;
using CommonWinFormsFunctions;

namespace _2DLevelCreator
{
    public partial class ThingEditorForm : Form
    {
        public ManipulationToolVPT manipulationTool = new ManipulationToolVPT();
        public SelectionToolVPT selectionTool = new SelectionToolVPT();

        public List<Thing2D> Thing2DSelection = new List<Thing2D>();
        public Thing2D Thing2DSelectionRenderView = null;

        public Grid gridTexCoords;
        public Grid gridThing2D;

        public bool VertexEditorMode = false;
        public bool TexCoordEditorMode = true;




        public ThingEditorForm()
        {
            InitializeComponent();
            this.wireMouseDown(this.Controls);
            Initiate();
        }


        public void Initiate()
        {
            this.manipulationTool.GRIDSNAPMOVEVAL = float.Parse(this.txtGridSnapMove.Text);
            this.manipulationTool.GRIDSNAPROTATEVAL = float.Parse(this.txtGridSnapRotate.Text);
            this.manipulationTool.GRIDSNAPSCALEVAL = float.Parse(this.txtGridSnapScale.Text);

            this.txtGridSizeTex_TextChanged(this.txtGridSizeTex, null);
            this.txtGridSizeThing2D_TextChanged(this.txtGridSizeThing2D, null);


            Thing2DSelectionRenderView = new Thing2D(Thing2D.Thing2D_List[0], new List<Thing2D>());

            this.txtTransparency_TextChanged(this.txtTransparency, null);   //This will set the Texture Coordinate Transparency to the value in the Textbox
        }


        public void wireMouseDown(Control.ControlCollection ctls)
        {
            // Hook MouseDown event for all controls
            foreach (Control ctl in ctls)
            {
                ctl.MouseDown += this.GainFocusOnMouseDown;
                wireMouseDown(ctl.Controls);
            }
        }

        private void GainFocusOnMouseDown(object sender, MouseEventArgs e)
        {
            ((Control)(sender)).Focus();
        }

        #region Handle Form Resizing

        private void ResizeForm(object sender, EventArgs e)
        {
            flpRightSidebar.Size = new Size(flpRightSidebar.Width, expRightSidebar.Height);
            flpLeftSidebar.Size = new Size(flpLeftSidebar.Width, expLeftSidebar.Height);
            this.thingEditorWindow.Size = new Size(this.Width - 10, flpRightSidebar.Height);
        }

        #endregion


        #region Handle Checking If Mouse Is In Screen Or Not

        private void thingEditorWindow_MouseLeave(object sender, EventArgs e)
        {
            this.thingEditorWindow.gameInput.isMouseOnScreen = false;         //monogame reimplement
        }
        private void thingEditorWindow_MouseEnter(object sender, EventArgs e)
        {
            this.thingEditorWindow.gameInput.isMouseOnScreen = true;          //monogame reimplement
        }
        private void thingEditorWindow_Click(object sender, EventArgs e)
        {
            this.thingEditorWindow.Focus();                                   //monogame reimplement
            this.thingEditorWindow.gameInput.isMouseOnScreen = true;          //monogame reimplement
        }

        #endregion








        #region Handle The Closing Form Event

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            //http://stackoverflow.com/questions/2021681/hide-form-instead-of-closing-when-close-button-clicked
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        #endregion


        #region List Functions

        public void FillList_Things()
        {
            ListBox listBox = (ListBox)this.Controls.Find("lstThing2D", true).FirstOrDefault();
            listBox.Items.Clear();
            for (int iCount = 0, iCountMax = Thing2D.Thing2D_List.Count; iCount < iCountMax; ++iCount)
            {
                listBox.Items.Add(Thing2D.Thing2D_List[iCount].ID.UniqueID);
            }
        }


        private void lstThing2D_MouseDoubleClick(object sender, EventArgs e)
        {
            int index = this.lstThing2D.IndexFromPoint(((MouseEventArgs)(e)).Location);
            if (index != ListBox.NoMatches)
            {
                index = ((ListBox)(sender)).SelectedIndex;

                string val = ((ListBox)(sender)).Items[index].ToString();
                for (int i = 0; i < Thing2D.Thing2D_List.Count; ++i)
                {
                    if (Thing2D.Thing2D_List[i].ID.UniqueID == val)
                    {
                        Thing2DSelection.Clear();
                        selectionTool.selectedVertices.Clear();

                        Thing2DSelection.Add(Thing2D.Thing2D_List[i]);
                        Thing2DSelectionRenderView.MaterialID = Thing2DSelection[0].MaterialID;


                        PropertyUpdater.ClearThisControl(this.flpRightSidebar);
                        object TEMPO = (object)Thing2D.Thing2D_List[i]; PropertyUpdater.DisplayProperties(ref TEMPO, this.flpRightSidebar);

                        break;
                    }
                }
            }
            //this.XnaWindow.Focus(); //This causes the selected object to be deselected. presumably because the game window now detects a 
            //click in this location wich generates a selection box selecting nothing therefore deselecting the object
            //Maybe a fix is to create a temp block on the selection tool until reaching the end of gameupdate
        }

        #endregion


        private void tsbAddVertice_Click(object sender, EventArgs e)
        {

            if (Thing2DSelection != null && this.selectionTool.selectedVertices.Count == 2)
            {
                for (int tCount = 0, tCountMax = Thing2DSelection.Count; tCount < tCountMax; ++tCount)
                {
                    int index_01 = -1; bool index_01Found = false;
                    int index_02 = -1; bool index_02Found = false;
                    int index_03 = -1; bool index_03Found = false;
                    int selectedIndex_01 = -1;
                    int selectedIndex_02 = -1;
                    int notselectedIndex = -1;

                    for (int iCount = 0, iCountMax = Thing2DSelection[tCount].vertexPositionTextureArray.Length; iCount < iCountMax; iCount += 3)
                    {
                        index_01 = iCount;
                        index_02 = iCount + 1;
                        index_03 = iCount + 2;

                        if (this.selectionTool.selectedVertices[0] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount])
                        {
                            index_01Found = true;
                        }
                        else if (this.selectionTool.selectedVertices[0] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 1])
                        {
                            index_02Found = true;
                        }
                        else if (this.selectionTool.selectedVertices[0] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 2])
                        {
                            index_03Found = true;
                        }

                        if (this.selectionTool.selectedVertices[1] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount])
                        {
                            index_01Found = true;
                        }
                        else if (this.selectionTool.selectedVertices[1] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 1])
                        {
                            index_02Found = true;
                        }
                        else if (this.selectionTool.selectedVertices[1] == Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount + 2])
                        {
                            index_03Found = true;
                        }

                        if (index_01Found && index_02Found)
                        {
                            selectedIndex_01 = index_01;
                            selectedIndex_02 = index_02;
                            notselectedIndex = index_03;
                            break;
                        }
                        if (index_01Found && index_03Found)
                        {
                            selectedIndex_01 = index_01;
                            selectedIndex_02 = index_03;
                            notselectedIndex = index_02;
                            break;
                        }
                        if (index_02Found && index_03Found)
                        {
                            selectedIndex_01 = index_02;
                            selectedIndex_02 = index_03;
                            notselectedIndex = index_01;
                            break;
                        }
                    }
                    if (selectedIndex_01 == -1 || selectedIndex_02 == -1 || notselectedIndex == -1) return;
                    if (selectedIndex_01 > selectedIndex_02) { int temp = selectedIndex_01; selectedIndex_01 = selectedIndex_02; selectedIndex_02 = temp; }


                    VertexPositionTextureWrapper vptw0;
                    VertexPositionTextureWrapper vptw1;
                    VertexPositionTextureWrapper vptw2;
                    VertexPositionTextureWrapper vptwa;


                    vptwa = new VertexPositionTextureWrapper((Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_01].Position + Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_02].Position) / 2,
                                                                (Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_01].TextureCoordinate + Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_02].TextureCoordinate) / 2);

                    VertexPositionTextureWrapper[] vptwB = new VertexPositionTextureWrapper[6];

                    if (notselectedIndex > selectedIndex_01 && notselectedIndex > selectedIndex_02)
                    {
                        vptw0 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_01]);
                        vptw1 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_02]);
                        vptw2 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[notselectedIndex]);

                        vptwB[0] = new VertexPositionTextureWrapper(vptw2); vptwB[1] = new VertexPositionTextureWrapper(vptw0); vptwB[2] = new VertexPositionTextureWrapper(vptwa);
                        vptwB[3] = new VertexPositionTextureWrapper(vptw2); vptwB[4] = new VertexPositionTextureWrapper(vptwa); vptwB[5] = new VertexPositionTextureWrapper(vptw1);
                    }
                    else if (notselectedIndex < selectedIndex_01 && notselectedIndex < selectedIndex_02)
                    {
                        vptw0 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[notselectedIndex]);
                        vptw1 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_01]);
                        vptw2 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_02]);
                        vptwB[0] = new VertexPositionTextureWrapper(vptw0); vptwB[1] = new VertexPositionTextureWrapper(vptw1); vptwB[2] = new VertexPositionTextureWrapper(vptwa);
                        vptwB[3] = new VertexPositionTextureWrapper(vptw0); vptwB[4] = new VertexPositionTextureWrapper(vptwa); vptwB[5] = new VertexPositionTextureWrapper(vptw2);
                    }
                    else
                    {
                        vptw0 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_01]);
                        vptw1 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[notselectedIndex]);
                        vptw2 = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[selectedIndex_02]);
                        vptwB[0] = new VertexPositionTextureWrapper(vptw1); vptwB[1] = new VertexPositionTextureWrapper(vptw2); vptwB[2] = new VertexPositionTextureWrapper(vptwa);
                        vptwB[3] = new VertexPositionTextureWrapper(vptw1); vptwB[4] = new VertexPositionTextureWrapper(vptwa); vptwB[5] = new VertexPositionTextureWrapper(vptw0);
                    }



                    VertexPositionTextureWrapper[] vptwA = new VertexPositionTextureWrapper[Thing2DSelection[tCount].vertexPositionTextureArray.Length + 3];

                    for (int iCount = 0, jCount = 0, iCountMax = vptwA.Length; iCount < iCountMax; ++iCount)
                    {
                        if (iCount != selectedIndex_01 && (iCount + 1) != selectedIndex_01 && (iCount + 2) != selectedIndex_01)
                        {
                            vptwA[iCount] = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[jCount++]);
                            vptwA[++iCount] = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[jCount++]);
                            vptwA[++iCount] = new VertexPositionTextureWrapper(Thing2DSelection[tCount].vertexPositionTextureArray.VertexPositionTextureWrapper[jCount++]);
                        }
                        else
                        {
                            vptwA[iCount] = vptwB[0];
                            vptwA[++iCount] = vptwB[1];
                            vptwA[++iCount] = vptwB[2];
                            vptwA[++iCount] = vptwB[3];
                            vptwA[++iCount] = vptwB[4];
                            vptwA[++iCount] = vptwB[5];
                            jCount += 3;
                        }

                    }
                    Thing2DSelection[tCount].vertexPositionTextureArray = new VertexPositionTextureArray(vptwA);
                    Thing2DSelection[tCount].primitiveCount = vptwA.Length / 3;
                }
            }
        }







        private void tsbDeleteVertice_Click(object sender, EventArgs e)
        {
            if (Thing2DSelection == null) return;
            for (int iCount = 0, iCountMax = Thing2DSelection.Count; iCount < iCountMax; ++iCount)
            {
                Thing2DSelection[iCount].vertexPositionTextureArray.RemoveEntries(this.selectionTool.selectedVertices);

                //LEAVE THIS
                Thing2DSelection[iCount].primitiveCount = Thing2DSelection[iCount].vertexPositionTextureArray.Length / 3;
            }

            PropertyUpdater.ClearThisControl(this.flpRightSidebar);
            object TEMPO = (object)Thing2DSelection[0]; PropertyUpdater.DisplayProperties(ref TEMPO, this.flpRightSidebar);
        }

        private void tsbTextureCoordsEditor_Click(object sender, EventArgs e)
        {
            VertexEditorMode = false;
            TexCoordEditorMode = true;
            Vector3 pivotPos = this.manipulationTool.CenterPivot();
            this.manipulationTool.UpdateTransformation(pivotPos, 0);
        }

        private void tsbVerticeEditor_Click(object sender, EventArgs e)
        {
            VertexEditorMode = true;
            TexCoordEditorMode = false;
            Vector3 pivotPos = this.manipulationTool.CenterPivot();
            this.manipulationTool.UpdateTransformation(pivotPos, 0);
        }





        private void tsbCreateUVMap_Click(object sender, EventArgs e)
        {
            PlanarMapObjectSpace(new Vector3(0.5f, 0.5f, 0));
        }

        public void PlanarMapObjectSpace(Vector3 position)
        {
            if (this.Thing2DSelection == null) return;
            for (int jCount = 0, jCountMax = Thing2DSelection.Count; jCount < jCountMax; ++jCount)
            {
                for (int iCount = 0, iCountMax = this.Thing2DSelection[jCount].vertexPositionTextureArray.Length; iCount < iCountMax; ++iCount)
                {
                    this.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate =
                        VertexPositionTextureArray.ConvertToTextureCoordSpace(this.Thing2DSelection[jCount].vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position + position);
                }
            }
            Vector3 pivotPos = this.manipulationTool.CenterPivot();
            this.manipulationTool.UpdateTransformation(pivotPos, 0);
        }



        public void PlanarMapWorldSpace(Thing2D thing2D, Vector3 position, Vector3 scale, float rotation)
        {
            Matrix rotMatrix = Matrix.CreateRotationZ(rotation);
            for (int iCount = 0, iCountMax = thing2D.vertexPositionTextureArray.Length; iCount < iCountMax; ++iCount)
            {
                thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].TextureCoordinate =
                    VertexPositionTextureArray.ConvertToTextureCoordSpace(Vector3.Transform(thing2D.vertexPositionTextureArray.VertexPositionTextureWrapper[iCount].Position * scale, rotMatrix) + position);

            }

            Vector3 pivotPos = this.manipulationTool.CenterPivot();
            this.manipulationTool.UpdateTransformation(pivotPos, 0);
        }









        private void tsbNewThing2D_Click(object sender, EventArgs e)
        {
            CreateNewThing2D();
        }

        public void CreateNewThing2D()
        {
            PopupCreateThing2D popup = new PopupCreateThing2D();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                Thing2D newThing2D = new Thing2D(Thing2D.Thing2D_List[0], Thing2D.Thing2D_List);
                string name = popup.txtName.Text;
                if (name == "") name = "No Name";
                newThing2D.ID.UniqueID = name;

                this.Thing2DSelection.Clear();
                this.Thing2DSelection.Add(newThing2D);

                PropertyUpdater.ClearThisControl(this.flpRightSidebar);
                object TEMPO = (object)newThing2D; PropertyUpdater.DisplayProperties(ref TEMPO, this.flpRightSidebar);

                this.FillList_Things();
            }

            popup.Dispose();
        }

        private void tsbDeleteThing2D_Click(object sender, EventArgs e)
        {
            DeleteThing2D();
            this.selectionTool.selectedVertices.Clear();
        }


        public void DeleteThing2D()
        {
            if (this.Thing2DSelection == null) return;//Nothing to delete.  
            //Implement popup box if nothing to delete

            PopupDeleteThing2D popup = new PopupDeleteThing2D();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Yes)
            {
                for (int jCount = 0, jCountMax = Thing2DSelection.Count; jCount < jCountMax; ++jCount)
                {
                    int index = this.Thing2DSelection[jCount].ID.Index;

                    if (index == 0) return; //Dont Delete Default Thing2D

                    for (int iCount = 0, iCountMax = Globals.list_AllObjects.Count; iCount < iCountMax; ++iCount)
                    {
                        if (Globals.list_AllObjects[iCount].Thing2D_ID.Index == index) Globals.list_AllObjects[iCount].Thing2D_ID.Index = 0;
                        else if (Globals.list_AllObjects[iCount].Thing2D_ID.Index > index) --Globals.list_AllObjects[iCount].Thing2D_ID.Index;
                    }
                    for (int iCount = 0, iCountMax = Globals.list_Blueprints.Count; iCount < iCountMax; ++iCount)
                    {
                        if (Globals.list_Blueprints[iCount].Thing2D_ID.Index == index) Globals.list_Blueprints[iCount].Thing2D_ID.Index = 0;
                        else if (Globals.list_Blueprints[iCount].Thing2D_ID.Index > index) --Globals.list_Blueprints[iCount].Thing2D_ID.Index;
                    }

                    if (Globals.background.thing2DIndex == index) Globals.background.thing2DIndex = 0;
                    else if (Globals.background.thing2DIndex > index) --Globals.background.thing2DIndex;


                    Thing2D.DeleteFromList(this.Thing2DSelection[jCount]);
                    this.FillList_Things();

                    PropertyUpdater.ClearThisControl(this.flpRightSidebar);
                    this.Thing2DSelection.Clear();
                }
            }
            popup.Dispose();
        }

        private void lstThing2D_MouseEnter(object sender, EventArgs e)
        {
            int oldTopIndex = ((ListBox)sender).TopIndex;
            int oldSelectedIndex = ((ListBox)sender).SelectedIndex;
            FillList_Things();
            ((ListBox)sender).SelectedIndex = oldSelectedIndex;
            ((ListBox)sender).TopIndex = oldTopIndex;
        }

        private void tsbCenterVertexPositions_Click(object sender, EventArgs e)
        {
            if (this.Thing2DSelection.Count == 0) return;
            VertexPositionTextureArray.CenterVerticesAroundOriginBoxStyle(this.Thing2DSelection[0].vertexPositionTextureArray);
        }



        //This needs to be on every form. So the event cant link to it...
        //Stops stupid input from the user (ie two decimal points or a "-" in the middle of a load of numbers
        public void TextboxValidateFloat(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox) Validation.ValidateText(typeof(float), ((TextBox)sender).Text, e, ((TextBox)sender).SelectionStart, ((TextBox)sender).SelectedText);
            if (sender is ToolStripTextBox) Validation.ValidateText(typeof(float), ((ToolStripTextBox)sender).Text, e, ((ToolStripTextBox)sender).SelectionStart, ((ToolStripTextBox)sender).SelectedText);
        }


    }
}
