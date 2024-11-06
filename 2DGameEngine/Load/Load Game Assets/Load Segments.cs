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
using _2DLevelCreator;
using Global_Data;

namespace LoadSpace
{
    public partial class Load
    {
        public static void Load_Segments()
        {

            string folder = @"Asset Data//Segments";
            string[] txtfiles = Directory.GetFiles(folder, "*.txt");

            for (int iCount = 0, iCountMax = txtfiles.Length; iCount < iCountMax; ++iCount)
            {
                new Segment(txtfiles[iCount], Globals.list_Segments);
            }
        }






    }
}
