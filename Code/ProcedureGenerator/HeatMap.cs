namespace ProcedureGenerator
{
    internal class HeatMap : Map
    {
        private float ColdestValue = 0.05f;
        private float ColderValue = 0.18f;
        private float ColdValue = 0.4f;
        private float WarmValue = 0.6f;
        private float WarmerValue = 0.8f;

        private HeightMap Height;

        public enum BlockType
        {
            Coldest = 0,
            Colder = 1,
            Cold = 2,
            Warm = 3,
            Warmer = 4,
            Warmest = 5
        }

        public BlockType GetBlockType(int x, int y)
        {
            float heatValue = GetValueInPos(x, y);
            if (heatValue < ColdestValue)
                return BlockType.Coldest;
            else if (heatValue < ColderValue)
                return BlockType.Colder;
            else if (heatValue < ColdValue)
                return BlockType.Cold;
            else if (heatValue < WarmValue)
                return BlockType.Warm;
            else if (heatValue < WarmerValue)
                return BlockType.Warmer;
            else
                return BlockType.Warmest;
        }

        public HeatMap(int _size, int _seed, int _chunksize, ref HeightMap _height) : base(_size, _seed, _chunksize)
        {
            Height = _height;
        }

        private float CorrectForHeight(float value, int x, int y, HeightMap.BlockType type, float Height)
        {
            //type = GetHeightType(x, y);
            if (type == HeightMap.BlockType.Grass)
            {
                value -= 0.1f * Height;// GetValueInPos(x, y);
            }
            else if (type == HeightMap.BlockType.Forest)
            {
                value -= 0.2f * Height;
            }
            else if (type == HeightMap.BlockType.Rock)
            {
                value -= 0.3f * Height;
            }
            else if (type == HeightMap.BlockType.Snow)
            {
                value -= 0.4f * Height;
            }
            return value;
        }

        private float Displace(float value, int blocksize, int x, int y)
        {
            float tempvalue = (float)(value + (randFromPair(x, y, seed) - 0.5f) * blocksize * 2 * roughness / size);
            tempvalue = Max(0.0f, Min(1.0f, tempvalue));
            tempvalue = CorrectForHeight(tempvalue, x, y, Height.GetBlockType(x, y), Height.GetValueInPos(x, y));
            return tempvalue;
        }
    }
}