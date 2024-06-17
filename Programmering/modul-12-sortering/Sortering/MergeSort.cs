namespace Sortering;

public static class MergeSort
{
    // Public metode til at starte merge sort
    public static void Sort(int[] array)
    {
        _mergeSort(array, 0, array.Length - 1);
    }

    // Rekursiv funktion til at opdele arrayet i mindre sub-arrays
    private static void _mergeSort(int[] array, int l, int h)
    {
        if (l < h)
        {
            int m = (l + h) / 2; // Find midtpunktet
            _mergeSort(array, l, m); // Sorter første halvdel
            _mergeSort(array, m + 1, h); // Sorter anden halvdel
            Merge(array, l, m, h); // Flet de sorterede halvdele sammen
        }
    }

    // Funktion til at flette to sorterede sub-arrays
    private static void Merge(int[] array, int low, int middle, int high)
    {
        // Find størrelserne af de to sub-arrays der skal flettes
        int n1 = middle - low + 1;
        int n2 = high - middle;

        // Opret midlertidige arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Kopier data til de midlertidige arrays
        for (int i = 0; i < n1; i++)
        {
            leftArray[i] = array[low + i];
        }
        for (int j = 0; j < n2; j++)
        {
            rightArray[j] = array[middle + 1 + j];
        }

        // Initialiser indekser for de midlertidige arrays og det originale array
        int k = low;
        int iIndex = 0;
        int jIndex = 0;

        // Flet de midlertidige arrays tilbage i det originale array
        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex] <= rightArray[jIndex])
            {
                array[k] = leftArray[iIndex];
                iIndex++;
            }
            else
            {
                array[k] = rightArray[jIndex];
                jIndex++;
            }
            k++;
        }

        // Kopier resterende elementer af leftArray, hvis nogen
        while (iIndex < n1)
        {
            array[k] = leftArray[iIndex];
            iIndex++;
            k++;
        }

        // Kopier resterende elementer af rightArray, hvis nogen
        while (jIndex < n2)
        {
            array[k] = rightArray[jIndex];
            jIndex++;
            k++;
        }
    }
}
