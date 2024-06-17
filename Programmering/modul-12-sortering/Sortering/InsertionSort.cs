namespace Sortering;

public class InsertionSort
{
    // Offentlig metode til at sortere arrayet ved hjælp af insertion sort
    public static void Sort(int[] array)
    {
        // Ydre loop starter fra det andet element (indeks 1)
        for (int i = 1; i < array.Length; i++)
        {
            int next = array[i]; // Gemmer det næste element, der skal indsættes i den sorterede del
            int j = i; // Initialiserer 'j' til 'i' for at starte sammenligningerne
            bool found = false; // En flagvariabel for at indikere, om den korrekte position er fundet

            // Indre loop for at finde den korrekte position for 'next' i den sorterede del af arrayet
            while (!found && j > 0)
            {
                if (next >= array[j - 1]) // Hvis 'next' er større eller lig med det foregående element
                {
                    found = true; // Position fundet, exit loopet
                }
                else
                {
                    array[j] = array[j - 1]; // Skub det sorterede element en plads op
                    j--; // Gå til det næste element i den sorterede del
                }
            }
            array[j] = next; // Indsæt 'next' på den fundne position
        }
        // Return statement er ikke nødvendigt, da metoden er void, og sorteringen er in-place
        return;
    }
}
