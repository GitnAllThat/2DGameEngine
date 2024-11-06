using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CustomControls;
using Things;
using _2DLevelCreator;

namespace Game.UserInterface
{
    public class MoveControl
    {

        Thing2D Bar = new Thing2D("#UNIQUEID# T2D_UI_Bar #/UNIQUEID# #MATERIAL# 14 #/MATERIAL# #VERTS# -0.5, 0.5, 0.5, 0.5, -0.5, -0.5, -0.5, -0.5, 0.5, 0.5, 0.5, -0.5 #/VERTS# #TEXCOORDS# 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1 #/TEXCOORDS#", new List<Thing2D>());
        Thing2D Slider = new Thing2D("#UNIQUEID# T2D_UI_Sliver #/UNIQUEID# #MATERIAL# 15 #/MATERIAL# #VERTS# -0.5, 0.5, 0.5, 0.5, -0.5, -0.5, -0.5, -0.5, 0.5, 0.5, 0.5, -0.5 #/VERTS# #TEXCOORDS# 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1 #/TEXCOORDS#", new List<Thing2D>());




        //NOTE: Positions are in terms of screen space( ie x pos of 0.1 will be positioned at the tenth of the screen)
        // Scale isnt. Scale x and y should be the same.
        Transform BarTransformDefault { get; set; } //This will hold the positioning information relative to all screen
        Transform SliderTransformDefault { get; set; } //This will hold the positioning information relative to all screen

        //These transforms will be the ones relative the the viewport.
        Transform BarTransform { get; set; }        //This will hold the positioning information to this screen in particular
        Transform SliderTransform { get; set; }        //This will hold the positioning information to this screen in particular

        float barAllowedScreenPercent = 0.5f;
        float sliderAllowedScreenPercent = 0.05f;

        //Constructor
        public MoveControl(int viewportWidth, int viewportHeight)
        {
            this.BarTransformDefault = new Transform();
            this.BarTransform = new Transform();
            this.SliderTransformDefault = new Transform();
            this.SliderTransform = new Transform();

            this.BarTransformDefault.vPosition = new Vector3(0.0f, 0.9f, 0);
            this.BarTransformDefault.vScale = new Vector3(1.0f, 1.0f, 1);
            this.SliderTransformDefault.vPosition = new Vector3(0.0f, 0.9f, 0);
            this.SliderTransformDefault.vScale = new Vector3(0.1f, 0.1f, 1);
        }

        public void ReloadUi(Vector3 AspectRatioScale, XnaWindow xnaWindow)
        {
            // Scale image size if its current size is greater than its allowed screen percentage.
            // Get Image Width and Screen Width
            float imageWidth = Material.list_Material[Bar.MaterialID.Index].Texture2D.Bounds.Width;
            float screenWidth = xnaWindow.Width;
            float percentOfBackBuffer = screenWidth / xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferWidth;


            this.BarTransform.vScale = this.BarTransformDefault.vScale * percentOfBackBuffer;
            if (screenWidth * barAllowedScreenPercent < imageWidth * percentOfBackBuffer)
            {

                float scale = (screenWidth * barAllowedScreenPercent) / (imageWidth * percentOfBackBuffer);
                this.BarTransform.vScale *= scale;
            }

            //Now we want to check if it is bigger than its default width. In which case we will shrink it.
            if (screenWidth * barAllowedScreenPercent > imageWidth)
            {
                float scale = imageWidth / (screenWidth * barAllowedScreenPercent);
                this.BarTransform.vScale *= scale;
            }





  



            float window_x = (float)(xnaWindow.Width * this.BarTransformDefault.vPosition.X - (xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferWidth / 2));
            float norm_x = (float)(window_x) / (float)(xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferWidth / 2);
            float window_y = (float)((xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferHeight - xnaWindow.Height * this.BarTransformDefault.vPosition.Y) - (xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferHeight / 2));
            float norm_y = (float)(window_y) / (float)(xnaWindow.Editor.GraphicsDevice.PresentationParameters.BackBufferHeight / 2);

            this.BarTransform.vPosition = new Vector3(norm_x + (this.BarTransform.vScale.X / 2), norm_y + (this.BarTransform.vScale.Y / 20), 0);
        }


        



        #region Draw Functions
        public virtual void Draw(XnaWindow xnaWindow)
        {
            this.Bar.DrawScreenSpace(xnaWindow, this.BarTransform, Matrix.Identity);
            //this.Slider.DrawScreenSpace(xnaWindow, this.SliderTransform, Matrix.Identity);
        }
        #endregion
    }
}
 