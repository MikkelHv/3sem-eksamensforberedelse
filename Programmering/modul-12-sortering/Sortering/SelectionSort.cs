namespace Sortering;

public class SelectionSort
{
    // Privat metode til at bytte to elementer i arrayet
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];   // Midlertidigt gemme værdien af array[i]
        array[i] = array[j];   // Sæt array[i] til værdien af array[j]
        array[j] = temp;       // Sæt array[j] til den midlertidige værdi (oprindelige array[i])
    }

    // Offentlig metode til at sortere arrayet ved hjælp af selection sort
    public static void Sort(int[] array)
    {
        // Ydre loop går gennem hvert element i arrayet
        for (int i = 0; i < array.Length; i++)
        {
            int min = i; // Antag at det nuværende element er det mindste

            // Indre loop for at finde det mindste element i resten af arrayet
            for (int j = i + 1; j < array.Length; j++)
            {
                // Hvis det nuværende element er mindre end det antagne mindste
                if (array[j] < array[min])
                {
                    min = j; // Opdater det mindste element
                }
            }

            // Byt det fundne mindste element med det første element i usorteret del
            Swap(array, i, min);
        }
        // Return statement er ikke nødvendigt, da metoden er void, og sorteringen er in-place
        return;
    }
}
