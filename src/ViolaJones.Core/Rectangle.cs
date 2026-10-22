namespace ViolaJones.Core;

public struct Rectangle
{
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    
    public Rectangle(int x, int y, int width, int height)
    {
        if (x < 0 || y < 0 || width <= 0 || height <= 0)
        {
            throw new ArgumentOutOfRangeException($"Unavlid params: {x}, {y}, {width}, {height}");
        }
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}