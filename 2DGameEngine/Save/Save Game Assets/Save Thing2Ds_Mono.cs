using System.IO;

using Things;



namespace SaveSpace
{
    public partial class Save
    {

        public static void Save_Thing2Ds()
        {
            using (StreamWriter sw = new StreamWriter("Asset Data//02 Thing2Ds.txt"))
            {
                for (int iCount = 1, iCountMax = Thing2D.Thing2D_List.Count; iCount < iCountMax; ++iCount)
                {

                    sw.Write(" #UNIQUEID# " + Thing2D.Thing2D_List[iCount].ID.UniqueID + " #/UNIQUEID# ");
                    sw.Write(" #MATERIAL# " + Thing2D.Thing2D_List[iCount].MaterialID.Index + " #/MATERIAL# ");


                    sw.Write(" #VERTS# ");
                    for (int jCount = 0, jCountMax = Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray().Length; jCount < jCountMax; ++jCount)
                    { sw.Write(Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray()[jCount].Position.X + ", " + Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray()[jCount].Position.Y + ", "); }
                    sw.Write(" #/VERTS# ");


                    sw.Write(" #TEXCOORDS# ");
                    for (int jCount = 0, jCountMax = Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray().Length; jCount < jCountMax; ++jCount)
                    { sw.Write(Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray()[jCount].TextureCoordinate.X + ", " + Thing2D.Thing2D_List[iCount].vertexPositionTextureArray.GetVertexPositionTextureArray()[jCount].TextureCoordinate.Y + ", "); }
                    sw.Write(" #/TEXCOORDS# ");

                    
                    sw.WriteLine();
                }
            }
        }

    }
}
