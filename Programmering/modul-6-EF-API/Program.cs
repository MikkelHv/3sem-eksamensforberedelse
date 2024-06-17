using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    var users = db.Boards.ToList();

    //first create user
    Console.WriteLine("Indsætter bruger");
    db.Add(new User("Mikkel"));
    db.SaveChanges();

    // Create Board
    Console.WriteLine("Indsætter board");
    db.Add(new Board());
    db.SaveChanges();


    // Create todo
    Console.WriteLine("Indsætter et nyt task");
    db.Add(new Todo("En opgave der skal løses", "eksamen"){
        UserId = 1,
        BoardId = 1
    }); // Jeg mangler her, at en todo skal have en userid koblet på også, samt et boardId, begge id'er skal være random fra listen
    db.SaveChanges();

}