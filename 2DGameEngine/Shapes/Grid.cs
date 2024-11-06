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
using CustomControls;

namespace Shapes
{
    public class Grid
    {
        Line[] gridLines;


        public Grid(float gridLinesCount, float size, float min, Color axisColor)
        {
            gridLines = CreateGrid(gridLinesCount, size, min, axisColor);
        }


        public void Draw(XnaWindow monoGameWindow)
        {
            for (int iCount = 0, iCountMax = this.gridLines.Length; iCount < iCountMax; ++iCount) 
            {
                gridLines[iCount].Draw(monoGameWindow); 
            }
        }

        public static Line[] CreateGrid(float gridLinesCount, float size, float min, Color axisColor)
        {
            if (gridLinesCount <= 0) gridLinesCount = 1;
            if (gridLinesCount > 100) gridLinesCount = 100;
            if (size <= 0) size = 1;


            float gridSpacing = (1f / gridLinesCount);

            Line[] grid = new Line[(int)(gridLinesCount * 4 * size) + 8];



            float spacingCount = gridSpacing;
            for (int iCount = 0, iCountMax = (int)(gridLinesCount * 2 * size) - 1; iCount < iCountMax; ++iCount)
            {
                grid[iCount] = new Line(new Vector3(-size, -size + spacingCount, 0), new Vector3(size, -size + spacingCount, 0), Color.DarkGray, 1);
                spacingCount += gridSpacing;
            }


            spacingCount = gridSpacing;
            for (int iCount = (int)(gridLinesCount * 2 * size) - 1, iCountMax = (int)(gridLinesCount * 4 * size) - 2; iCount < iCountMax; ++iCount)
            {
                grid[iCount] = new Line(new Vector3(-size + spacingCount, -size, 0), new Vector3(-size + spacingCount, size, 0), Color.DarkGray, 1);
                spacingCount += gridSpacing;
            }


            grid[(int)(gridLinesCount * 4 * size) - 2] = new Line(new Vector3(-size, size, 0), new Vector3(size, size, 0), new Color(90, 90, 90), 1);
            grid[(int)(gridLinesCount * 4 * size) - 1] = new Line(new Vector3(size, size, 0), new Vector3(size, -size, 0), new Color(90, 90, 90), 1);
            grid[(int)(gridLinesCount * 4 * size)] = new Line(new Vector3(size, -size, 0), new Vector3(-size, -size, 0), new Color(90, 90, 90), 1);
            grid[(int)(gridLinesCount * 4 * size) + 1] = new Line(new Vector3(-size, -size, 0), new Vector3(-size, size, 0), new Color(90, 90, 90), 1);
            grid[(int)(gridLinesCount * 4 * size) + 2] = new Line(new Vector3(-size, 0, 0), new Vector3(size, 0, 0), axisColor, 1);
            grid[(int)(gridLinesCount * 4 * size) + 3] = new Line(new Vector3(0, -size, 0), new Vector3(0, size, 0), axisColor, 1);
            grid[(int)(gridLinesCount * 4 * size) + 4] = new Line(new Vector3(-min, min, 0), new Vector3(min, min, 0), Color.Orange, 1);
            grid[(int)(gridLinesCount * 4 * size) + 5] = new Line(new Vector3(min, min, 0), new Vector3(min, -min, 0), Color.Orange, 1);
            grid[(int)(gridLinesCount * 4 * size) + 6] = new Line(new Vector3(min, -min, 0), new Vector3(-min, -min, 0), Color.Orange, 1);
            grid[(int)(gridLinesCount * 4 * size) + 7] = new Line(new Vector3(-min, -min, 0), new Vector3(-min, min, 0), Color.Orange, 1);

            return grid;
        }
    }
}
