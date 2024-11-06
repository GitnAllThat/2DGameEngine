using Microsoft.Xna.Framework;
using CustomControls;

namespace Game.UserInterface
{
    public class UserInterface
    {
        public MoveControl moveControl;



        
        //Constructor
        public UserInterface(XnaWindow xnaWindow)
        {
            this.moveControl = new MoveControl(xnaWindow.DisplayRectangle.Width, xnaWindow.DisplayRectangle.Height);

            this.ReloadUi(xnaWindow);
        }



        //This is Used for window resize (WARNING) Not used in actual game
        Vector3 Offset = Vector3.Zero;
        Vector3 AspectRatio = Vector3.Zero;
        public void ReloadUi(XnaWindow xnaWindow)
        {
            
            if (xnaWindow.Width > xnaWindow.Height)
            { AspectRatio = new Vector3(1, (float)xnaWindow.Width / (float)xnaWindow.Height, 1); }
            else
            { AspectRatio = new Vector3((float)xnaWindow.Width / (float)xnaWindow.Height, 1, 1); }

            AspectRatio.Normalize();

            this.moveControl.ReloadUi(AspectRatio, xnaWindow);
        }




        #region Draw Functions
        public virtual void Draw(XnaWindow xnaWindow)
        {
            this.moveControl.Draw(xnaWindow);
        }
        #endregion
    }
}
 