using ViolaJones.Core.Features;

namespace ViolaJones.Tests;

public class HaarGeneratorTest
{
    [Fact]
    public void GenerateHaarFeature_CorrectCount()
    {
        var generator = new HaarFeatureGenerator(4, 3);
        var features = generator.GetFeatures();
        Assert.Equal(24, features.Count);
    }
}