using EasyPeasyAbstractions.Interfacing;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace EasyPeasyAbstractions.Implementation
{
    /// <summary>
/// This object pool class should be thread safe as it uses ConcurrentBag<> to store the objects. 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> where T : IPoolable, new()
{
    private ConcurrentBag<T> _objects;
    private Func<T> _objectGenerator;
    private int _capacity;

    public ObjectPool(Func<T> objectGenerator = null, int capacity = 100)
    {
        _objects = new ConcurrentBag<T>();
        _objectGenerator = objectGenerator ?? (() => new T());
        _capacity = capacity;
        Initialize(_capacity / 2); // Initialize pool with half of the capacity
    }

    public T Get()
    {
        if (_objects.TryTake(out T item))
            return item;

        return _objectGenerator();
    }

    public void Return(T item)
    {
        if (_objects.Count < _capacity)
        {
            item.Reset();
            _objects.Add(item);
        }
    }
    /// <summary>
    /// The Initialize method is called in the constructor to pre-populate the pool with a certain number of objects.
    /// </summary>
    /// <param name="initialCount"></param>
    public void Initialize(int initialCount)
    {
        for (int i = 0; i < initialCount; i++)
        {
            _objects.Add(_objectGenerator());
        }
    }

    public int PoolCount()
    {
        return _objects.Count;
    }
}
}