using Microsoft.Xna.Framework;
using _2DLevelCreator;
using _2d_Objects;
using Global_Data;
using Microsoft.Xna.Framework.Input;
using Things;

namespace CustomControls
{
    //Monogame Reimplement: Change XnaWindow back to MonoGameMainWindow
    public partial class MonoGameMainWindow : XnaWindow
    {
        public void DebugMovement(GameInput gameInput)
        {
            

            //Holding down Space allows the collision system to run
            if (Keyboard.GetState()[Keys.Space].Equals(KeyState.Down))
            {
                Globals.MOVE = true;
                if (this.form.selectionTool.selectedObjects.Count > 0)
                    this.form.manipulationTool.UpdateTransformation(this.form.manipulationTool.CenterPivot(), 0);
            }
            else
            {
                Globals.MOVE = false;
            }


            //Runs the collision System one frame at atime
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.Enter) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.Enter))     
            {
                Globals.MOVE = true;
            }




            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.F1) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.F1))   //Draw WireFrame
            {
                Globals.DRAWWIREFRAME = (Globals.DRAWWIREFRAME) ? false : true;
            }
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.F3) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.F3))   //Draws a Grid
            {
                Globals.DRAWAXIS = (Globals.DRAWAXIS) ? false : true;
            }
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.P) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.P))     //Increase Solver Iterations
            {
                ++Globals.SOLVERITERATIONS;
            }
            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.O) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.O))     //Decrease Solver Iterations
            {
                --Globals.SOLVERITERATIONS;
            }







            #region Generate various objects at mouse position (Keys 0-5)

            //Creates new thing2D_Rb's at the mouse position
            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D0) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.D0))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[0], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].ScaleBy(new Vector3(2f, 2f, 1));
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }

            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D1) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.D1))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[Globals.randNum.Next(3, 6)], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].ScaleBy(new Vector3(2, 2, 1));
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }

            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D2) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.D2))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[1], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].ScaleBy(new Vector3(2, 2, 1));
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }

            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D3))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[Globals.randNum.Next(3, 6)], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].ScaleBy(new Vector3(Globals.randNum.Next(1, 5), Globals.randNum.Next(1, 5), 1));
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }

            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D4) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.D4))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[8], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }

            if (gameInput.isMouseOnScreen && gameInput.keyboardStateCurrent.IsKeyDown(Keys.D5) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.D5))
            {
                new Thing2D_Rb<RigidBody>(Globals.list_Blueprints[2], Globals.list_AllObjects);
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.transform.vPosition = gameInput.mousePositionCurrentProjected;
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].RescaleTo(new Vector3(2, 2, 1));
                Globals.list_AllObjects[Globals.list_AllObjects.Count - 1].rigidBody.Rebuild();
                Globals.list_BuildingBlocks.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]);
                this.form.FillList_GameObjects(Globals.list_AllObjects);
            }
            #endregion
        }
    }
}
