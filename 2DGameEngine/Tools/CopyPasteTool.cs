using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using Global_Data;
using Things;

namespace Tools
{
    public class CopyPasteTool
    {
        public static List<Thing2D_Rb<RigidBody>> CopiedObjects = new List<Thing2D_Rb<RigidBody>>();


        public static void CopyObjects(SelectionToolObjects selectionTool, GameInput gameInput)
        {

            if ((gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) && (gameInput.keyboardStateCurrent.IsKeyDown(Keys.C) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.C)))
            {
                List<Thing2D_Rb<RigidBody>> list = selectionTool.GetObjects();
                if (list.Count > 0)
                {
                    CopyPasteTool.CopiedObjects.Clear();
                    for (int iCount = 0, iCountMax = list.Count; iCount < iCountMax; ++iCount)
                    {
                        CopyPasteTool.CopiedObjects.Add(list[iCount]);
                    }
                }
            }

        }



        public static void PasteObjects(GameInput gameInput, ManipulationTool manipulationTool, SelectionToolObjects selectionTool)
        {
            if (CopyPasteTool.CopiedObjects.Count > 0)
            {
                if (gameInput.isMouseOnScreen && (gameInput.keyboardStateCurrent.IsKeyDown(Keys.LeftControl)) && (gameInput.keyboardStateCurrent.IsKeyDown(Keys.V) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.V)))
                {
                    //First calculate a pivotpoint
                    Vector3 pivotPos = Vector3.Zero;
                    for (int iCount = 0, iCountMax = CopyPasteTool.CopiedObjects.Count; iCount < iCountMax; ++iCount)
                    {
                        pivotPos += CopyPasteTool.CopiedObjects[iCount].Position;
                    }
                    pivotPos /= CopyPasteTool.CopiedObjects.Count;
                    manipulationTool.UpdateTransformation(gameInput.mousePositionCurrentProjected, 0);

                    selectionTool.selectedObjects.Clear();
                    for (int iCount = 0, iCountMax = CopyPasteTool.CopiedObjects.Count; iCount < iCountMax; ++iCount)
                    {
                        Thing2D_Rb<RigidBody> newObject = new Thing2D_Rb<RigidBody>(CopyPasteTool.CopiedObjects[iCount], Globals.list_AllObjects);

                        newObject.Position = gameInput.mousePositionCurrentProjected + (CopyPasteTool.CopiedObjects[iCount].Position - pivotPos);
                        newObject.rigidBody.Update();

                        Globals.list_BuildingBlocks.Add(newObject);


                        Program.mainForm.FillList_GameObjects(Globals.list_AllObjects);

                        selectionTool.selectedObjects.Add(newObject);
                        selectionTool.UpdateOtherThings();
                    }
                }
            }
        }
    }
}
