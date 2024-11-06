using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2d_Objects;
using Global_Data;


namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class MonoGameMainWindow : XnaWindow
    {
        public void GameDraw()
        {
            Editor.GraphicsDevice.Clear(Color.CornflowerBlue);

            Editor.GraphicsDevice.BlendState = BlendState.NonPremultiplied;    // Allows alpha





            if (Globals.DRAWBACKFACES)  //Turn on drawing backfaces
            {
                RasterizerState rasterizerState = new RasterizerState(); rasterizerState.CullMode = CullMode.None;
                Editor.GraphicsDevice.RasterizerState = rasterizerState;
            }

            if (Globals.DRAWWIREFRAME)   //Turn on Wireframe Mode
            {
                RasterizerState rasterizerState = new RasterizerState();
                rasterizerState.CullMode = CullMode.None;
                rasterizerState.FillMode = FillMode.WireFrame;
                Editor.GraphicsDevice.RasterizerState = rasterizerState;
            }



            Globals.background.Draw(this);



            if (Globals.DRAWAXIS) Globals.grid.Draw(this);

            if (Globals.DRAWTHINGS) for (int i = 0; i < Globals.list_AllObjects.Count; ++i) { Globals.list_AllObjects[i].Draw(this); }
            if (Globals.DRAWRIGIDBODY) for (int i = 0; i < Globals.list_AllObjects.Count; ++i) { Globals.list_AllObjects[i].rigidBody.Draw(this); }

            for (int i = 0; i < Globals.list_Segments.Count; ++i) { Globals.list_Segments[i].Draw(this); }
            for (int i = 0; i < Globals.list_Segments.Count; ++i) { Globals.list_Segments[i].DrawStartEnd(this); }






            this.form.manipulationTool.Draw(this);              //Draw manipulation tool

            Collision_Methods.DrawDebuggingTools(this);         //Draws any debugging tools

            this.form.selectionTool.DrawSelection(this);        //Draws selection bits

            this.form.selectionTool.SelectionBox.Draw(this);    //Draws Selectionbox





            
            //Draw Debugging text
            Editor.spriteBatch.Begin();

            float height = 10;
            Editor.spriteBatch.DrawString(this.DrawFont, "XnaWindow Has Focus? :" + this.Focused, new Vector2(305, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Released? :" + gameInput.MouseLeftReleased, new Vector2(305, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Pressed? :" + gameInput.MouseLeftPressed, new Vector2(305, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Down Location :" + gameInput.mouseLeftDownLocation, new Vector2(305, height += 20), Color.White);
            Editor.spriteBatch.DrawString(this.DrawFont, "Solver Iterations :" + Globals.SOLVERITERATIONS, new Vector2(305, height += 20), Color.White);

            Editor.spriteBatch.End();


            gameInput.mouseBC.Draw(this);   //Draws where the mouse should be.(Also this is the rigidbody that is used to collide with things to select them) 

        }



    }
}
