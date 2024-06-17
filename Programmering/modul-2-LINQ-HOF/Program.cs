using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonApp // Namespace for at organisere
{
    // Data og Person-klasse at arbejde med
    class Person // Definere personobjekternes strukturen
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }

    class Program // class Program der indeholder Main metoden, hvor al logikken udføres
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
                new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
                new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
                new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
                new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
                new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
            };

            // Opgave 1.1 - Udregner den samlede alder for alle mennesker.
            Console.WriteLine("Opgave 1.1");
            int totalAge = 0;
            for (int i = 0; i < people.Length; i++)
            {
                totalAge += people[i].Age;
            }
            Console.WriteLine($"Samlede alder (med loop): {totalAge}");

            // LINQ
            var totalAgeL = people.Sum(x => x.Age);
            Console.WriteLine($"Samlede alder med LINQ: " + totalAgeL);



            //Opgave 1.2
            Console.WriteLine("\nOpgave 1.2");
            // Tæller hvor mange der hedder "Nielsen"
            int countNielsen = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Name.Contains("Nielsen"))
                {
                    countNielsen++;
                }
            }
            Console.WriteLine($"Hvor mange der hedder Nielsen: " + countNielsen);


            // LINQ
            var countNielsenL = people.Count(x => x.Name.Contains("Nielsen"));
            Console.WriteLine($"LINQ Hvor mange der hedder Nielsen: " + countNielsenL);



            //Opgave 1.3
            Console.WriteLine("Opgave 1.3");
            // Find den ældste person
            Person oldestPerson = null;
            for (int i = 0; i < people.Length; i++)
            {
                if (oldestPerson == null || people[i].Age > oldestPerson.Age)
                {
                    oldestPerson = people[i];
                }
            }
            Console.WriteLine($"Hvem er den ældste: " + oldestPerson.Name + " " + oldestPerson.Age);

            //LINQ
            var oldestPersonL = people.OrderByDescending(x => x.Age).FirstOrDefault();
            Console.WriteLine($"Hvem er den ældste LINQ: " + oldestPersonL.Name + " " + oldestPersonL.Age);



            // Opgave 2.
            
            //Med udgangspunkt i arrayet med personer, løs nedenstående delopgaver ved anvendelse af LINQ.

            Console.WriteLine("\nOpgave 2.1");
            //Find og udskriv personen med mobilnummer “+4543215687”.
            var mobil = people.FirstOrDefault(x => x.Phone.Contains("+4543215687"));
            Console.WriteLine(mobil.Name);

            Console.WriteLine("\nOpgave 2.2");  
            //Vælg alle som er over 30 og udskriv dem.
            var over30 = people.Where(x => x.Age > 30);
            foreach (var person in over30){
                Console.WriteLine($"Er over 30 år: " + person.Name);
            }
            
            Console.WriteLine("\nOpgave 2.3");
            //Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
            var modifiedPhoneNumbers = people.Select(person =>
            {
                // Fjern "+45" fra telefonnummeret, hvis det findes, ellers returner det uændret
                string modifiedPhone = person.Phone.StartsWith("+45") ? person.Phone.Substring(3) : person.Phone;
                return new Person { Name = person.Name, Age = person.Age, Phone = modifiedPhone };
            }).ToArray();
            foreach (var person in modifiedPhoneNumbers){
                Console.WriteLine(person.Name + " " + person.Age + " " + person.Phone);
            }

            Console.WriteLine("\nOpgave 2.4");
            //Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma
            var yngreEnd30 = people.Where(x => x.Age < 30);
            string result = string.Join(",", yngreEnd30.Select(person => $"{person.Name} ({person.Phone})"));
            Console.WriteLine(result);


            // Opgave 3
            Console.WriteLine("\nOpgave 3");
            // Her oprettes et array med "forbudte" ord.
            var badWords = new string[] { "shit", "fuck", "idiot", "lort", "fanden" };

            // Opretter en funktion, der erstatter bestemte ord med et angivet erstatningsord.
            var FilterBadWords = CreateWordReplacerFn(badWords, "kage");
            // Udskriver den modificerede tekst efter udskiftning af "badWords" med "kage".
            Console.WriteLine(FilterBadWords("Sikke en gang lort"));
            // Forventet output: "Sikke en gang kage"

            // Opretter en funktion, der filtrerer ud ord i en given tekst baseret på et array af "forbudte" ord.
            var FilterWords = CreateWordFilterFn(badWords);
            // Udskriver den filtrerede tekst, hvor de "forbudte" ord er fjernet.
            Console.WriteLine(FilterWords("Hvad fanden laver du, din idiot ?")); //Nødvendigt at have " " mellemrum mellem "idiot" og "?" fordi ellers læses det ikke som forudt
            // Forventet output: "Hvad fanden laver du, din?"

            // Funktion der opretter en WordFilter-funktion.
            static Func<string, string> CreateWordFilterFn(string[] words)
            {
                return text =>
                {
                    // Deler den givne tekststreng ved mellemrum for at oprette en array af ord.
                    var wordArray = text.Split(' ');
                    
                    // Filtrerer ordene i arrayet, så kun de ord, der ikke er inkluderet i "words"-arrayet, bevares.
                    var filteredWords = wordArray.Where(word => !words.Contains(word));
                    
                    // Sammensætter de filtrerede ord tilbage til en tekststreng med mellemrum som adskiller.
                    return string.Join(" ", filteredWords);
                };
            }

            // Funktion der opretter en WordReplacer-funktion.
            static Func<string, string> CreateWordReplacerFn(string[] words, string replacementWord)
            {
                return text =>
                {
                    // Deler den givne tekststreng ved mellemrum for at oprette en array af ord.
                    var wordArray = text.Split(' ');
                    
                    // Erstatter de fundne ord med "replacementWord", hvis de findes i "words"-arrayet.
                    var replacedWords = wordArray.Select(word => words.Contains(word) ? replacementWord : word);
                    
                    // Sammensætter de erstattede ord tilbage til en tekststreng med mellemrum som adskiller.
                    return string.Join(" ", replacedWords);
                };
            }
        }
    }
}
