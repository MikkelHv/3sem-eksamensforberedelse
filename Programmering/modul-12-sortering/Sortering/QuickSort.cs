namespace Sortering
{
    public static class QuickSort
    {
        // Swap two elements in the array
        private static void Swap(int[] array, int k, int j)
        {
            int tmp = array[k];
            array[k] = array[j];
            array[j] = tmp;
        }

        // Recursive quicksort function
        private static void _quickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high); // Find the pivot element
                _quickSort(array, low, pivot - 1); // Recursively sort the left subarray
                _quickSort(array, pivot + 1, high); // Recursively sort the right subarray
            }
        }

        // Partition function to place pivot element at the correct position
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high]; // Choose the last element as pivot
            int i = low - 1; // Index of the smaller element

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j); // Swap if the current element is smaller than or equal to pivot
                }
            }
            Swap(array, i + 1, high); // Swap the pivot element with the element at i+1
            return i + 1; // Return the partitioning index
        }

        // Public method to start the sorting process
        public static void Sort(int[] array)
        {
            _quickSort(array, 0, array.Length - 1); // Call the recursive quicksort function
        }
    }
}
