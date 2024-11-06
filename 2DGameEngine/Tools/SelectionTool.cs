
using Microsoft.Xna.Framework;
using _2d_Objects;
using _2DLevelCreator;
using CustomControls;


namespace Tools
{
    public class Selectionbox
    {
        public ConvexPolygon selectionBox;



        public void UpdateSelectionBox(GameInput gameInput)
        {
            if (!gameInput.MouseLeftIsDown && !gameInput.MouseLeftReleased)
            {
                this.selectionBox = new ConvexPolygon(new Transform(gameInput.mousePositionCurrentProjected, 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.001f, 0.001f, 0), new Vector3(0.001f, 0.001f, 0), new Vector3(0.001f, -0.001f, 0), new Vector3(-0.001f, -0.001f, 0) }, 0, false);
                this.selectionBox.Colour = new Color(111, 111, 111, 90);
                this.selectionBox.Update();
                return;
            }

            Vector3[] vectors = null;
            vectors = new Vector3[4];

            Vector3 topLeft = Vector3.Zero;
            Vector3 topRight = Vector3.Zero;
            Vector3 bottomRight = Vector3.Zero;
            Vector3 bottomLeft = Vector3.Zero;

            if (gameInput.mouseLeftDownLocation.X < gameInput.mousePositionCurrentProjected.X)
            {
                topLeft.X = gameInput.mouseLeftDownLocation.X;
                topRight.X = gameInput.mousePositionCurrentProjected.X;
                bottomLeft.X = gameInput.mouseLeftDownLocation.X;
                bottomRight.X = gameInput.mousePositionCurrentProjected.X;
            }
            else
            {
                topLeft.X = gameInput.mousePositionCurrentProjected.X;
                topRight.X = gameInput.mouseLeftDownLocation.X;
                bottomLeft.X = gameInput.mousePositionCurrentProjected.X;
                bottomRight.X = gameInput.mouseLeftDownLocation.X;
            }
            if (gameInput.mouseLeftDownLocation.Y > gameInput.mousePositionCurrentProjected.Y)
            {
                topLeft.Y = gameInput.mouseLeftDownLocation.Y;
                bottomLeft.Y = gameInput.mousePositionCurrentProjected.Y;
                topRight.Y = gameInput.mouseLeftDownLocation.Y;
                bottomRight.Y = gameInput.mousePositionCurrentProjected.Y;
            }
            else
            {
                topLeft.Y = gameInput.mousePositionCurrentProjected.Y;
                bottomLeft.Y = gameInput.mouseLeftDownLocation.Y;
                topRight.Y = gameInput.mousePositionCurrentProjected.Y;
                bottomRight.Y = gameInput.mouseLeftDownLocation.Y;
            }


            //(WARNING) Do not want to create edges with zero Length. Collision program cannot handle them properly
            if ((topLeft == topRight) || (topLeft == bottomRight) || (topLeft == bottomLeft) ||
                (topRight == bottomRight) || (topRight == bottomLeft) || (bottomRight == bottomLeft)) 
            {
                this.selectionBox = new ConvexPolygon(new Transform(gameInput.mousePositionCurrentProjected, 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, new Vector3[4] { new Vector3(-0.001f, 0.001f, 0), new Vector3(0.001f, 0.001f, 0), new Vector3(0.001f, -0.001f, 0), new Vector3(-0.001f, -0.001f, 0) }, 0, false);
                this.selectionBox.Colour = new Color(111, 111, 111, 90);
                this.selectionBox.Update();
                return; 
            }


            vectors[0] = topLeft;// +new Vector3(-0.1f, 0.1f, 0);
            vectors[1] = topRight;// +new Vector3(0.1f, 0.1f, 0);
            vectors[2] = bottomRight;// +new Vector3(0.1f, -0.1f, 0);
            vectors[3] = bottomLeft;// +new Vector3(-0.1f, -0.1f, 0);



            Vector3 position = (vectors[0] + vectors[1] + vectors[2] + vectors[3]) / 4;
            vectors[0] -= position;
            vectors[1] -= position;
            vectors[2] -= position;
            vectors[3] -= position;

            this.selectionBox = new ConvexPolygon(new Transform(position, 0, new Vector3(1, 1, 1)), new Motion(), Vector3.Zero, vectors, 0, false);
            this.selectionBox.Colour = new Color(111, 111, 111, 90);
            this.selectionBox.Update();
        }



        public void Draw(XnaWindow xnaWindow)
        {
            if (this.selectionBox != null && this.selectionBox.CalculateArea() >= 0.000005f)
            {
                this.selectionBox.Draw(xnaWindow);
            }
        }
    }





    public class SelectionTool
    {
        public Selectionbox SelectionBox { get; set; }

        public SelectionTool()
        {
            SelectionBox = new Selectionbox();
        }


        public virtual void UseSelectionTool(GameInput gameInput, ManipulationTool manipulationTool){}

        public virtual void FocusSelection(XnaWindow xnaWindow){ }

        public virtual void DrawSelection(XnaWindow xnaWindow) { }
    }
}
