namespace Sakura.Status;

public class Stat(string name, int value, int max)
{
    public string Name { get; } = name;

    public int Value { get; set; } = value;

    public int Max { get; set; } = max;

    public void Increase(int amount)
    {
        Value = Math.Min(Value + amount, Max);
    }

    public void Decrease(int amount)
    {
        Value = Math.Max(0, Value - amount);
    }

    public void Fill()
    {
        Value = Max;
    }
}