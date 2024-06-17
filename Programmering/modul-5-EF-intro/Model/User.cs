// TodoTask.cs
namespace Model
{
    public class User
    {
        public User(string name) {
            this.Name = name;
        }
        public long UserId { get; set; }
        public string Name { get; set; }
        public ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>(); // Navigation property to associate multiple TodoTasks with a user

    }
}