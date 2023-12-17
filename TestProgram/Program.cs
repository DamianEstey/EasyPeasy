using EasyPeasyAbstractions.Implementation;
using EasyPeasyAbstractions.Interfacing;

public class Counter : IPoolable
{
    public int CurrentCount { get; set; }

    public Counter()
    {
        CurrentCount = 0;
    }

    public void IncrementCount()
    {
        CurrentCount++;
    }

    public void Reset()
    {
        CurrentCount = 0;
    }
}

public class Program
{
    public static void Main()
    {
          // Create a new object pool of type Counter
        ObjectPool<Counter> counterPool = new ObjectPool<Counter>();

        // Get a Counter object from the pool
        Counter counter = counterPool.Get();

        // Increment the count
        counter.IncrementCount();

        // Return the Counter object to the pool
        counterPool.Return(counter);

        Console.WriteLine(counterPool.PoolCount()); // Counter count: 0
        // Return
    }
}
