using System;
using System.Windows.Forms;
using System.Drawing;

namespace CustomControls
{
    public abstract class Expander : Panel
    {
        public Button btnCollapse = new Button();
        public bool _open = true;

        public abstract void ResizeCollapseButton(object sender, EventArgs e);

        public virtual void AddControl(Control ct)
        {
            if (this._open) this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
        }

        public void btnCollapse_Click(object sender, EventArgs e)
        {
            if (!_open)
                this.OpenExpander();
            else
                this.CloseExpander();


            this._open = !this._open;
        }

        public abstract void OpenExpander();
        public abstract void CloseExpander();


        public abstract void Initalise();
    }
}
