using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.NET.Controls;
using Color = Microsoft.Xna.Framework.Color;
using System.Windows.Forms;
using _2DLevelCreator;
using Global_Data;
using System;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public class XnaWindow : MonoGameControl        //Nuget : MonoGame.Forms.DX     https://github.com/BlizzCrafter/MonoGame.Forms
    {
        public SpriteFont DrawFont;
        public Effect effect;
        public Camera camera;
        public GameInput gameInput;

        protected override void Initialize()
        {
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }





        TimeSpan accumulatedTime = TimeSpan.Zero;
        TimeSpan TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0); // 60 updates per second
        TimeSpan MaxElapsedTime = TimeSpan.FromSeconds(0.5); // Maximum allowable time for one frame

        protected override void Update(GameTime gameTime)
        {
            TimeSpan elapsedTime = gameTime.ElapsedGameTime;

            // Ensure no frame gets too much time
            if (elapsedTime > MaxElapsedTime)
            {
                elapsedTime = MaxElapsedTime;
            }

            accumulatedTime += elapsedTime;

            // Run update logic in fixed time steps
            while (accumulatedTime >= TargetElapsedTime)
            {
                // Update the game logic here
                Globals.timeDifference = (float)TargetElapsedTime.TotalSeconds;

                accumulatedTime -= TargetElapsedTime;
                GameUpdate();
            }
        }

        public virtual void GameUpdate()
        {

        }




        protected override void Draw()
        {
        }
    }
}
