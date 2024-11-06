using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using CommonWinFormsFunctions;
using Shapes;

namespace _2DLevelCreator
{
    public partial class RigidThingEditorForm : Form
    {
        #region Manipulation Radio Functions

        private void rdoMoveTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.MoveTool;
        }

        private void rdoRotateTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.RotateTool;
        }

        private void rdoScaleTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.ScaleTool;
        }

        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.NoTool;
        }

        #endregion


        #region Gridsnap Checkbox Functions

        private void chkGridSnapMove_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.GRIDSNAPMOVE = (((CheckBox)sender).Checked);
        }

        private void chkGridSnapRotate_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.GRIDSNAPROTATE = (((CheckBox)sender).Checked);
        }

        private void chkGridSnapScale_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.GRIDSNAPSCALE = (((CheckBox)sender).Checked);
        }

        #endregion


        #region Gridsnap Textbox Functions

        private void txtGridSnapMove_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(((TextBox)sender).Text, out val))
            {
                this.manipulationTool.GRIDSNAPMOVEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }

        private void txtGridSnapRotate_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(((TextBox)sender).Text, out val))
            {
                this.manipulationTool.GRIDSNAPROTATEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }

        private void txtGridSnapScale_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(((TextBox)sender).Text, out val))
            {
                this.manipulationTool.GRIDSNAPSCALEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }

        #endregion


        #region Grid Functions

        private void txtGridSize_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGridSize.Text == "") return;

            grid = new Grid((1f / float.Parse(this.txtGridSpacing.Text)), float.Parse(this.txtGridSize.Text), 1, Microsoft.Xna.Framework.Color.Orange);
        }
        private void txtGridSize_Validated(object sender, EventArgs e)
        {

        }


        private void txtGridSpacing_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGridSize.Text == "") return;

            grid = new Grid((1f / float.Parse(this.txtGridSpacing.Text)), float.Parse(this.txtGridSize.Text), 1, Microsoft.Xna.Framework.Color.Orange);
        }
        private void txtGridSpacing_Validated(object sender, EventArgs e)
        {

        }


        private void txtTransparency_TextChanged(object sender, EventArgs e)
        {
            //monogame reimplement : This was never implemented in old xna
            //this.Thing2DSelectionRenderView.Transparency = float.Parse(((TextBox)(sender)).Text);
        }
        private void txtTransparency_Validated(object sender, EventArgs e)
        {

        }


        #endregion

















        #region Radio Modes

        private void rdoRigidbodyMode_CheckedChanged(object sender, EventArgs e)
        {
            this.RIGIDBODYMODE = true;
            this.CENTROIDMODE = false;
        }

        private void rdoCentroidMode_CheckedChanged(object sender, EventArgs e)
        {
            this.RIGIDBODYMODE = false;
            this.CENTROIDMODE = true;
            rdoMoveTool_CheckedChanged(null, null);
            this.rdoMoveTool.Checked = true;

            if(this.Thing2D_RbSelection != null)
                this.manipulationTool.UpdateTransformation(this.Thing2D_RbSelection.rigidBody.CentroidRotated, 0);
            else
                this.manipulationTool.UpdateTransformation(Vector3.Zero, 0);
        }

        #endregion



        private void chkAsAGroup_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.TRANSFORMASGROUP = (((CheckBox)sender).Checked);
        }















    }
}
