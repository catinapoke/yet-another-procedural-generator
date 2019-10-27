using System.Drawing;

namespace ProcedureGenerator
{
    internal class CombinedMap
    {
        private HeightMap Height; //Высота
        private HeatMap Heat;    //Теплота
        private MoistureMap Moisture;//Влажность
        private ClimatMap Climat;
        public int size;
        public int chunksize;

        private enum Type
        {
            Null,           //Default
            DeepWater,      //0.2f;
            ShallowWater,   //0.4f;
            Sand,           //0.5f;
            Grass,          //0.7f;
            Forest,         //0.8f;
            Rock,           //0.9f;
            Snow            //1;
        }

        public CombinedMap(int _size, int _seed, int _chunksize)
        {
            size = _size;
            chunksize = _chunksize;
            Height = new HeightMap(_size, _seed, _chunksize);
            Heat = new HeatMap(_size, _seed + 1, _chunksize, ref Height);
            Moisture = new MoistureMap(_size, _seed + 2, _chunksize, ref Height);
            Climat = new ClimatMap(ref Height, ref Heat, ref Moisture, _size, _chunksize);
        }

        public void LoadPoint(int x, int y)
        {
            Height.LoadPos(x, y);
            Heat.LoadPos(x, y);
            Moisture.LoadPos(x, y);
            Climat.LoadPos(x, y);
        }

        public void LoadChunk(int ChunkX, int ChunkY)
        {
            for (int i = ChunkX * chunksize; i < (ChunkX + 1) * chunksize; i++)
                for (int j = ChunkY * chunksize; j < (ChunkY + 1) * chunksize; j++)
                    LoadPoint(i, j);
        }

        public Color GetColorInPos(int x, int y)
        {
            return Climat.GetColor(Climat.GetValueInPos(x, y), x, y);
        }

        public Bitmap CreateBitmap()
        {
            return Climat.GenerateBitmap();
        }
    }
}