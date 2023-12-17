namespace EasyPeasyAlgos.Sort;

/// <summary>
/// This is a simple bubble sort algorithm that sorts an array of ints and floats.
/// </summary>
public class Bubble
{
    public static void Sort(int[] arr, int numThreads, SortOrder sortOrder)
    {
        if (numThreads > Environment.ProcessorCount)
        {
            numThreads = Environment.ProcessorCount;
        }

        int chunkSize = (int)(arr.Length / numThreads);

        Task[] tasks = new Task[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            int startIndex = i * chunkSize;
            int endIndex = i.Equals(numThreads - 1) ? arr.Length : (i + 1) * chunkSize;

            tasks[i] = Task.Run(() =>
            {
                BubbleSort(arr, startIndex, endIndex - 1, sortOrder);
            });
        }

        Task.WaitAll(tasks);
    }

    private static void BubbleSort(int[] arr, int low, int high, SortOrder sortOrder)
    {
        for (int i = low; i <= high; i++)
        {
            for (int j = low; j < high - i + low; j++)
            {
                if ((sortOrder == SortOrder.Ascending && arr[j] > arr[j + 1]) || (sortOrder == SortOrder.Descending && arr[j] < arr[j + 1]))
                {
                    // swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void Sortf(float[] arr, int numThreads, SortOrder sortOrder)
    {
        if (numThreads > Environment.ProcessorCount)
        {
            numThreads = Environment.ProcessorCount;
        }

        int chunkSize = (int)(arr.Length / numThreads);

        Task[] tasks = new Task[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            int startIndex = i * chunkSize;
            int endIndex = i.Equals(numThreads - 1) ? arr.Length : (i + 1) * chunkSize;

            tasks[i] = Task.Run(() =>
            {
                BubbleSortf(arr, startIndex, endIndex - 1, sortOrder);
            });
        }

        Task.WaitAll(tasks);
    }

    private static void BubbleSortf(float[] arr, int low, int high, SortOrder sortOrder)
    {
        for (int i = low; i <= high; i++)
        {
            for (int j = low; j < high - i + low; j++)
            {
                if ((sortOrder == SortOrder.Ascending && arr[j] > arr[j + 1]) || (sortOrder == SortOrder.Descending && arr[j] < arr[j + 1]))
                {
                    // swap arr[j] and arr[j+1]
                    float temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}