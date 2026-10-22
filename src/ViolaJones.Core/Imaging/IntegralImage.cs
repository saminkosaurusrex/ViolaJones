namespace ViolaJones.Core.Imaging;

public sealed class IntegralImage
{
    private readonly long[,] _sum;
    
    public int Width { get; }
    public int Height { get; }

    public IntegralImage(byte[,] pixels)
    {
        Height =  pixels.GetLength(0);
        Width =  pixels.GetLength(1);
        
        _sum = new long[Height + 1, Width + 1];
        for (var i = 0; i < Height; i++)
        {
            long rowSum = 0;
            
            for (int j = 0; j < Width; j++)
            {
                rowSum += pixels[i, j];
                _sum[i + 1, j + 1] = _sum[i, j + 1] + rowSum; 
            }
        }
    }

    public long RectangleSum(int x, int y, int width, int height)
    {
        var x2 = x + width;
        var y2 = y + height;

        return _sum[y2, x2]
               - _sum[y, x2]
               - _sum[y2, x]
               + _sum[y, x];
    }
    
}