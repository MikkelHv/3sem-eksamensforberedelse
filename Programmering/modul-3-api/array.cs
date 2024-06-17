/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Task[] tasks = new Task[]
{
    new Task("Læse", false),
    new Task("Træne", false),
    new Task("Spise", false)
};

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/tasks", () => tasks);

app.MapGet("/api/tasks/{id}", (int id) =>
{
    if (id < 0 || id >= tasks.Length)
    {
        return Results.NotFound("Task not found.");
    }

    return Results.Json(tasks[id]);
});

app.MapPut("/api/tasks/{id}", (int id, Task updatedTask) =>
{
    if (id < 0 || id >= tasks.Length)
    {
        return Results.NotFound("Task not found.");
    }

    tasks[id] = new Task(updatedTask.Name, updatedTask.Done);

    return Results.Json(tasks[id]);
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{
    if (id < 0 || id >= tasks.Length)
    {
        return Results.NotFound("Task not found.");
    }

    // Flyt opgaven til slutningen af arrayet og fjern den
    for (int i = id; i < tasks.Length - 1; i++)
    {
        tasks[i] = tasks[i + 1];
    }

    Array.Resize(ref tasks, tasks.Length - 1);

    return Results.Json(tasks);
});

app.MapPost("/api/tasks/", (Task task) =>
{
    if (string.IsNullOrWhiteSpace(task.Name))
    {
        return Results.BadRequest("Task name cannot be empty.");
    }

    Array.Resize(ref tasks, tasks.Length + 1);
    tasks[tasks.Length - 1] = task;

    return Results.Json(tasks.LastOrDefault());
});

app.Run("http://localhost:3000");

record Task(string Name, bool Done);
*/