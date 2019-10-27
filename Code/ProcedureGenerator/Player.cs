namespace ProcedureGenerator
{
    internal class Player
    {
        public int x
        { get; private set; }

        public int y
        { get; private set; }

        public int ChunkX, ChunkY;

        public Player(int _x, int _y, int size)
        {
            x = NormaliseCoords(_x, size);
            y = NormaliseCoords(_y, size);
            ChunkX = identifyChunk(x);
            ChunkY = identifyChunk(y);
        }

        public static int identifyChunk(int coord)
        {
            if (coord >= 0 && coord / Controller.GameMap.chunksize == 0)
                return 0;
            else if (coord < 0 && coord / Controller.GameMap.chunksize == 0)
                return -1;
            else if (coord >= 0)
                return coord / 16;
            else
                return coord / 16 - 1;
        }

        public void ChangeCoords(int _x, int _y, int size)
        {
            x = NormaliseCoords(_x, size);
            y = NormaliseCoords(_y, size);
        }

        private static int NormaliseCoords(int coord, int size)
        {
            if (coord >= size)
                return (coord % size);
            if (coord < 0)
                return size + (coord % size);
            return coord;
        }

        public void SetRightChunks()
        {
            ChunkX = identifyChunk(x);
            ChunkY = identifyChunk(y);
        }
    }
}