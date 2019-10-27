namespace ProcedureGenerator
{
    internal class HeightMap : Map
    {
        private float DeepWater = 0.2f;
        private float ShallowWater = 0.4f;
        private float Sand = 0.5f;
        private float Grass = 0.7f;
        private float Forest = 0.8f;
        private float Rock = 0.9f;
        private float Snow = 1;

        public enum BlockType
        {
            DeepWater,      //0.2f
            ShallowWater,   //0.4f
            Sand,           //0.5f
            Grass,          //0.7f
            Forest,         //0.8f
            Rock,           //0.9f
            Snow            //1
        }

        public BlockType GetBlockType(int x, int y)
        {
            float heightValue = GetValueInPos(x, y);
            if (heightValue < DeepWater) return BlockType.DeepWater;
            else if (heightValue < ShallowWater) return BlockType.ShallowWater;
            else if (heightValue < Sand) return BlockType.Sand;
            else if (heightValue < Grass) return BlockType.Grass;
            else if (heightValue < Forest) return BlockType.Forest;
            else if (heightValue < Rock) return BlockType.Rock;
            else return BlockType.Snow;
        }

        public HeightMap(int _size, int _seed, int _chunksize) : base(_size, _seed, _chunksize)
        {
        }
    }
}