namespace LevelCreator.EditorForms
{
    partial class GameWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gameWindow = new CustomControls.GameWindow();
            SuspendLayout();
            // 
            // gameWindow
            // 
            gameWindow.form = null;
            gameWindow.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.HiDef;
            gameWindow.Location = new System.Drawing.Point(0, 0);
            gameWindow.MouseHoverUpdatesOnly = false;
            gameWindow.Name = "gameWindow";
            gameWindow.Size = new System.Drawing.Size(1044, 864);
            gameWindow.TabIndex = 0;
            gameWindow.Text = "gameWindow";
            // 
            // GameWindowForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1045, 865);
            Controls.Add(gameWindow);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "GameWindowForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Game Window";
            FormClosing += ClosingForm;
            Resize += ResizeForm;
            ResumeLayout(false);
        }

        public CustomControls.GameWindow gameWindow;

        #endregion






    }
}