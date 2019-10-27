using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProcedureGenerator
{
    internal class Controller
    {
        static public Player player;
        private static int size, seed, chunksize = 16;
        public static bool MiniMapMode;
        public static CombinedMap GameMap;
        private static Bitmap Map;
        public static Bitmap ControlImage;

        public static void StartWork(int _x, int _y, int _size, int _seed, bool _minimap)
        {
            size = _size;
            seed = _seed;
            MiniMapMode = _minimap;
            GameMap = new CombinedMap(size, seed, chunksize);
            player = new Player(_x, _y, size);
            GameMap.LoadChunk(player.ChunkX, player.ChunkY);
            Map = GameMap.CreateBitmap();
            Map.SetPixel(player.x, player.y, Color.FromArgb(255, 255, 0, 0));
            PaintChunk(ref Map, player.ChunkX, player.ChunkY);
            if (MiniMapMode)
            {
                ControlImage = ToTexture2D.IncreaseScale(MakeMiniMap(Map, player.ChunkX, player.ChunkY), 3);
            }
            else
                ControlImage = Map;
        }

        public static void ChangedMode()
        {
            if (MiniMapMode)
            {
                ControlImage = ToTexture2D.IncreaseScale(MakeMiniMap(Map, player.ChunkX, player.ChunkY), 3);
            }
            else
                ControlImage = Map;
        }

        public static bool isNewMap(int _seed, int _size)
        {
            return !(seed == _seed && size == _size);
        }

        public static void LoadFullMap()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    GameMap.LoadPoint(i, j);
                }
            Map = GameMap.CreateBitmap();
            Map.Save(String.Format("{0}.png", seed), ImageFormat.Png);
            Map.SetPixel(player.x, player.y, Color.FromArgb(255, 255, 0, 0));
            PaintChunk(ref Map, player.ChunkX, player.ChunkY);
            if (MiniMapMode)
            {
                ControlImage = ToTexture2D.IncreaseScale(MakeMiniMap(Map, player.ChunkX, player.ChunkY), 3);
            }
            else
                ControlImage = Map;
        }

        public static void PlayerMoved(int SomeX, int SomeY, bool tp)
        {
            int OldX = player.x, OldY = player.y, OldChunkX = player.ChunkX, OldChunkY = player.ChunkY;

            if (tp)
            {
                player.ChangeCoords(SomeX, SomeY, size);
            }
            else
            {
                player.ChangeCoords(player.x + SomeX, player.y + SomeY, size);
            }

            player.SetRightChunks();

            if (OldChunkX == player.ChunkX && OldChunkY == player.ChunkY)
            {
                Map.SetPixel(OldX, OldY, GameMap.GetColorInPos(OldX, OldY));
                Map.SetPixel(player.x, player.y, Color.FromArgb(255, 255, 0, 0));
                if (MiniMapMode)
                {
                    ControlImage = ToTexture2D.IncreaseScale(MakeMiniMap(Map, player.ChunkX, player.ChunkY), 3);
                }
                else
                    ControlImage = Map;
            }
            else
            {
                GameMap.LoadChunk(player.ChunkX, player.ChunkY);
                Map = GameMap.CreateBitmap();
                Map.SetPixel(player.x, player.y, Color.FromArgb(255, 255, 0, 0));
                PaintChunk(ref Map, player.ChunkX, player.ChunkY);
                if (MiniMapMode)
                {
                    ControlImage = ToTexture2D.IncreaseScale(MakeMiniMap(Map, player.ChunkX, player.ChunkY), 3);
                }
                else
                    ControlImage = Map;
            }
        }

        private static void PaintChunk(ref Bitmap Img, int ChunkX, int ChunkY)
        {
            ToTexture2D.PaintSquare(ref Img, ChunkX * chunksize - 1, ChunkY * chunksize - 1, (ChunkX + 1) * chunksize, (ChunkY + 1) * chunksize, Color.Red);
        }

        public static Bitmap MakeMiniMap(Bitmap Img, int ChunkX, int ChunkY)
        {
            int SizeMap = 11;
            Bitmap MiniMap = new Bitmap(SizeMap * chunksize, SizeMap * chunksize);
            for (int i = 0; i < SizeMap * chunksize; i++)
                for (int j = 0; j < SizeMap * chunksize; j++)
                {
                    MiniMap.SetPixel(i, j, Img.GetPixel(NormaliseCoords((ChunkX - SizeMap / 2) * chunksize + i, size), NormaliseCoords((ChunkY - SizeMap / 2) * chunksize + j, size)));
                }
            return MiniMap;
        }

        private static int NormaliseCoords(int coord, int size)
        {
            if (coord >= size)
                return (coord % size);
            if (coord < 0)
                return size + (coord % size);
            return coord;
        }
    }
}