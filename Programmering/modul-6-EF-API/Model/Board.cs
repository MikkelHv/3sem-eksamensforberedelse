
namespace Model
{
    public class Board
    {
        // Parameterless constructor required by ORM
        public Board() {}

        // Constructor to initialize a new Board
        /*
        public Board(Todo todo) 
        {
            this.Todo = todo;
        }
        */

        public long BoardId { get; set; }
        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}
