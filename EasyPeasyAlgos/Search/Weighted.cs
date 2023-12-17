namespace EasyPeasyAlgos.Search;

/// <summary>
/// This is used for self-organizing arrays. It contains a value and a weight.
/// </summary>
public class Weighted
{
    public int Value { get; set; }
    public int Weight { get; set; }

    public Weighted(int value, int weight)
    {
        Value = value;
        Weight = weight;
    }
}
