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
using Things;
using _2d_Objects;
using Global_Data;
using _2DLevelCreator;

namespace LoadSpace
{
    public partial class Load
    {
        public static void Load_Blueprints()
        {

            #region Default Checker Object

            OBB obb = new OBB(new Transform(), new Motion(), Vector3.Zero, 1f, 1f, 0,false);
            new Thing2D_Rb<RigidBody>(new UniqueIdentifier_Reference(Thing2D.Thing2D_List[0].FindID(0)), obb, "Checker", Globals.list_Blueprints);

            #endregion



            string line;
            StreamReader sr = new StreamReader("Asset Data//03 Blueprints.txt");

            while ((line = sr.ReadLine()) != null)
            {
                if (line == "") continue;
                new Thing2D_Rb<RigidBody>(line, Globals.list_Blueprints);
            }
            sr.Close();
        }






    }
}
