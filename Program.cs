using System.Linq;

namespace PostegreSQLConnectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new() { Name = "Tom", Age = 33 };
                User user2 = new() { Name = "Alice", Age = 25 };

                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                System.Console.WriteLine("Users list:");
                foreach (User u in users)
                    System.Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
    }
}
