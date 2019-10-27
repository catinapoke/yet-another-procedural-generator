namespace ProcedureGenerator
{
    internal class MoistureMap : Map
    {
        private HeightMap Height;
        private float DryerValue = 0.27f;
        private float DryValue = 0.4f;
        private float WetValue = 0.6f;
        private float WetterValue = 0.8f;
        private float WettestValue = 0.9f;

        public enum BlockType
        {
            Wettest = 0,
            Wetter = 1,
            Wet = 2,
            Dry = 3,
            Dryer = 4,
            Dryest = 5
        }

        public BlockType GetBlockType(int x, int y)
        {
            float moistureValue = GetValueInPos(x, y);
            if (moistureValue < DryerValue) return BlockType.Dryest;
            else if (moistureValue < DryValue) return BlockType.Dryer;
            else if (moistureValue < WetValue) return BlockType.Dry;
            else if (moistureValue < WetterValue) return BlockType.Wet;
            else if (moistureValue < WettestValue) return BlockType.Wetter;
            else return BlockType.Wettest;
        }

        public MoistureMap(int _size, int _seed, int _chunksize, ref HeightMap _height) : base(_size, _seed, _chunksize)
        {
            Height = _height;
        }

        private float CorrectForHeight(float value, int x, int y, HeightMap.BlockType type, float Height)
        {
            //type = GetHeightType(x, y);
            if (type == HeightMap.BlockType.DeepWater)
            {
                value += 8f * Height;// GetValueInPos(x, y);
            }
            else if (type == HeightMap.BlockType.ShallowWater)
            {
                value += 3f * Height;
            }
            else if (type == HeightMap.BlockType.Sand)
            {
                value = 1f * Height;
            }
            else if (type == HeightMap.BlockType.Grass)
            {
                value += 0.25f * Height;
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