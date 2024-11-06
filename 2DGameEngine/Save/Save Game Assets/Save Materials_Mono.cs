using _2DLevelCreator;


using System.IO;


namespace SaveSpace
{
    public partial class Save
    {
        public static void Save_Game_Materials()
        {
            using (StreamWriter sw = new StreamWriter("Asset Data//01 Materials.txt"))
            {
                for (int i = 1, count = Material.list_Material.Count; i < count; ++i)
                {
                    sw.Write(" #PATH# " +   Material.list_Material[i].Location  + " #/PATH# ");
                    sw.Write(" #NAME# " +   Material.list_Material[i].ID.UniqueID  + " #/NAME# ");
                    sw.Write(" #TYPE# " +   Material.list_Material[i].Type      + " #/TYPE# ");
                    sw.WriteLine();
                }
            }
        }

    }
}
