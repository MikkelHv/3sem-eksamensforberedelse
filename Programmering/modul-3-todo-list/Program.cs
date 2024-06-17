var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Lavet med en liste, samme opgaver er løst med array i Array.cs

List<Task> tasks = new List<Task>() //Bruge Task record-class til at bruge korrekt type
{
    new Task("Læse", false),
    new Task("Træne", false),
    new Task("Spise", false)
};


app.MapGet("/", () => "Hello World!");

app.MapGet("/api/tasks", () => tasks);

// Endpoint for at returnere en specifik opgave baseret på id
app.MapGet("/api/tasks/{id}", (int id) =>
{
    if (id < 0 || id >= tasks.Count) // hvis id ikke er inden for tasks.Count, findes id'et ikke
    {
        return Results.NotFound("Task not found.");
    }

    return Results.Json(tasks[id]);
});

// PUT metode
app.MapPut("/api/tasks/{id}", (int id, Task updatedTask) => 
{
    if (id < 0 || id >= tasks.Count) // hvis id ikke er inden for tasks.Count, findes id'et ikke
    {
        return Results.NotFound("Task not found.");
    }

    // Opdater den eksisterende opgave med den nye information
    tasks[id] = new Task(updatedTask.Name, updatedTask.Done);

    // Returner den opdaterede opgave som JSON
    return Results.Json(tasks[id]);
});

// DELETE metode
app.MapDelete("/api/tasks/{id}", (int id) => 
{
    if (id < 0 || id >= tasks.Count) // hvis id ikke er inden for tasks.Count, findes id'et ikke
    {
        return Results.NotFound("Task not found.");
    }

    tasks.RemoveAt(id); //Sletter opgaven

    foreach (var tsk in tasks) {
        Console.WriteLine(tsk.Name);
    }

    return Results.Json(tasks);
});

// POST metode
app.MapPost("/api/tasks/", (Task task) => {
    if (string.IsNullOrWhiteSpace(task.Name))
    {
        return Results.BadRequest("Task name cannot be empty."); // sender en badrequest hvis den er null eller whitespace
    }
    tasks.Add(task);

    foreach (var tsk in tasks) {
        Console.WriteLine(tsk.Name);
    }

    return Results.Json(tasks.LastOrDefault());

});


app.Run("http://localhost:3000"); // Defineret hvilken port den skal åbne

record Task(string Name, bool Done);