
using CustomControls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Things;


namespace _2DLevelCreator
{
    public class Background
    {
        public Transform Transform { get; set; }   //X & Y specify where the image starts. "Z" will be the depth to stack backgrounds infront of each other.
        public bool RepeatX { get; set; }       //Shall repeat X?
        public bool RepeatY { get; set; }       //Shall repeat y?
        public bool FollowCamera { get; set; }  //Permanantly attach Background to the camera.

        public int thing2DIndex { get; set; }
        Vector2[] meshTexCoords { get; set; }

        public Background(int imageIndex,Transform transform, bool repeatX, bool repeatY, bool followCamera, ContentManager Content)      //Constructor
        {
            this.thing2DIndex = imageIndex;
            this.meshTexCoords = new[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };

            this.Transform = transform;
            this.RepeatX = repeatX;
            this.RepeatY = repeatY;
            this.FollowCamera = followCamera;
        }

        public Background(Background background) // Copy Constructor
        {
            this.thing2DIndex = background.thing2DIndex;
            this.meshTexCoords = (Vector2[])background.meshTexCoords.Clone();

            this.Transform = new Transform(background.Transform);
            this.RepeatX = background.RepeatX;
            this.RepeatY = background.RepeatY;
            this.FollowCamera = background.FollowCamera;
        }


        /*
         What to do:
         
         Convert camera viewport to the depth of the image
         
         Either use the renderer to do all this or.
         Set up verts to fit the screen. ie if image spans 20% of screen, then program should detect the amount of verts \
         needed to fill the screen fully. ie in this case 12 verts to make a triangle fan. then just need to shift the image texture coords
         on camera movement.
         or 12 verts + 2 offscreen tiles for camera spanning. can just reposition the tiles.
         
         
         
         */

        public void ScaleToScreen(GraphicsDeviceManager graphics)
        {
            //this.Width = graphics.PreferredBackBufferWidth;
            //this.Height = graphics.PreferredBackBufferHeight;

            //NOTE : have to factor in depth so it is actually the screen size.
        }



        public void Draw(XnaWindow monoGameWindow)
        {

            Thing2D.Thing2D_List[this.thing2DIndex].Draw(monoGameWindow, this.Transform, Matrix.CreateRotationZ(this.Transform.zRotation));
    
            
        }
    }
}
