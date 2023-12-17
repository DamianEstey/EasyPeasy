namespace EasyPeasyAlgos.Search;

/// <summary>
/// This is used for self-organizing arrays. It contains a value and a weight.
/// </summary>
public class Weightedf
{
    public float Value { get; set; }
    public float Weight { get; set; }

    public Weightedf(float value, float weight)
    {
        Value = value;
        Weight = weight;
    }
}