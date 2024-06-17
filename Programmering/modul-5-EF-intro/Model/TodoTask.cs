// TodoTask.cs
namespace Model
{
    public class TodoTask
    {
        // Parameterless constructor required by ORM
        //Den sikrer, at dine objekter kan oprettes og håndteres korrekt af forskellige rammeværk og værktøjer.
        public TodoTask() {}

        // Constructor to initialize a new TodoTask
        public TodoTask(string text, string category, bool done) 
        {
            this.Text = text;
            this.Category = category;
            this.Done = done;
        }

        // Unique identifier for the TodoTask
        public long TodoTaskId { get; set; }

        // Description or content of the task
        public string? Text { get; set; }

        // Category to which the task belongs
        public string? Category { get; set; }

        // Status of the task, indicating if it is completed
        public bool Done { get; set; }

        // Foreign key property for User
        public long UserId { get; set; }

        // Navigation property to associate the task with a user
        public User User { get; set; }
    }
}
