using _2d_Objects;
using CommonWinFormsFunctions;
using Global_Data;
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

        #region Manipulation Radio Functions

        private void rdoMoveTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.MoveTool;
            this.manipulationTool.UpdateToolTransformations();
        }

        private void rdoRotateTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.RotateTool;
            this.manipulationTool.UpdateToolTransformations();
        }

        private void rdoScaleTool_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.ScaleTool;
            this.manipulationTool.UpdateToolTransformations();
        }

        private void rdoNone_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.currentTool = this.manipulationTool.NoTool;
            this.manipulationTool.UpdateToolTransformations();
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

        private void chkAsAGroup_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.TRANSFORMASGROUP = (((CheckBox)sender).Checked);
        }

        #endregion




        #region Gridsnap Textbox Functions


        private void txtGridSnapMove_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float val))
            {
                this.manipulationTool.GRIDSNAPMOVEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }
        private void txtGridSnapMove_Validated(object sender, EventArgs e)
        {
            //Resets the text(The tools value may be different from the current text e.g. if the text was less than the min snap value)
            ((TextBox)sender).Text = this.manipulationTool.GRIDSNAPMOVEVAL.ToString();
        }






        private void txtGridSnapRotate_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float val))
            {
                this.manipulationTool.GRIDSNAPROTATEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }
        private void txtGridSnapRotate_Validated(object sender, EventArgs e)
        {
            //Resets the text(The tools value may be different from the current text e.g. if the text was less than the min snap value)
            ((TextBox)sender).Text = this.manipulationTool.GRIDSNAPROTATEVAL.ToString();
        }





        private void txtGridSnapScale_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float val))
            {
                this.manipulationTool.GRIDSNAPSCALEVAL = Math.Max(val, this.manipulationTool.MINGRIDSNAP);
            }
        }
        private void txtGridSnapScale_Validated(object sender, EventArgs e)
        {
            //Resets the text(The tools value may be different from the current text e.g. if the text was less than the min snap value)
            ((TextBox)sender).Text = this.manipulationTool.GRIDSNAPSCALEVAL.ToString();
        }

        #endregion











    }
}
