
namespace EasyPeasyAlgos.Sort;
/// <summary>
/// This is a simple quick sort algorithm that sorts an array of ints and floats.
/// </summary>
public class Quick
    {
        public static void Sort(int[] arr, SortOrder sortOrder, int threadcount)
        {
            int numThreads = threadcount;

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
                    QuickSort(arr, startIndex, endIndex - 1, sortOrder);
                });
            }

            Task.WaitAll(tasks);
        }

        private static void QuickSort(int[] arr, int low, int high, SortOrder sortOrder)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high, sortOrder);

                QuickSort(arr, low, pi - 1, sortOrder);
                QuickSort(arr, pi + 1, high, sortOrder);
            }
        }

        private static int Partition(int[] arr, int low, int high, SortOrder sortOrder)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if ((sortOrder == SortOrder.Ascending && arr[j] < pivot) || (sortOrder == SortOrder.Descending && arr[j] > pivot))
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #region For Floats
        public static void Sortf(float[] arr, SortOrder sortOrder, int threadcount)
        {
            int numThreads = threadcount;

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
                    QuickSortf(arr, startIndex, endIndex - 1, sortOrder);
                });
            }

            Task.WaitAll(tasks);
        }

        private static void QuickSortf(float[] arr, int low, int high, SortOrder sortOrder)
        {
            if (low < high)
            {
                int pi = Partitionf(arr, low, high, sortOrder);

                QuickSortf(arr, low, pi - 1, sortOrder);
                QuickSortf(arr, pi + 1, high, sortOrder);
            }
        }

        private static int Partitionf(float[] arr, int low, int high, SortOrder sortOrder)
        {
            float pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if ((sortOrder == SortOrder.Ascending && arr[j] < pivot) || (sortOrder == SortOrder.Descending && arr[j] > pivot))
                {
                    i++;
                    Swapf(arr, i, j);
                }
            }
            Swapf(arr, i + 1, high);
            return (i + 1);
        }

        private static void Swapf(float[] arr, int i, int j)
        {
            float temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion
    }