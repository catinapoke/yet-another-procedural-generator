public class Map
{
    public int size;
    public int chunksize;
    public int seed;
    public float?[,] map;
    public float roughness = 4f;

    private enum BlockType
    {
        Default
    }

    public Map(int _size, int _seed, int _chunksize, bool random = true, float value = 0.4f)
    {
        size = _size;
        seed = _seed;
        chunksize = _chunksize;
        map = new float?[size, size];
        NullMap();
        if (random)
        {
            map[0, 0] = randFromPair(0, 0, seed);
            map[size - 1, 0] = randFromPair(size - 1, 0, seed);
            map[size - 1, size - 1] = randFromPair(size - 1, size - 1, seed);
            map[0, size - 1] = randFromPair(0, size - 1, seed);
        }
        else
        {
            map[0, 0] = value;
            map[size - 1, 0] = value;
            map[size - 1, size - 1] = value;
            map[0, size - 1] = value;
        }
    }

    public float?[,] GetMiniMapHeight(int ChunkX, int ChunkY)
    {
        int SizeMap = 9;
        float?[,] Minimap = new float?[SizeMap * chunksize, SizeMap * chunksize];
        for (int i = 0; i < SizeMap * chunksize; i++)
            for (int j = 0; j < SizeMap * chunksize; j++)
            {
                Minimap[i, j] = map[NormaliseCoords(ChunkX * chunksize + i), NormaliseCoords(ChunkY * chunksize + j)];
            }
        return Minimap;
    }

    private void NullMap()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                map[i, j] = null;
    }

    public float randFromPair(int x, int y, int seed)
    {
        int xm7 = 0, xm13 = 0, xm1301081 = 0, ym8461 = 0, ym105467 = 0, ym105943 = 0;

        for (int i = 0; i < 80; i++)
        {
            xm7 = x % 7;
            xm13 = x % 13;
            xm1301081 = x % 1301081;
            ym8461 = y % 8461;
            ym105467 = y % 105467;
            ym105943 = y % 105943;
            y = x + seed;
            x += (xm7 + xm13 + xm1301081 + ym8461 + ym105467 + ym105943);
        }
        return (xm7 + xm13 + xm1301081 + ym8461 + ym105467 + ym105943) / 1520972.0f;
    }

    public float Min(float a, float b)
    {
        if (a > b)
            return b;
        else
            return a;
    }

    public float Max(float a, float b)
    {
        if (a < b)
            return b;
        else
            return a;
    }

    public float GetValueInPos(int x, int y)
    {
        int x2 = NormaliseCoords(x);
        int y2 = NormaliseCoords(y);
        if (map[x2, y2] == null)
        {
            int degree = 1;
            while (((x2 & degree) == 0) && ((y2 & degree) == 0))
                degree <<= 1;
            if (((x2 & degree) != 0) && ((y2 & degree) != 0))
                squareStep(x2, y2, degree);
            else
                diamondStep(x2, y2, degree);
        }
        return (float)map[x2, y2];
    }

    public void LoadPos(int x, int y)
    {
        int x2 = NormaliseCoords(x);
        int y2 = NormaliseCoords(y);
        if (map[x2, y2] == null)
        {
            int degree = 1;
            while (((x2 & degree) == 0) && ((y2 & degree) == 0))
                degree <<= 1;
            if (((x2 & degree) != 0) && ((y2 & degree) != 0))
                squareStep(x2, y2, degree);
            else
                diamondStep(x2, y2, degree);
        }
    }

    public int NormaliseCoords(int coord)
    {
        if (coord >= size)
            return (coord % size) + 1;
        if (coord < 0)
            return size + (coord % size) - 1;
        return coord;
    }

    private float Displace(float value, int blocksize, int x, int y)
    {
        float tempvalue = (float)(value + (randFromPair(x, y, seed) - 0.5f) * blocksize * 2 * roughness / size);
        tempvalue = Max(0.0f, Min(1.0f, tempvalue));
        return tempvalue;
    }

    private void squareStep(int x, int y, int blocksize)
    {
        map[x, y] = Displace((GetValueInPos(x - blocksize, y - blocksize) +
                                 GetValueInPos(x - blocksize, y + blocksize) +
                                 GetValueInPos(x + blocksize, y - blocksize) +
                                 GetValueInPos(x + blocksize, y + blocksize)) / 4, blocksize, x, y);
    }

    private void diamondStep(int x, int y, int blocksize)
    {
        map[x, y] = Displace((GetValueInPos(x - blocksize, y) +
                                  GetValueInPos(x + blocksize, y) +
                                  GetValueInPos(x, y - blocksize) +
                                  GetValueInPos(x, y + blocksize)) / 4, blocksize, x, y);
    }

    public void GenerateChunk(int ChunkX, int ChunkY)
    {
        for (int i = ChunkX * chunksize; i < (ChunkX + 1) * chunksize; i++)
            for (int j = ChunkY * chunksize; j < (ChunkY + 1) * chunksize; j++)
                LoadPos(i, j);
    }

    private BlockType GetBlockType()
    {
        return BlockType.Default;
    }
}