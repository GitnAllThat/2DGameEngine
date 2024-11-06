using System;
using System.Drawing;

namespace CustomControls
{
    public class ExpanderRight : Expander
    {


        public ExpanderRight()
        {
            this.SizeChanged += new System.EventHandler(this.ResizeCollapseButton); 
            this.ClientSize = new Size(this.ClientSize.Width,this.ClientSize.Height);
            this.Initalise();
        }

        public override void ResizeCollapseButton(object sender, EventArgs e)
        {
            this.btnCollapse.Size = new System.Drawing.Size(15, this.ClientSize.Height);
            this.btnCollapse.Location = new System.Drawing.Point(this.ClientSize.Width - this.btnCollapse.Width, 0);
        }




        public override void OpenExpander()
        {
            int finalX = this.btnCollapse.Width;

            for (int iCount = 1, iCountMax = this.Controls.Count; iCount < iCountMax; ++iCount)
            {
                int sizeX = this.Controls[iCount].Location.X + this.Controls[iCount].Width;
                if (sizeX > finalX) finalX = sizeX;
            }

            this.ClientSize = new Size(finalX + this.btnCollapse.Width, this.ClientSize.Height);
            this.btnCollapse.Text = "3";
        }


        public override void CloseExpander()
        {
            this.ClientSize = new Size(this.btnCollapse.Width, this.ClientSize.Height);
            this.btnCollapse.Text = "4";
        }








        public override void Initalise()
        {
            this.TabIndex = 0;
            // 
            // btnCollapse
            // 
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            this.btnCollapse.Font = new Font("Marlett", 10);
            this.btnCollapse.Text = "3";
            this.Controls.Add(this.btnCollapse);
        }
    }
}
