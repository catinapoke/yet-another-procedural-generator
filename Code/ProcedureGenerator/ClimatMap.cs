using System.Drawing;

namespace ProcedureGenerator
{
    internal class ClimatMap
    {
        private HeightMap Height;
        private HeatMap Heat;
        private MoistureMap Moisture;
        private int size;
        private int chunksize;
        private static Color Ice = Color.FromArgb(255, 165, 242, 243);
        private static Color Desert = Color.FromArgb(238, 218, 130);
        private static Color Savanna = Color.FromArgb(177, 209, 110);
        private static Color TropicalRainforest = Color.FromArgb(66, 123, 25);
        private static Color Tundra = Color.FromArgb(96, 131, 112);
        private static Color TemperateRainforest = Color.FromArgb(29, 73, 40);
        private static Color Grassland = Color.FromArgb(164, 225, 99);
        private static Color SeasonalForest = Color.FromArgb(73, 100, 35);
        private static Color BorealForest = Color.FromArgb(95, 115, 62);
        private static Color Woodland = Color.FromArgb(139, 175, 90);
        private static Color None = Color.White;
        public static Color DeepWater = Color.FromArgb(0, 0, 150);
        public static Color ShallowColor = Color.FromArgb(25, 25, 150);

        public enum BlockType
        {
            Desert,
            Savanna,
            TropicalRainforest,
            Grassland,
            Woodland,
            SeasonalForest,
            TemperateRainforest,
            BorealForest,
            Tundra,
            Ice,
            None
        }

        private void NoneMap()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Map[i, j] = BlockType.None;
        }

        private BlockType[,] BiomeTable = new BlockType[6, 6] {
        //COLDEST        //COLDER          //COLD                  //HOT                          //HOTTER                       //HOTTEST
        { BlockType.Ice, BlockType.Tundra, BlockType.Grassland,    BlockType.Desert,              BlockType.Desert,              BlockType.Desert },              //DRYEST
        { BlockType.Ice, BlockType.Tundra, BlockType.Grassland,    BlockType.Desert,              BlockType.Desert,              BlockType.Desert },              //DRYER
        { BlockType.Ice, BlockType.Tundra, BlockType.Woodland,     BlockType.Woodland,            BlockType.Savanna,             BlockType.Savanna },             //DRY
        { BlockType.Ice, BlockType.Tundra, BlockType.BorealForest, BlockType.Woodland,            BlockType.Savanna,             BlockType.Savanna },             //WET
        { BlockType.Ice, BlockType.Tundra, BlockType.BorealForest, BlockType.SeasonalForest,      BlockType.TropicalRainforest,  BlockType.TropicalRainforest },  //WETTER
        { BlockType.Ice, BlockType.Tundra, BlockType.BorealForest, BlockType.TemperateRainforest, BlockType.TropicalRainforest,  BlockType.TropicalRainforest }   //WETTEST
        };

        public BlockType GetBlockType(int x, int y)
        {
            return BiomeTable[(int)Moisture.GetBlockType(x, y), (int)Heat.GetBlockType(x, y)];
        }

        public Color GetColor(BlockType value, int x, int y)
        {
            if (Height.GetBlockType(x, y) == HeightMap.BlockType.DeepWater && Map[x, y] != BlockType.None)
                return ClimatMap.DeepWater;
            else if (Height.GetBlockType(x, y) == HeightMap.BlockType.ShallowWater && Map[x, y] != BlockType.None)
                return ClimatMap.ShallowColor;
            switch (value)
            {
                case BlockType.Ice:
                    return Ice;

                case BlockType.BorealForest:
                    return BorealForest;

                case BlockType.Desert:
                    return Desert;

                case BlockType.Grassland:
                    return Grassland;

                case BlockType.SeasonalForest:
                    return SeasonalForest;

                case BlockType.Tundra:
                    return Tundra;

                case BlockType.Savanna:
                    return Savanna;

                case BlockType.TemperateRainforest:
                    return TemperateRainforest;

                case BlockType.TropicalRainforest:
                    return TropicalRainforest;

                case BlockType.Woodland:
                    return Woodland;
            }
            return Color.White;
        }

        private BlockType[,] Map;

        public ClimatMap(ref HeightMap _height, ref HeatMap _heat, ref MoistureMap _moisture, int _size, int _chunksize)
        {
            Height = _height;
            Heat = _heat;
            Moisture = _moisture;
            size = _size;
            chunksize = _chunksize;
            Map = new BlockType[size, size];
            NoneMap();
        }

        public Bitmap GenerateBitmap()
        {
            System.Drawing.Bitmap checks = new System.Drawing.Bitmap(size, size);
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    checks.SetPixel(x, y, GetColor(Map[x, y], x, y));
                }
            }
            return checks;
        }

        public int NormaliseCoords(int coord)
        {
            if (coord >= size)
                return (coord % size) + 1;
            if (coord < 0)
                return size + (coord % size) - 1;
            return coord;
        }

        public BlockType GetValueInPos(int x, int y)
        {
            int x2 = NormaliseCoords(x);
            int y2 = NormaliseCoords(y);
            if (Map[x, y] == BlockType.None)
                Map[x2, y2] = GetBlockType(x2, y2);
            return Map[x2, y2];
        }

        public void LoadPos(int x, int y)
        {
            int x2 = NormaliseCoords(x);
            int y2 = NormaliseCoords(y);
            Map[x2, y2] = GetBlockType(x2, y2);
        }

        public void LoadChunk(int ChunkX, int ChunkY)
        {
            for (int i = ChunkX * chunksize; i < (ChunkX + 1) * chunksize; i++)
                for (int j = ChunkY * chunksize; j < (ChunkY + 1) * chunksize; j++)
                    LoadPos(i, j);
        }
    }
}