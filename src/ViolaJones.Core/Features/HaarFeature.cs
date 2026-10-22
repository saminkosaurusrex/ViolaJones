using ViolaJones.Core.Enums;
using ViolaJones.Core.Imaging;

namespace ViolaJones.Core.Features;

public class HaarFeature
{
    
    private readonly IReadOnlyList<Rectangle> _rectangles;
    private readonly HaarFeatureType _type;

    public HaarFeature(HaarFeatureType type, IReadOnlyList<Rectangle> recs)
    {
        if (recs == null)
        {
            throw new ArgumentNullException(nameof(recs));
        }
        if(!Enum.IsDefined(typeof(HaarFeatureType), type))
            throw new ArgumentOutOfRangeException(nameof(type));
        if (type.GetWeights().Length != recs.Count)
        {
            throw new ArgumentException("Different number of rectangles from neede rectangles");
        }
        _type = type;
        _rectangles = new List<Rectangle>(recs);
    }
    

    public long HaarCalculation(IntegralImage img)
    {
        var weights = _type.GetWeights();
        
        long result = 0;
        for (var i = 0; i < _rectangles.Count; i++)
        {
            result += weights[i] * img.RectangleSum(_rectangles[i].X, _rectangles[i].Y, _rectangles[i].Width, _rectangles[i].Height);
        }
        
        return result;
    }
}

