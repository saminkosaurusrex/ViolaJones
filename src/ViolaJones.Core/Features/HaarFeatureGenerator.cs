using System.Collections.ObjectModel;
using ViolaJones.Core.Enums;

namespace ViolaJones.Core.Features;

public class HaarFeatureGenerator(int width, int height)
{
    public Collection<HaarFeature> GetFeatures()
    {
        var result = new Collection<HaarFeature>();
        for(var h = 1; h <= height; h++)
        {
            for (var w = 1; w <= width / 2; w++)
            {
                for (var y = 0; y + h <= height; y++)
                {
                    for (var x = 0; x + (2 * w) <= width; x++)
                    {
                        Rectangle rectangle1 = new Rectangle(x, y, w, h);
                        Rectangle rectangle2 = new Rectangle(x + w, y, w, h);
                        var recs = new List<Rectangle>();
                        recs.Add(rectangle1);
                        recs.Add(rectangle2);
                        HaarFeature haar = new HaarFeature(HaarFeatureType.TwoRectangleHorizontal,  recs);
                        result.Add(haar);
                    } 
                }
            }
        }
        return result;
    }
}