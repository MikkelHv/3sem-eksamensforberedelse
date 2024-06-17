namespace Sortering;

public class BubbleSort
{
    // Privat metode til at bytte to elementer i arrayet
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];   // Midlertidigt gemme v�rdien af array[i]
        array[i] = array[j];   // S�t array[i] til v�rdien af array[j]
        array[j] = temp;       // S�t array[j] til den midlertidige v�rdi (oprindelige array[i])
    }

    // Offentlig metode til at sortere arrayet ved hj�lp af boblesortering
    public static void Sort(int[] array)
    {
        // Ydre loop g�r gennem arrayet fra slutningen til begyndelsen
        for (int i = array.Length - 1; i >= 0; i--)
        {
            // Indre loop g�r fra starten af arrayet op til i-1
            for (int j = 0; j <= i - 1; j++)
            {
                // Hvis det aktuelle element er st�rre end det n�ste element
                if (array[j] > array[j + 1])
                {
                    // Byt de to elementer
                    Swap(array, j, j + 1);
                }
            }
        }
        // Return statement er ikke n�dvendigt, da metoden er void, og sorteringen er in-place
        return;
    }
}

