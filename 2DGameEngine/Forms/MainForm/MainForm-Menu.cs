using Microsoft.Xna.Framework;
using Global_Data;
using SaveSpace;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Things;
using Tools;

namespace _2DLevelCreator
{
    public partial class MainForm : Form
    {

        #region New Scene Function
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

            Globals.list_AllObjects.Clear();
            Globals.list_BuildingBlocks.Clear();
            Globals.list_GameObjects.Clear();
            this.FillList_GameObjects(Globals.list_AllObjects);
        }
        #endregion


        #region Save Functions
        private void tsmSave_Click(object sender, EventArgs e)
        {
            Save.Save_Level(Globals.Path);
        }

        private void tsmSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            Globals.Path = saveFileDialog.FileName;

            StringMalarkey.RemoveTextFromString("GameObjects.txt", ref Globals.Path);
            StringMalarkey.RemoveTextFromString("BuildingBlocks.txt", ref Globals.Path);

            Globals.Path += "//";
            Save.Save_Level(Globals.Path);
        }

        private void tsmiSaveMaterials_Click(object sender, EventArgs e)
        {
            Save.Save_Game_Materials();
        }
        #endregion


        #region Load Functions

        private void tsmLoad_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            this.FillList_GameObjects(Globals.list_AllObjects);
        }


        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Globals.Path = openFileDialog.FileName;

            StringMalarkey.RemoveTextFromString("GameObjects.txt", ref Globals.Path);
            StringMalarkey.RemoveTextFromString("BuildingBlocks.txt", ref Globals.Path);

            Globals.Path += "//";
            LoadSpace.Load.Load_Level(Globals.Path);
        }

        #endregion

        private void tsmiSaveSegmentFile_Click(object sender, EventArgs e)
        {
            //Never got around to implementing
        }

    }
}
