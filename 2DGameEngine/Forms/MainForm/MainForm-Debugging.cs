using _2d_Objects;
using Global_Data;
using System;
using System.Windows.Forms;


namespace _2DLevelCreator
{
    public partial class MainForm : Form
    {
        private void chkShowAABBsNS_CheckedChanged(object sender, EventArgs e)
        {
            Globals.DRAWSTATICAABB = (((CheckBox)sender).Checked);
            this.monoGameMainWindow.Focus();
        }

        private void chkShowAABBsS_CheckedChanged(object sender, EventArgs e)
        {
            Globals.DRAWAABB = (((CheckBox)sender).Checked);
            this.monoGameMainWindow.Focus();
        }

        private void chkShowRigidbodies_CheckedChanged(object sender, EventArgs e)
        {
            Globals.DRAWRIGIDBODY = (((CheckBox)sender).Checked);
            this.monoGameMainWindow.Focus();
        }

        private void chkShowThings_CheckedChanged(object sender, EventArgs e)
        {
            Globals.DRAWTHINGS = (((CheckBox)sender).Checked);
            this.monoGameMainWindow.Focus();
        }

        private void chkSegmentMode_CheckedChanged(object sender, EventArgs e)
        {
            Globals.DRAWSEGMENTS = (((CheckBox)sender).Checked);
            this.monoGameMainWindow.Focus();
        }
    }
}
