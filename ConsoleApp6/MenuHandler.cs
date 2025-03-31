using ConsoleApp6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class MenuHandler
    {
        private readonly UserService _userService;

        public MenuHandler()
        {
            _userService = new UserService();
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Show users");
                Console.WriteLine("3. Remove user");
                Console.WriteLine("4. Update user");
                Console.WriteLine("5. Sort users");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        ShowUsers();
                        break;
                    case "3":
                        RemoveUser();
                        break;
                    case "4":
                        UpdateUser();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
                Thread.Sleep(2000);
            }
        }

        private void AddUser()
        {
            Console.Clear();
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            var user = new User { Name = name, Age = age, Email = email };

            _userService.Add(user);

            Console.WriteLine("User was added");
        }

        private void ShowUsers()
        {
            Console.Clear();

            var users = _userService.GetAll();

            if (users.Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            var sortedUsers = users.OrderBy(x => x.Name).ToList();
            PrintUsers(sortedUsers);
        }

        private void PrintUsers(List<User> users)
        {
            users = users.OrderBy(x => x.Name).ToList();
            Console.WriteLine("The list of users (sorted by name): ");
            foreach (var  user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            }
        }

        private void RemoveUser()
        {
            Console.Clear();
            Console.Write("Enter the ID to remove: ");
            int userId = int.Parse(Console.ReadLine());

            var user = _userService.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User is not found.");
                return;
            }

            _userService.Delete(user);

            Console.WriteLine("User was removed!");
        }

        private void UpdateUser()
        {
            Console.Clear();
            Console.Write("Enter the ID to update: ");
            int userId = int.Parse(Console.ReadLine());

            var user = _userService.GetById(userId);

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

            _userService.Update(user);
            Console.WriteLine("User was updated!");
        }
    }
}