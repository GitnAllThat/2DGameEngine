using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControls;


using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelCreator.EditorForms
{
    public partial class GameWindowForm : Form
    {
        public GameWindowForm()
        {
            InitializeComponent();
        }

        #region Handle Form Resizing

        private void ResizeForm(object sender, EventArgs e)
        {

        }

        #endregion


        #region Handle Checking If Mouse Is In Screen Or Not

        private void XnaMainWindow_MouseLeave(object sender, EventArgs e)
        {
            //this.XnaWindow.gameInput.isMouseOnScreen = false;
        }

        private void XnaMainWindow_MouseEnter(object sender, EventArgs e)
        {
            //this.XnaWindow.gameInput.isMouseOnScreen = true;
        }

        private void XnaMainWindow_Click(object sender, EventArgs e)
        {
            //this.XnaWindow.Focus();
            //this.XnaWindow.gameInput.isMouseOnScreen = true;
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








    }
}
