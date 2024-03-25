using System.Collections;

namespace Sakura.Status;

[Serializable]
public class Stats : IEnumerable<Stat>
{
    private Dictionary<string, Stat> _stats = [];

    public Stat this[string name]
    {
        get => Find(name);
        set
        {
            var found = Find(name);
            if (found != null)
            {
                found.Value = value.Value;
                found.Max = value.Max;
            }
        }
    }

    public IEnumerator<Stat> GetEnumerator()
    {
        return _stats.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Stat stat)
    {
        _stats.Add(stat.Name, stat);
    }

    public void Add(string name, int value)
    {
        _stats.Add(name, new Stat(name, value, value));
    }

    public void Add(string name, int value, int max)
    {
        _stats.Add(name, new Stat(name, value, max));
    }

    private Stat Find(string name)
    {
        return _stats.GetValueOrDefault(name);
    }

    public void Fill()
    {
        foreach (var stat in _stats.Values) stat.Fill();
    }
}