using System.Drawing;

//using Microsoft.Xna.Framework;

public static class ToTexture2D
{
    static public byte color2;

    public static int Convert(int grad)
    {
        int temp = 2;
        for (int i = 2; i <= grad; i++)
            temp *= 2;
        return temp + 1;
    }

    public static Bitmap CreateBitmap(float?[,] Result, bool BaseColor)
    {
        int size = Result.GetUpperBound(0) + 1;
        System.Drawing.Bitmap checks = new System.Drawing.Bitmap(size, size);
        Color color;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                color = ChooseColor(Result[x, y], BaseColor);
                checks.SetPixel(x, y, color);
            }
        }
        return checks;
    }

    public static void PaintSquare(ref Bitmap Image, int x1, int y1, int x2, int y2, Color color)
    {
        int i;
        for (i = x1; i <= x2; i++)
        {
            PaintIfCan(ref Image, i, y1, color);
            PaintIfCan(ref Image, i, y2, color);
        }
        for (i = y1 + 1; i < y2; i++)
        {
            PaintIfCan(ref Image, x1, i, color);
            PaintIfCan(ref Image, x2, i, color);
        }
    }

    private static void PaintIfCan(ref Bitmap Img, int x, int y, Color color)
    {
        if (y < Img.Height && y > -1 && x < Img.Width && x > -1)
            Img.SetPixel(x, y, color);
    }

    public static Bitmap IncreaseScale(Bitmap Result, int scale)
    {
        if (scale <= 1)
            return Result;
        Bitmap IncreasedMap = new Bitmap(Result.Width * scale, Result.Height * scale);
        for (int i = 0; i < Result.Width; i++)
            for (int j = 0; j < Result.Height; j++)
            {
                for (int z = 0; z < scale; z++)
                    for (int k = 0; k < scale; k++)
                        IncreasedMap.SetPixel(i * scale + z, j * scale + k, Result.GetPixel(i, j));
            }
        return IncreasedMap;
    }

    private static float Min(float a, float b)
    {
        if (a > b)
            return b;
        else
            return a;
    }

    private static float Max(float a, float b)
    {
        if (a < b)
            return b;
        else
            return a;
    }

    /*
     * Colors of Map
     * DarkOcean = 0,
     * Ocean = 0.2f
     * Sand = 0.4f
     * Green = 0.5f
     * DarkGreen = 0.7f
     * Stone = 0.8f
     * Snow = 0.9f
     */

    public static Color ChooseColor(float? height, bool BaseColor)
    {
        if (BaseColor)
        {
            if (height == null)
                return Color.SteelBlue;
            int grey = (int)(255 * height);
            return Color.FromArgb(255, grey, grey, grey);
        }

        if (height == null)
            return Color.White;

        Color tempColor;
        if (height < 0.2f)
            tempColor = Color.FromArgb(255, 0, 0, 139);
        else if (height < 0.4f)
            tempColor = Color.FromArgb(255, 0, 0, 255);
        else if (height < 0.5f)
            tempColor = Color.FromArgb(255, 255, 255, 102);
        else if (height < 0.7f)
            tempColor = Color.FromArgb(255, 50, 205, 50);
        else if (height < 0.8f)
            tempColor = Color.FromArgb(255, 0, 100, 0);
        else if (height < 0.9f)
            tempColor = Color.FromArgb(255, 255, 255, 102);
        else
            tempColor = Color.FromArgb(255, 165, 242, 243);
        return tempColor;
    }
}