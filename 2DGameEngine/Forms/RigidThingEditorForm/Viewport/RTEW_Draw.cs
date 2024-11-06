using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;
using _2d_Objects;
using Global_Data;
using SaveSpace;
using Tools;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using Microsoft.Xna.Framework.Input;
using Things;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class RigidThingEditorWindow : XnaWindow
    {
        public void GameDraw()
        {
            //Globals.background.Draw(this);


            this.Editor.GraphicsDevice.Clear(new Microsoft.Xna.Framework.Color(60,60,60));

            this.Editor.GraphicsDevice.BlendState = BlendState.NonPremultiplied;    // Allows alpha


            this.form.grid.Draw(this);

            if (this.form.Thing2D_RbSelection != null) Thing2D.Thing2D_List[this.form.Thing2D_RbSelection.Thing2D_ID.Index].Draw(this, new Transform(Vector3.Zero, 0, this.form.Thing2D_RbSelection.Scale), Matrix.Identity);

            this.form.selectionTool.DrawSelection(this);

            this.form.manipulationTool.Draw(this);

            this.form.selectionTool.SelectionBox.Draw(this);

            //Game.DrawText(this.XnaWindow);






            gameInput.mouseBC.Draw(this);   //Good for Debugging where the game things the mouse is in Screen Coordinates





            /*
            Editor.spriteBatch.Begin();

            float height = 10;

            //Editor.spriteBatch.DrawString(this.DrawFont, "Is Mouse On Form? :" + this.isMouseOnForm, new Vector2(20, height += 20), Color.White);             //MonoGame Reimplement isMouseOnForm
            Editor.spriteBatch.DrawString(this.DrawFont, "XnaWindow Has Focus? :" + this.Focused, new Vector2(20, height += 20), Color.White);

            Editor.spriteBatch.DrawString(this.DrawFont, "Released? :" + gameInput.MouseLeftReleased, new Vector2(20, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Pressed? :" + gameInput.MouseLeftPressed, new Vector2(20, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Down Location :" + gameInput.mouseLeftDownLocation, new Vector2(20, height += 20), Color.White);

            Editor.spriteBatch.End();
            */
        }



    }
}
