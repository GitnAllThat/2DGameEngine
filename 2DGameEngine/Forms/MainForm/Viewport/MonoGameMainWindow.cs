using Microsoft.Xna.Framework;
using System.Windows.Forms;
using _2DLevelCreator;
using System.ComponentModel;
using System;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class MonoGameMainWindow : XnaWindow
    {
        
        




        [Browsable(true)]   //Makes the following property visible in the properties of the control on the [Design] form (where you can see what the form looks like)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]  //This adds the code to the file that generates the form
        public MainForm form { get; set; }




        #region Code to fill this.form with its correct form
        // This method is called when the parent changes
        //Basically i cant get the form[design] window to add this control using the constructor MonoGameMainWindow(Form form)
        //So it will set the form when it is placed on it.
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            // Set the form reference if the parent is a MainForm
            if (this.Parent is MainForm parentForm)
            {
                // Using the second constructor by calling Initialize with parent form
                this.form = parentForm;
            }
        }

        #endregion






        protected override void Initialize()
        {
            GameInitiate();
        }


        //Can only be a no parameter constructor. Winforms always uses this one.
        public MonoGameMainWindow()
        {

        }








        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }








        protected override void Update(GameTime gameTime)
        {


            // The base is responsoble for calling this.GameUpdate.
            // The frequency of the call to GameUpdate is based on the elapsed time and its target time ( target fps )
            // ie if the fps is low then the games logic may need to be updated multiple times to
            // sync it properly
            base.Update(gameTime); //The base updates the game based on time elapsed
        }



        protected override void Draw()
        {
            //Editor.GraphicsDevice.Clear(Color.White);


            GameDraw();






            /*  Debugging
            Editor.BeginCamera2D();


            Texture2D tex2D_Ball = Editor.Content.Load<Texture2D>("Images\\Ball");
            Editor.spriteBatch.Draw(tex2D_Ball, new Vector2(
                Editor.GraphicsDevice.Viewport.Width / 2 - tex2D_Ball.Width / 2,
                Editor.GraphicsDevice.Viewport.Height / 2 - tex2D_Ball.Height / 2),
                Color.White);


            //Debug Key Pressed
            Microsoft.Xna.Framework.Input.Keys[] keys = gameInput.keyboardStateCurrent.GetPressedKeys();
            for (int i = 0; i < keys.Length; ++i)
            {
                //Text
                Editor.spriteBatch.DrawString(DrawFont, $"the key: {keys[i]} is pressed", new Vector2(
                    Editor.GraphicsDevice.Viewport.Width,
                    Editor.GraphicsDevice.Viewport.Height + 10 * i),
                    Color.Yellow);
            }

            Editor.EndCamera2D();
            */
        }            
    }
}
