namespace Sortering;

public class BubbleSort
{
    // Privat metode til at bytte to elementer i arrayet
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];   // Midlertidigt gemme værdien af array[i]
        array[i] = array[j];   // Sæt array[i] til værdien af array[j]
        array[j] = temp;       // Sæt array[j] til den midlertidige værdi (oprindelige array[i])
    }

    // Offentlig metode til at sortere arrayet ved hjælp af boblesortering
    public static void Sort(int[] array)
    {
        // Ydre loop går gennem arrayet fra slutningen til begyndelsen
        for (int i = array.Length - 1; i >= 0; i--)
        {
            // Indre loop går fra starten af arrayet op til i-1
            for (int j = 0; j <= i - 1; j++)
            {
                // Hvis det aktuelle element er større end det næste element
                if (array[j] > array[j + 1])
                {
                    // Byt de to elementer
                    Swap(array, j, j + 1);
                }
            }
        }
        // Return statement er ikke nødvendigt, da metoden er void, og sorteringen er in-place
        return;
    }
}

