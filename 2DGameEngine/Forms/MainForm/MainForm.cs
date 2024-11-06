using _2d_Objects;
using CommonWinFormsFunctions;
using CustomControls;
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
        public RigidThingEditorForm rigidThingEditorForm;
        public ThingEditorForm thingEditorForm;
        public GameWindowForm gameWindowForm;
        public ManipulationToolObjects manipulationTool = new ManipulationToolObjects();
        public SelectionToolObjects selectionTool = new SelectionToolObjects();

        public MainForm()
        {
            InitializeComponent();


            //Part of the Focussing Code
            this.wireEnter(this.Controls);
            this.wireMouseDown(this.Controls);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.DoubleBuffered = true;
        }



        // I think i wrote this to prevent losing selected objects when clicking on a control on the form
        // eg if i have objects selected and then check a checkbox. it puts focus off the viewport so
        // it doesnt think it is making a selection in the game (and thus losing current selection)
        // NOT SURE. NEED TO TEST
        #region Focussing Code

        Control mParent;
        public bool isMouseOnForm = false;
        public string focusedControlName = "";

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

        public void wireEnter(Control.ControlCollection ctls)
        {
            // Hook Enter event for all controls
            foreach (Control ctl in ctls)
            {
                ctl.Enter += ctl_Enter;
                wireEnter(ctl.Controls);
            }
        }

        private void ctl_Enter(object sender, EventArgs e)
        {
            this.isMouseOnForm = true;

            // Find parent
            Control parent = (sender as Control).Parent;
            while (parent != null && !(parent is Control)) parent = parent.Parent;
            if (parent != mParent)
            {
                // Parent changed, do something.  Watch out for null
                //....
                mParent = parent as Control;
                this.focusedControlName = mParent.Name;
            }
        }

        #endregion



        #region  Window Resize/Maximise/Restore

        public void RecalcAspectRatio() //Can be called within monogameControl
        {
            MainForm_ResizeBegin(null, null);
            MainForm_Resize(null, null);
        }
        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            flpRightSidebar.Size = new Size(flpRightSidebar.Width, expRightSidebar.Height);
            flpLeftSidebar.Size = new Size(flpLeftSidebar.Width, expLeftSidebar.Height);

            monoGameMainWindow.Refresh();

            this.monoGameMainWindow.camera.SetupCamera((float)this.monoGameMainWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferWidth / (float)this.monoGameMainWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferHeight);
            this.monoGameMainWindow.camera.CameraPosition = this.monoGameMainWindow.camera.CalculateCameraCenter(this.monoGameMainWindow, oldDepth);

            monoGameMainWindow.Size = new Size(this.Width - 10, flpRightSidebar.Height);

            float aspectRatio = monoGameMainWindow.Editor.GraphicsDevice.Viewport.AspectRatio;
            this.lblAspectRatio.Text = aspectRatio.ToString();
            //

            //this.Invalidate(); // Marks the form for repaint
            //this.Update();     // Forces immediate repaint
        }

        private float oldDepth = 24;
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            oldDepth = this.monoGameMainWindow.camera.CameraPosition.Z;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            MainForm_Resize(sender, e);
        }


        //Handles the maximise and restore of the window.
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);//(m.WParam.ToInt32() & 0xFFF0) == 0xF030


            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                //MainForm_Resize(null, null);
                if ((m.WParam.ToInt32() & 0xFFF0) == 0xF030) // Maximize Window
                {
                    MainForm_ResizeEnd(null, null);
                }

                if ((m.WParam.ToInt32() & 0xFFF0) == 0xF120) // Restore Window
                {
                    MainForm_ResizeEnd(null, null);
                }
                //This should handle the event on any window. SC_RESTORE is 0xF120, and SC_MINIMIZE is 0XF020, if you need those constants, too.
            }

        }

        #endregion



        #region Handle Checking If Mouse Is In Screen Or Not

        private void monoGameMainWindow_MouseLeave(object sender, EventArgs e)
        {
            this.monoGameMainWindow.gameInput.isMouseOnScreen = false;
        }

        private void monoGameMainWindow_MouseEnter(object sender, EventArgs e)
        {
            this.monoGameMainWindow.gameInput.isMouseOnScreen = true;
        }

        private void monoGameMainWindow_Click(object sender, EventArgs e)
        {
            this.monoGameMainWindow.Focus();
            this.monoGameMainWindow.gameInput.isMouseOnScreen = true;
        }

        #endregion



        #region Fill Lists

        public void FillList_Constructs(List<Thing2D_Rb<RigidBody>> list)
        {
            ListBox listBox = (ListBox)this.Controls.Find("lstBlueprints", true).FirstOrDefault();
            listBox.Items.Clear();
            for (int i = 0; i < list.Count; ++i)
            {
                listBox.Items.Add(list[i].ID.UniqueID);
            }
        }
        public void FillList_GameObjects(List<Thing2D_Rb<RigidBody>> list)
        {
            ListBox listBox = (ListBox)this.Controls.Find("lstObjects", true).FirstOrDefault();
            listBox.Items.Clear();
            for (int i = 0; i < list.Count; ++i)
            {
                listBox.Items.Add(list[i].ID.UniqueID);
            }
        }

        #endregion



        #region Select From List

        private void lstBlueprints_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstBlueprints.IndexFromPoint(e.Location);
            SelectFromList(sender, index, Globals.list_Blueprints);
        }

        private void lstObjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstObjects.IndexFromPoint(e.Location);
            SelectFromList(sender, index, Globals.list_AllObjects);
        }



        private void SelectFromList(object sender, int index, List<Thing2D_Rb<RigidBody>> list)
        {
            if (index != ListBox.NoMatches)
            {
                string val = ((ListBox)(sender)).Items[index].ToString();
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].ID.UniqueID == val)
                    {
                        this.selectionTool.selectedObjects.Clear();
                        this.selectionTool.selectedObjects.Add(list[i]);
                        this.selectionTool.UpdateOtherThings();
                        break;
                    }
                }
            }
            //this.monoGameMainWindow.Focus();  //This causes the selected object to be deselected. presumably because the game window now detects a 
            //click in this location wich generates a selection box selecting nothing therefore deselecting the object
            //Maybe a fix is to create a temp block on the selection tool until reaching the end of gameupdate
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
