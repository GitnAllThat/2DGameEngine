using _2d_Objects;
using Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Things;
using Tools;
using Microsoft.Xna.Framework;
using CommonWinFormsFunctions;


namespace _2DLevelCreator
{
    public partial class RigidThingEditorForm : Form
    {
        public ManipulationToolVertices manipulationTool = new ManipulationToolVertices();
        public SelectionToolVertices selectionTool = new SelectionToolVertices();

        public Grid grid;

        public Thing2D_Rb<RigidBody> Thing2D_RbSelection;

        public bool RIGIDBODYMODE = true;
        public bool CENTROIDMODE = false;




        public RigidThingEditorForm()
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


            this.txtGridSize_TextChanged(this.txtGridSize, null);

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
            rigidThingEditorWindow.Size = new Size(this.Width - 10, flpRightSidebar.Height);
        }

        #endregion


        #region Handle Checking If Mouse Is In Screen Or Not

        private void XnaMainWindow_MouseLeave(object sender, EventArgs e)
        {
            this.rigidThingEditorWindow.gameInput.isMouseOnScreen = false;
        }

        private void XnaMainWindow_MouseEnter(object sender, EventArgs e)
        {
            this.rigidThingEditorWindow.gameInput.isMouseOnScreen = true;
        }

        private void XnaMainWindow_Click(object sender, EventArgs e)
        {
            this.rigidThingEditorWindow.Focus();
            this.rigidThingEditorWindow.gameInput.isMouseOnScreen = true;
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




        private void tsbAddVertex_Click(object sender, EventArgs e)
        {
            if (this.Thing2D_RbSelection == null) return;
            if (this.Thing2D_RbSelection.rigidBody is ConvexPolygon)
            {
                if (this.selectionTool.selectedVerticeIndexs.Count < 2) return;

                List<int[]> pairList = new List<int[]>();

                Vector3[] verts = ((ConvexPolygon)(this.Thing2D_RbSelection.rigidBody)).verts;

                for (int iCount = 0, iCountMax = this.selectionTool.selectedVerticeIndexs.Count; iCount < iCountMax; ++iCount)
                {
                    for (int jCount = 0, jCountMax = this.selectionTool.selectedVerticeIndexs.Count; jCount < jCountMax; ++jCount)
                    {
                        if (this.selectionTool.selectedVerticeIndexs[iCount] == (this.selectionTool.selectedVerticeIndexs[jCount] + 1) % verts.Length)
                        {
                            pairList.Add(new int[2] { this.selectionTool.selectedVerticeIndexs[iCount], this.selectionTool.selectedVerticeIndexs[jCount] });
                        }
                    }
                }


                Vector3[] newVerts = new Vector3[verts.Length + pairList.Count];
                int index = -1;
                for (int iCount = 0, iCountMax = verts.Length; iCount < iCountMax; ++iCount)
                {
                    ++index;
                    newVerts[index] = verts[iCount];

                    for (int jCount = 0, jCountMax = pairList.Count; jCount < jCountMax; ++jCount)
                    {
                        if (iCount == pairList[jCount][1])
                        {
                            ++index;
                            newVerts[index] = (verts[pairList[jCount][1]] + verts[pairList[jCount][0]]) * 0.5f;
                            break;
                        }
                    }
                }
                ((ConvexPolygon)(this.Thing2D_RbSelection.rigidBody)).verts = newVerts;
            }
        }


        private void tsbDeleteVertex_Click(object sender, EventArgs e)
        {
            if (this.Thing2D_RbSelection == null) return;
            if (this.Thing2D_RbSelection.rigidBody is ConvexPolygon)
            {
                Vector3[] verts = ((ConvexPolygon)(this.Thing2D_RbSelection.rigidBody)).verts;

                Vector3[] newVerts = new Vector3[Math.Max(verts.Length - this.selectionTool.selectedVerticeIndexs.Count, 3)];

                //Need to keep at least 3 verticies.
                int removeCount = this.selectionTool.selectedVerticeIndexs.Count - verts.Length + 3;
                while (removeCount-- > 0)
                {
                    this.selectionTool.selectedVerticeIndexs.RemoveAt(this.selectionTool.selectedVerticeIndexs.Count - 1);
                }


                int index = -1;
                int noAdded = 0;

                for (int iCount = 0, iCountMax = verts.Length; iCount < iCountMax; ++iCount)
                {
                    bool add = true;
                    for (int jCount = 0, jCountMax = this.selectionTool.selectedVerticeIndexs.Count; jCount < jCountMax; ++jCount)
                    {
                        if (this.selectionTool.selectedVerticeIndexs[jCount] == iCount)
                        {
                            add = false;
                            this.selectionTool.selectedVerticeIndexs.RemoveAt(jCount);
                            break;
                        }
                    }

                    if (add)
                    {
                        ++index;
                        ++noAdded;
                        newVerts[index] = verts[iCount];
                    }
                }
                ((ConvexPolygon)(this.Thing2D_RbSelection.rigidBody)).verts = newVerts;
            }
        }



        #region Convert Rigidbodies

        private void tsbConvertToBC_Click(object sender, EventArgs e)
        {
            this.selectionTool.ClearAllSelections();
            if (this.Thing2D_RbSelection == null) return;
            this.Thing2D_RbSelection.rigidBody = BoundingCircle.ConvertToBoundingCircle(this.Thing2D_RbSelection.rigidBody);
        }

        private void tsbConvertToOBB_Click(object sender, EventArgs e)
        {
            this.selectionTool.ClearAllSelections();
            if (this.Thing2D_RbSelection == null) return;
            this.Thing2D_RbSelection.rigidBody = OBB.ConvertToOBB(this.Thing2D_RbSelection.rigidBody);
        }

        private void tslConvertToConvexPolygon_Click(object sender, EventArgs e)
        {
            this.selectionTool.ClearAllSelections();
            if (this.Thing2D_RbSelection == null) return;
            this.Thing2D_RbSelection.rigidBody = ConvexPolygon.ConvertToConvexPolygon(this.Thing2D_RbSelection.rigidBody);
        }

        #endregion


        #region Center Thing2D Vertices (Positions)

        private void tsbCenterVertexPositions_Click(object sender, EventArgs e)
        {
            VertexPositionTextureArray.CenterVerticesAroundOriginBoxStyle(Thing2D.Thing2D_List[this.Thing2D_RbSelection.Thing2D_ID.Index].vertexPositionTextureArray);
        }

        #endregion


        #region Match Thing2D Vertices

        private void tsbMatchThing2DVerts_Click(object sender, EventArgs e)
        {
            if (this.Thing2D_RbSelection == null) return;
            if (this.Thing2D_RbSelection.rigidBody is BoundingCircle) this.RbMatchThing2D((BoundingCircle)this.Thing2D_RbSelection.rigidBody);
            if (this.Thing2D_RbSelection.rigidBody is OBB) this.RbMatchThing2D((OBB)this.Thing2D_RbSelection.rigidBody);
            if (this.Thing2D_RbSelection.rigidBody is ConvexPolygon) this.RbMatchThing2D((ConvexPolygon)this.Thing2D_RbSelection.rigidBody);
        }

        private void RbMatchThing2D(BoundingCircle boundingCircle)
        {
            List<Vector3> vertsList = VertexPositionTextureArray.GetVerticePositions(Thing2D.Thing2D_List[this.Thing2D_RbSelection.Thing2D_ID.Index].vertexPositionTextureArray);

            float radius = 0;

            for (int iCount = vertsList.Count - 1; iCount >= 0; --iCount)
            {
                float length = vertsList[iCount].Length();
                if (length > radius) radius = length;
            }

            this.Thing2D_RbSelection.rigidBody = new BoundingCircle(new Transform(this.Thing2D_RbSelection.rigidBody.transform.vPosition,
                                                                            this.Thing2D_RbSelection.rigidBody.transform.zRotation,
                                                                            new Vector3(1, 1, 1)),
                                                    new Motion(),
                                                    Vector3.Zero,
                                                    radius,
                                                    this.Thing2D_RbSelection.rigidBody.PhysicalPropertyID.Index,
                                                    this.Thing2D_RbSelection.rigidBody.Static);
        }

        private void RbMatchThing2D(OBB obb)
        {
            List<Vector3> vertsList = VertexPositionTextureArray.GetVerticePositions(Thing2D.Thing2D_List[this.Thing2D_RbSelection.Thing2D_ID.Index].vertexPositionTextureArray);

            float width = 0, height = 0;

            for (int iCount = vertsList.Count - 1; iCount >= 0; --iCount)
            {
                if (Math.Abs(vertsList[iCount].X) > width) width = Math.Abs(vertsList[iCount].X);
                if (Math.Abs(vertsList[iCount].Y) > height) height = Math.Abs(vertsList[iCount].Y);
            }

            this.Thing2D_RbSelection.rigidBody = new OBB(new Transform(this.Thing2D_RbSelection.rigidBody.transform.vPosition,
                                                                            this.Thing2D_RbSelection.rigidBody.transform.zRotation,
                                                                            new Vector3(1, 1, 1)),
                                                    new Motion(),
                                                    Vector3.Zero,
                                                    height * 2, width * 2,
                                                    this.Thing2D_RbSelection.rigidBody.PhysicalPropertyID.Index,
                                                    this.Thing2D_RbSelection.rigidBody.Static);
        }

        private void RbMatchThing2D(ConvexPolygon convexPolygon)
        {
            List<Vector3> vertsList = VertexPositionTextureArray.GetVerticePositions(Thing2D.Thing2D_List[this.Thing2D_RbSelection.Thing2D_ID.Index].vertexPositionTextureArray);

            VectorHelper.RemoveDuplicates(vertsList);

            VectorHelper.MakeClockwise(vertsList);

            this.Thing2D_RbSelection.rigidBody = new ConvexPolygon(new Transform(this.Thing2D_RbSelection.rigidBody.transform.vPosition,
                                                                            this.Thing2D_RbSelection.rigidBody.transform.zRotation,
                                                                            new Vector3(1, 1, 1)),
                                                    new Motion(),
                                                    Vector3.Zero,
                                                    VectorHelper.ToArray(vertsList),
                                                    this.Thing2D_RbSelection.rigidBody.PhysicalPropertyID.Index,
                                                    this.Thing2D_RbSelection.rigidBody.Static);
        }

        #endregion

        //This needs to be on every form. So the event cant link to it...
        //Stops stupid input from the user (ie two decimal points or a "-" in the middle of a load of numbers
        public void TextboxValidateFloat(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox) Validation.ValidateText(typeof(float), ((TextBox)sender).Text, e, ((TextBox)sender).SelectionStart, ((TextBox)sender).SelectedText);
            if (sender is ToolStripTextBox) Validation.ValidateText(typeof(float), ((ToolStripTextBox)sender).Text, e, ((ToolStripTextBox)sender).SelectionStart, ((ToolStripTextBox)sender).SelectedText);
        }




    }
}
