using System;
using System.IO;
using _2DLevelCreator;
using Things;

namespace LoadSpace
{
    public class MeasureSize<T>
    {
        private readonly Func<T> _generator;
        private const int NumberOfInstances = 10;
        private readonly T[] _memArray;

        public MeasureSize(Func<T> generator)
        {
            _generator = generator;
            _memArray = new T[NumberOfInstances];
        }

        public long GetByteSize()
        {
            //Make one to make sure it is jitted
            _generator();

            long oldSize = GC.GetTotalMemory(false);
            for (int i = 0; i < NumberOfInstances; i++)
            {
                _memArray[i] = _generator();
            }
            long newSize = GC.GetTotalMemory(false);
            return (newSize - oldSize) / NumberOfInstances;
        }
    }



    public partial class Load
    {
        public static void Load_Thing2Ds()
        {
            //First adds a default Thing2D which will be represented as a checker pattern.
            new Thing2D("T2D_Checker", new UniqueIdentifier_Reference(Material.list_Material[0].FindID(0)), new VertexPositionTextureArray(), Thing2D.Thing2D_List);


            string line;
            StreamReader sr = new StreamReader("Asset Data//02 Thing2Ds.txt");





            while ((line = sr.ReadLine()) != null)
            {
                if (!StringMalarkey.CheckForTags(line, new string[] { "UNIQUEID", "MATERIAL", "VERTS", "TEXCOORDS" })) continue;        //Check that the string contains the appropriate tags.

                new Thing2D(    StringMalarkey.ExtractString(line, "UNIQUEID"),
                                new UniqueIdentifier_Reference(Material.list_Material[0].FindID(Convert.ToInt32(StringMalarkey.ExtractString(line, "MATERIAL")))),
                                StringMalarkey.GetVertPosTexArrayFromString(line), 
                                Thing2D.Thing2D_List);
            }






            sr.Close();
        }
    }
}
