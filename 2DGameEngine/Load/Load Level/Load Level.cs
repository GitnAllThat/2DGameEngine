using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System.IO;


using Global_Data;



namespace LoadSpace
{
    public partial class Load
    {
        public static void Load_Level(string path)
        {
            Globals.list_AllObjects.Clear();
            Globals.list_GameObjects.Clear();
            Globals.list_BuildingBlocks.Clear();
            Globals.Path = path;

            Load_Objects(path, "//GameObjects.txt", Globals.list_GameObjects);
            Load_Objects(path, "//BuildingBlocks.txt", Globals.list_BuildingBlocks);
        }
    }
}
