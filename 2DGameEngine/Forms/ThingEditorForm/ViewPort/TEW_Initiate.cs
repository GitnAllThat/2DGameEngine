using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _2DLevelCreator;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class ThingEditorWindow : XnaWindow
    {
        public void GameInitiate()
        {
            DrawFont = Editor.Content.Load<SpriteFont>("ArialFont");
            effect = Editor.Content.Load<Effect>("MyHLSL_Old");

            gameInput = new GameInput(this);

            camera = new Camera(1.777f);
            this.camera.CameraPosition = new Vector3(0, 0, 15);
            this.camera.FocusOnPosition(new Vector3(0, 0, 0), this, 0);




            //tex2D_Ball = Editor.Content.Load<Texture2D>("Images\\Ball");
            //DrawFont = Editor.Content.Load<SpriteFont>("DrawFont");
            //Editor.RemoveDefaultComponents();   //Gets rid of the default FpsCounter and the default camera
        }


    }

}