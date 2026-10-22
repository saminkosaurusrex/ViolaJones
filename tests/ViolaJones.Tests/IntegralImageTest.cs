using ViolaJones.Core.Imaging;

namespace ViolaJones.Tests;

public class IntegralImageTest
{
    [Fact]
    public void RectangleSum_ReturnsCorrectSum()
    {
        byte[,] pixels =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        var integralImg = new IntegralImage(pixels);
        Assert.Equal(28, integralImg.RectangleSum(1,1,2,2));
    }

    [Fact]
    public void RectangleSumPReturnsWholeSum()
    {
        byte[,] pixels =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        var integralImg = new IntegralImage(pixels);
        Assert.Equal(45, integralImg.RectangleSum(0, 0,3,3));
    }
}