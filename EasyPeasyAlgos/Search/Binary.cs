public class Binary
{
    /// <summary>
    /// This is a simple binary search algorithm that searches for a target value in an array of ints.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int Search(int[] arr, int target)
{
    // Define the start of the search space
    int beginning = 0;
    // Define the end of the search space
    int end = arr.Length - 1;

    // Continue searching while there are still elements in the search space
    while (beginning <= end)
    {
        // Calculate the middle index of the search space
        int mid = beginning + (end - beginning) / 2;

        // If the middle element is the target, return its index
        if (arr[mid] == target)
        {
            return mid;
        }
        // If the middle element is less than the target, discard the beginning half of the search space
        else if (arr[mid] < target)
        {
            beginning = mid + 1;
        }
        // If the middle element is greater than the target, discard the end half of the search space
        else
        {
            end = mid - 1;
        }
    }

    // If the target is not found, return -1
    return -1;
}

   public static float Searchf(float[] arr, float target)
{
    // Define the start of the search space
    int beginning = 0;
    // Define the end of the search space
    int end = arr.Length - 1;

    // Continue searching while there are still elements in the search space
    while (beginning <= end)
    {
        // Calculate the middle index of the search space
        int mid = beginning + (end - beginning) / 2;

        // If the middle element is the target, return its index
        if (Math.Abs(arr[mid] - target) < 0.0001)
        {
            return mid;
        }
        // If the middle element is less than the target, discard the beginning half of the search space
        else if (arr[mid] < target)
        {
            beginning = mid + 1;
        }
        // If the middle element is greater than the target, discard the end half of the search space
        else
        {
            end = mid - 1;
        }
    }

    // If the target is not found, return -1
    return -1;
}

/// <summary>
/// This is a simple binary search algorithm that searches for a target value in an array of ints recursively.
/// </summary>
/// <param name="arr"></param>
/// <param name="target"></param>
/// <param name="beginning"></param>
/// <param name="end"></param>
/// <returns></returns>
public static int SearchRecursively(int[] arr, int target, int beginning, int end)
{
    // Base case: the search space is empty, the target is not found
    if (beginning > end)
    {
        return -1;
    }

    // Calculate the middle index of the search space
    int mid = beginning + (end - beginning) / 2;

    // If the middle element is the target, return its index
    if (arr[mid] == target)
    {
        return mid;
    }
    // If the middle element is less than the target, search the end half
    else if (arr[mid] < target)
    {
        return SearchRecursively(arr, target, mid + 1, end);
    }
    // If the middle element is greater than the target, search the beginning half
    else
    {
        return SearchRecursively(arr, target, beginning, mid - 1);
    }
}

public static float SearchRecursively(float[] arr, float target, int beginning, int end)
{
    // Base case: the search space is empty, the target is not found
    if (beginning > end)
    {
        return -1;
    }

    // Calculate the middle index of the search space
    int mid = beginning + (end - beginning) / 2;

    // If the middle element is the target, return its index
    if (Math.Abs(arr[mid] - target) < 0.0001)
    {
        return mid;
    }
    // If the middle element is less than the target, search the end half
    else if (arr[mid] < target)
    {
        return SearchRecursively(arr, target, mid + 1, end);
    }
    // If the middle element is greater than the target, search the beginning half
    else
    {
        return SearchRecursively(arr, target, beginning, mid - 1);
    }
}
}