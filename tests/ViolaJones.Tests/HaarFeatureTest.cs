using ViolaJones.Core;
using ViolaJones.Core.Enums;
using ViolaJones.Core.Features;
using ViolaJones.Core.Imaging;

namespace ViolaJones.Tests;

public class HaarFeatureTest
{
    [Fact]
    public void HaarFeatureCalculation_ReturnCorrectValue()
    {
        byte[,] pixels =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        var integralImg = new IntegralImage(pixels);

        var rec1 = new Rectangle(x: 0, y: 0, width:2, height: 2);
        var rec2 = new Rectangle(x: 2, y: 0, width:1, height: 2);

        List<Rectangle> recs = new List<Rectangle>();
        recs.Add(rec1);
        recs.Add(rec2);
        
        var haar = new HaarFeature( HaarFeatureType.TwoRectangleHorizontal, recs);
        var haarCal = haar.HaarCalculation(integralImg);
        
        Assert.Equal(3, haarCal);
    }
    
    [Fact]
    public void HaarFeatureCalculation_NullRecsErr()
    {
        byte[,] pixels =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        var integralImg = new IntegralImage(pixels);

        List<Rectangle> recs = new List<Rectangle>();
        
        Assert.Throws<ArgumentNullException>(() =>  new HaarFeature( HaarFeatureType.TwoRectangleHorizontal, null));
    }
    
    [Fact]
    public void HaarFeatureCalculation_DiffLengths()
    {
        byte[,] pixels =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        
        var integralImg = new IntegralImage(pixels);

        var rec1 = new Rectangle(x: 0, y: 0, width:2, height: 2);
        var rec2 = new Rectangle(x: 2, y: 0, width:1, height: 2);

        List<Rectangle> recs = new List<Rectangle>();
        recs.Add(rec1);
        
        Assert.Throws<ArgumentException>(() =>  new HaarFeature( HaarFeatureType.TwoRectangleHorizontal, recs));
    }
    
}