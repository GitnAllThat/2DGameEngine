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

namespace SaveSpace
{
    public partial class Save
    {
        public static void Save_Level(string path)
        {
            Save_Objects(path, "GameObjects.txt", Globals.list_GameObjects, 0);
            Save_Objects(path, "BuildingBlocks.txt", Globals.list_BuildingBlocks, 0);
        }
    }
}
