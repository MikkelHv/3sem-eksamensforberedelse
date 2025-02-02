﻿namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal) 
        {
            // simpelt loop, der iterere gennem arrayet indtil den finder tal ellers returneres -1 aka not found
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal)
        {
            int min = 0;
            int max = array.Length - 1;

            // Brug <= for at sikre, at vi også tjekker det sidste element i intervallet
            while (min <= max)
            {
                // Beregn midterpunktet af det nuværende interval
                int mid = (min + max) / 2;

                // Hvis talet findes ved midterpunktet, returner indexet
                if (tal == array[mid])
                {
                    return mid;
                }
                // Hvis talet er mindre end midterpunktets værdi, søg i den venstre halvdel
                else if (tal < array[mid])
                {
                    max = mid - 1;
                }
                // Hvis talet er større end midterpunktets værdi, søg i den højre halvdel
                else
                {
                    min = mid + 1;
                }
            }
            // Hvis talet ikke findes i arrayet, returner -1
            return -1;
        }


        private static int[] sortedArray { get; set; } =
    new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            // Find den første ledige plads (symboliseret af -1)
            int insertIndex = -1;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] == -1)
                {
                    insertIndex = i;
                    break;
                }
            }

            // Hvis der ikke er nogen ledig plads, returner arrayet som det er
            if (insertIndex == -1)
            {
                //throw new InvalidOperationException("Arrayet har ingen ledige pladser.");
                return sortedArray;
            }

            // Skift de elementer, der er større end det indsatte tal
            for (int i = insertIndex; i > 0 && sortedArray[i - 1] > tal; i--)
            {
                sortedArray[i] = sortedArray[i - 1];
                insertIndex = i - 1;
            }

            // Indsæt det nye tal på den rigtige plads
            sortedArray[insertIndex] = tal;

            // Returner en kopi af det opdaterede array
            return (int[])sortedArray.Clone();
        }

    }
}