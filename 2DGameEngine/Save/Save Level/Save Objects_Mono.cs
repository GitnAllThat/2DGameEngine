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

namespace SaveSpace
{
    public partial class Save
    {
        public static void Save_Objects(string path, string fileName, List<Thing2D_Rb<RigidBody>> list, int indexStart)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            using (StreamWriter sw = new StreamWriter(path + fileName))
            {
                for (int i = indexStart, count = list.Count; i < count; ++i)
                {
                    list[i].Save(sw);
                    
                    sw.WriteLine();
                }
            }
        }
    }
}
