using System;
using System.Drawing;

namespace CustomControls
{
    public class ExpanderDown : Expander
    {
        public ExpanderDown()
        {
            this.SizeChanged += new System.EventHandler(this.ResizeCollapseButton); 
            this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.Initalise();
        }

        public override void ResizeCollapseButton(object sender, EventArgs e)
        {
            this.btnCollapse.Size = new System.Drawing.Size(this.ClientSize.Width, 22);
        }



        public override void OpenExpander()
        {
            int finalY = this.btnCollapse.Height;

            for (int iCount = 1, iCountMax = this.Controls.Count; iCount < iCountMax; ++iCount)
            {
                int sizeY = this.Controls[iCount].Location.Y + this.Controls[iCount].Height;
                if (sizeY > finalY) finalY = sizeY;
            }

            this.ClientSize = new Size(this.ClientSize.Width, finalY + 3);
            this.btnCollapse.Text = "▲ " + this.Name + " ▲";
        }


        public override void CloseExpander()
        {
            this.ClientSize = new Size(this.ClientSize.Width, 22);
            this.btnCollapse.Text = "▼ " + this.Name + " ▼";
        }





        public override void Initalise()
        {
            this.TabIndex = 0;
            // 
            // btnCollapse
            // 
            this.btnCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            this.btnCollapse.Font = new Font("Arial", 8);
            this.btnCollapse.Text = "▲ " + this.Name + " ▲";
            this.btnCollapse.Size = new System.Drawing.Size(this.btnCollapse.Size.Width, 22);
            this.Controls.Add(this.btnCollapse);
        }
    }
}
