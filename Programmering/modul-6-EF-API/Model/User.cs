
namespace Model
{
    public class User
    {
        // Parameterless constructor required by ORM
        public User() {}

        // Constructor to initialize a new User
        public User(string name) 
        {
            this.Name = name;
        }

        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
