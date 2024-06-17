
namespace Model
{
    public class Todo
    {
        // Parameterless constructor required by ORM
        public Todo() {}

        // Constructor to initialize a new Todo
        public Todo(string name, string category) 
        {
            this.Name = name;
            this.Category = category;
        }

        public long TodoId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        // Foreign key property for User
        public long UserId { get; set; } 

        // Navigation property to associate the todo with a user
        public User User { get; set; }

        // Foreign key property for Board
        public long BoardId { get; set; }

        // Navigation property to associate the todo with a board
        public Board Board { get; set; }
    }
}
