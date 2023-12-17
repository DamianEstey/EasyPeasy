using System.Collections.Generic;


namespace EasyPeasyAlgos.Search;

public class Linear 
{
    /// <summary>
    /// This is a simple linear search algorithm that searches for a target value in an array of ints.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int Search(int[] arr, int target)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i].Equals(target))
            {
                return arr[i];
            }
        }

        return -1;
    }

    /// <summary>
    /// This is a simple linear search algorithm that searches for a target value in an array of floats.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static float Searchf(float[] arr, int target)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            if(Math.Abs(arr[i] - target) < 0.0001)
            {
                return arr[i];
            }
        }

        return -1f;
    }

    /// <summary>
    /// This is a simple linear search algorithm that searches for a target value in an array of ints. This array is also a self-organized array.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int Search(Weighted[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Value.Equals(target))
            {
                // Increment the weight of the found element
                arr[i].Weight++;

                // If it's not the first element and its weight is greater than the previous element's weight
                if (i > 0 && arr[i].Weight > arr[i - 1].Weight)
                {
                    // Swap the found element with the previous element
                    Weighted temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }

                return arr[i].Value;
            }
        }

        return -1; // return null if the item was not found
    }

    /// <summary>
    /// This is a simple linear search algorithm that searches for a target value in an array of floats. This array is also a self-organized array.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static float Searchf(Weightedf[] arr, float target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i].Value - target) < 0.0001) // Compare floats with a small tolerance
            {
                // Increment the weight of the found element
                arr[i].Weight++;

                // If it's not the first element and its weight is greater than the previous element's weight
                if (i > 0 && arr[i].Weight > arr[i - 1].Weight)
                {
                    // Swap the found element with the previous element
                    Weightedf temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }

                return arr[i].Value;
            }
        }

        return -1f; // return -1f if the item was not found
    }
}