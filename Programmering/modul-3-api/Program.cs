var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lavet med liste, se Array.cs for samme opgaver med et array


//Opgave 2
app.MapGet("/api/hello", () => new { Message = "Hello world!" });


// Opgave 3
app.MapGet("/api/hello/{name}", (string name) => new { Message =$"Hello {name}!"});
app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}!, du må være " + age + " år gammel"});


//Opgave 4
// frugt api
Random rnd = new();
String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

app.MapGet("/api/fruit", () => frugter); // viser array af frugter
app.MapGet("/api/fruit/{index}", (int index) => frugter[index]); // Viser en bestemt frugt, der er på specifik plads i arrayet
app.MapGet("/api/fruit/random", () => frugter[rnd.Next(frugter.Length)]); // Viser random frugt fra arrayet


// Opgave 5: Tilføj en post til frugter
app.MapPost("/api/fruit", (Fruit fruit) =>
{
    /*
    // Opret et nyt array med en størrelse, der er én større end det oprindelige array
    String[] nyeFrugter = new String[frugter.Length + 1];

    // Kopier de eksisterende elementer over til det nye array
    for (int i = 0; i < frugter.Length; i++) {
        nyeFrugter[i] = frugter[i];
    }

    // Tilføj det nye element til det nye array
    nyeFrugter[frugter.Length] = fruit.name;

    // Opdater den oprindelige reference til det nye array
    frugter = nyeFrugter;

    // Udskriv det opdaterede array til konsollen (for debugging)
    foreach (String frugt in frugter) {
        Console.WriteLine(frugt);
    }

    // Returner det opdaterede array som JSON --- Best-practise ellers sende en Results.Ok("Frugt tilføjet succesfuldt")
    return Results.Json(frugter);
    */

    /// Opgave 6 start ///
    // Validering: Check om fruit.name er null eller tom
    if (string.IsNullOrWhiteSpace(fruit.name))
    {
        return Results.BadRequest("Fruit name cannot be empty."); // sender en badrequest hvis den er null eller whitespace
    }
    /// Opgave 6 slut ///

    // Liste-løsning - mere effektiv til dynamiske ændringer
    List<string> frugterListe = frugter.ToList();

    // Tilføj den nye frugt til listen
    frugterListe.Add(fruit.name);

    // Udskriv det opdaterede array til konsollen (for debugging)
    foreach (String frugt in frugterListe) {
        Console.WriteLine(frugt);
    }

    // Returner det opdaterede array som JSON --- Best-practise ellers sende en Results.Ok("Frugt tilføjet succesfuldt")
    return Results.Json(frugterListe);

});
app.Run("http://localhost:3000"); // Defineret hvilken port den skal åbne

//Record, nødvendig for at lave POST ---opg 5
record Fruit(string name);
