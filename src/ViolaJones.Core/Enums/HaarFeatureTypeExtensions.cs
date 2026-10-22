namespace ViolaJones.Core.Enums;


// !!DEV: only for symmetric rectangles, asymmetric rectangles must have different weights!! 

public static class HaarFeatureTypeExtensions
{
    public static int[] GetWeights(this HaarFeatureType type)
    {
        return type switch
        {
            HaarFeatureType.TwoRectangleHorizontal => [1, -1],
            HaarFeatureType.TwoRectangleVertical => [1, -1],
            HaarFeatureType.ThreeRectangleHorizontal => [1, -2, 1],
            HaarFeatureType.ThreeRectangleVertical => [1, -2, 1],
            HaarFeatureType.FourRectangleCheckerboard => [1, -1, -1, 1],
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}