
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

using _2d_Objects;
using _2DLevelCreator;
using Global_Data;
using Things;

namespace Tools
{
    public class DeleteTool
    {

        public static void DeleteSelection(SelectionToolObjects selectionTool, GameInput gameInput)
        {

            if (gameInput.keyboardStateCurrent.IsKeyDown(Keys.Delete) && !gameInput.keyboardStatePrevious.IsKeyDown(Keys.Delete))
            {
                List<Thing2D_Rb<RigidBody>> list = selectionTool.GetObjects();
                if (list.Count > 0)
                {
                    for (int iCount = list.Count - 1; iCount >= 0; --iCount)
                    {
                        for (int jCount = Globals.list_AllObjects.Count - 1; jCount >= 0; --jCount)
                        {
                            if (Globals.list_AllObjects[jCount] == list[iCount])
                            {
                                Globals.list_AllObjects.RemoveAt(jCount);
                            }
                        }
                        for (int jCount = Globals.list_BuildingBlocks.Count - 1; jCount >= 0; --jCount)
                        {
                            if (Globals.list_BuildingBlocks[jCount] == list[iCount])
                            {
                                Globals.list_BuildingBlocks.RemoveAt(jCount);
                            }
                        }
                        for (int jCount = Globals.list_GameObjects.Count - 1; jCount >= 0; --jCount)
                        {
                            if (Globals.list_GameObjects[jCount] == list[iCount])
                            {
                                Globals.list_GameObjects.RemoveAt(jCount);
                            }
                        }

                        UniqueIdentifier.RemoveUniqueIdentifier(list[iCount].ID.UniqueID);
                        list.RemoveAt(iCount);
                    }
                }
                Program.mainForm.FillList_GameObjects(Globals.list_AllObjects);
            }

        }
    }
}
