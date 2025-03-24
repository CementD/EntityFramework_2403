using ConsoleApp6.DAL;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var usersRepos = new UsersRepository();

            //context.Database.EnsureCreated();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Show users");
                Console.WriteLine("3. Remove user");
                Console.WriteLine("4. Update user");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(usersRepos);
                        break;
                    case "2":
                        ShowUsers(usersRepos);
                        break;
                    case "3":
                        RemoveUser(usersRepos);
                        break;
                    case "4":
                        UpdateUser(usersRepos);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Incorect input!");
                        break;
                }
                Thread.Sleep(2000);
            }
        }

        static void AddUser(UsersRepository usersRepository)
        {
            Console.Clear();
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            var user = new User { Name = name, Age = age, Email = email };
            
            usersRepository.Add(user);

            Console.WriteLine("User was added");
        }

        static void ShowUsers(UsersRepository usersRepository)
        {
            Console.Clear();
            var users = usersRepository.GetAll();

            if (users.Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            Console.WriteLine("The list of users: ");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            }
        }

        static void RemoveUser(UsersRepository usersRepository)
        {
            Console.Clear();
            Console.Write("Enter the ID to remove: ");
            int userId = int.Parse(Console.ReadLine());

            var user = usersRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User is not found.");
                return;
            }

            usersRepository.Delete(user);

            Console.WriteLine("User was removed!");
        }

        static void UpdateUser(UsersRepository usersRepository)
        {
            Console.Clear();
            Console.Write("Enter the ID to update: ");
            int userId = int.Parse(Console.ReadLine());

            var user = usersRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Clear();
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Email");
            Console.WriteLine("4. Update all");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new name: ");
                    user.Name = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Enter new age: ");
                    user.Age = int.Parse(Console.ReadLine());
                    break;

                case "3":
                    Console.Write("Enter new email: ");
                    user.Email = Console.ReadLine();
                    break;

                case "4":
                    Console.Write("Enter new name: ");
                    user.Name = Console.ReadLine();

                    Console.Write("Enter new age: ");
                    user.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter new email: ");
                    user.Email = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid input! Please try again.");
                    return;
            }

            usersRepository.Update(user);
            Console.WriteLine("User was updated!");
        }

    }
}
