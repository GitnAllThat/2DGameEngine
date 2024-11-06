using System;
using System.Windows.Forms;
using Shapes;

namespace _2DLevelCreator
{
    public partial class ThingEditorForm
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

        private void txtGridSizeTex_TextChanged(object sender, EventArgs e)
        {
            gridTexCoords = new Grid((1f / float.Parse(this.txtGridSpaceTex.Text)), float.Parse(this.txtGridSizeTex.Text), 0, Microsoft.Xna.Framework.Color.Blue);
        }

        private void txtGridSpaceTex_TextChanged(object sender, EventArgs e)
        {
            gridTexCoords = new Grid((1f / float.Parse(this.txtGridSpaceTex.Text)), float.Parse(this.txtGridSizeTex.Text), 0, Microsoft.Xna.Framework.Color.Blue);
        }

        private void txtGridSizeThing2D_TextChanged(object sender, EventArgs e)
        {
            gridThing2D = new Grid((1f / float.Parse(this.txtGridSpaceThing2D.Text)), float.Parse(this.txtGridSizeThing2D.Text), 1, Microsoft.Xna.Framework.Color.Orange);
        }

        private void txtGridSpaceThing2D_TextChanged(object sender, EventArgs e)
        {
            gridThing2D = new Grid((1f / float.Parse(this.txtGridSpaceThing2D.Text)), float.Parse(this.txtGridSizeThing2D.Text), 1, Microsoft.Xna.Framework.Color.Orange);
        }

        #endregion



        private void chkAsAGroup_CheckedChanged(object sender, EventArgs e)
        {
            this.manipulationTool.TRANSFORMASGROUP = (((CheckBox)sender).Checked);
        }

        private void txtTransparency_TextChanged(object sender, EventArgs e)
        {
            this.Thing2DSelectionRenderView.Transparency = float.Parse(((TextBox)(sender)).Text);
        }





    }
}
