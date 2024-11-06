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
using _2d_Objects;
using Global_Data;
using Things;


namespace LoadSpace
{
    public static partial class Load
    {
        public static void Load_Objects(string path, string fileName, List<Thing2D_Rb<RigidBody>> list)
        {
            string line;
            StreamReader sr = new StreamReader(path + fileName);

            while ((line = sr.ReadLine()) != null)
            {
                if (line == "") continue;   //Skip this line if it is empty.

                new Thing2D_Rb<RigidBody>(line, Globals.list_AllObjects);
                list.Add(Globals.list_AllObjects[Globals.list_AllObjects.Count - 1]); //Also adds to GameObjects or BuildingBlocks
            }

            sr.Close();
        }


        public static int GetConstructIndex(int ID) //Search through all constructs to match the desired id. if not found then a default construct will be provided.
        {
            for (int i = 0, count = Globals.list_Blueprints.Count; i < count; ++i)
            {
                if (ID == Globals.list_Blueprints[i].ID.Index) return i;
            }
            return 0;
        }
    }
}
