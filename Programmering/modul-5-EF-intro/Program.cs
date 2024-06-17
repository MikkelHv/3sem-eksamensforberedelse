using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Indsætter et nyt task");
    db.Add(new TodoTask("En opgave der skal løses", "eksamen",false));
    db.SaveChanges();



    // Read
    Console.WriteLine("Finder det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");



   // Update
    Console.WriteLine("Update en task. Skriv id nr på task...");

    // Læser brugerens input for task ID
    var taskToUpdateIdStr = Console.ReadLine(); // Problemet er, at Console.ReadLine returnerer en string, men TodoTaskId er en long

    // Forsøger at konvertere brugerens input fra string til long
    if (long.TryParse(taskToUpdateIdStr, out long taskToUpdateId)) // Derfor bruger jeg TryParse
    {
        // Finder tasken i databasen baseret på ID
        var updateTask = db.Tasks
            .FirstOrDefault(b => b.TodoTaskId == taskToUpdateId);
        
        // Hvis tasken findes
        if (updateTask != null)
        {
            // Beder brugeren om at indtaste den nye opgavebeskrivelse
            Console.WriteLine("Skriv ny opgave");
            var newTask = Console.ReadLine();
            
            // Opdaterer taskens tekst
            updateTask.Text = newTask;
            
            // Gemmer ændringerne i databasen
            db.SaveChanges();
            
            // Informerer brugeren om den opdaterede opgave
            Console.WriteLine($"Her er den opdaterede version: {updateTask.Text}");
        }
        else
        {
            // Informerer brugeren om, at tasken ikke blev fundet
            Console.WriteLine("Task ikke fundet.");
        }
    }
    else
    {
        // Informerer brugeren om, at der opstod en fejl ved konvertering af ID
        Console.WriteLine("Der opstod en fejl. Ugyldigt ID.");
    }



        //Delete

    // Informerer brugeren om det aktuelle antal opgaver
    Console.WriteLine("Her er antallet af opgaver:");
    foreach (var task in db.Tasks)
    {
        Console.WriteLine(task.TodoTaskId); // Udskriver ID for hver opgave
    }

    // Informerer brugeren om, at en opgave skal slettes, og beder om ID
    Console.WriteLine("\nDu er ved at slette en task\nIndtast id...");
    var taskToDeleteStr = Console.ReadLine(); // Læser brugerens input for task ID

    // Forsøger at konvertere brugerens input fra string til long
    if (long.TryParse(taskToDeleteStr, out long taskToDeleteId))
    {
        // Finder tasken i databasen baseret på ID
        var deleteTask = db.Tasks
            .FirstOrDefault(b => b.TodoTaskId == taskToDeleteId);
            
        // Hvis tasken findes
        if (deleteTask != null)
        {
            db.Remove(deleteTask); // Fjerner tasken fra databasen
            db.SaveChanges(); // Gemmer ændringerne i databasen
            Console.WriteLine($"Opgaven er slettet"); // Informerer brugeren om, at tasken er slettet
        }
        else
        {
            Console.WriteLine("Task not found"); // Informerer brugeren om, at tasken ikke blev fundet
        }
    }
    else
    {
        Console.WriteLine("Something failed"); // Informerer brugeren om, at der opstod en fejl ved konvertering af ID
    }

    // Informerer brugeren om det nye antal opgaver efter sletning
    Console.WriteLine("Her er det nye antal af opgaver:");
    foreach (var task in db.Tasks)
    {
        Console.WriteLine(task.TodoTaskId); // Udskriver ID for hver opgave
    }

}