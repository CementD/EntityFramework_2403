using ConsoleApp6.DAL;
using ConsoleApp6.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add order to student");
                Console.WriteLine("3. Show all students and orders");
                Console.WriteLine("4. Show all orders");
                Console.WriteLine("5. Delete student");
                Console.WriteLine("6. Delete order");
                Console.WriteLine("7. Update student");
                Console.WriteLine("8. Update order");
                Console.WriteLine("9. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        AddStudent(context);
                        break;
                    case "2":
                        AddOrderToStudent(context);
                        break;
                    case "3":
                        ShowStudentsWithOrders(context);
                        break;
                    case "4":
                        ShowAllOrders(context); 
                        break;
                    case "5":
                        DeleteStudent(context);
                        break;
                    case "6":
                        DeleteOrder(context);
                        break;
                    case "7":
                        UpdateStudent(context);
                        break;
                    case "8":
                        UpdateOrder(context);
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void AddStudent(AppDbContext context)
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();
            var student = new Student { Name = name };
            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student was added.");
        }

        static void ShowStudentsWithOrders(AppDbContext context)
        {
            var students = context.Students.Include(s => s.Orders).ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
                foreach (var order in student.Orders)
                {
                    Console.WriteLine($"Order: {order.ProductName}, Date: {order.DateCreate}");
                }
            }
        }

        static void ShowStudents(AppDbContext context)
        {
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }
        }

        static void ShowAllOrders(AppDbContext context)
        {
            var orders = context.Orders.Include(o => o.Student).ToList();
            if (orders.Any())
            {
                Console.WriteLine("All Orders:");
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product: {order.ProductName}, Date: {order.DateCreate}, Student: {order.Student.Name}");
                }
            }
            else Console.WriteLine("No orders found.");
        }

        static void AddOrderToStudent(AppDbContext context)
        {
            ShowStudents(context);
            Console.Write("Enter student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter te name of product: ");
                string productName = Console.ReadLine();
                var order = new Order { ProductName = productName, DateCreate = DateTime.Now };
                student.Orders.Add(order);
                context.SaveChanges();
                Console.WriteLine("Order was added.");
            }
            else Console.WriteLine("Student was not found.");
        }

        static void DeleteStudent(AppDbContext context)
        {
            ShowStudents(context);
            Console.Write("Enter student id: ");
            int studentId = int.Parse (Console.ReadLine());
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Student was deleted.");
            }
            else Console.WriteLine("Student was not found.");
        }

        static void DeleteOrder(AppDbContext context)
        {
            ShowAllOrders(context);
            Console.Write("Enter order ID to delete: ");
            int orderId = int.Parse (Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
                Console.WriteLine("Order was deleted.");
            }
            else Console.WriteLine("Order was not found.");
        }


        static void UpdateStudent(AppDbContext context)
        {
            ShowStudents(context);
            Console.Write("Enter student id: ");
            int studentId = int.Parse (Console.ReadLine());
            var student = context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                Console.Write("Enter new name: ");
                student.Name = Console.ReadLine();
                context.SaveChanges();
                Console.WriteLine("Student was updated.");
            }
            else Console.WriteLine("Student was not found.");
        }

        static void UpdateOrder(AppDbContext context)
        {
            ShowAllOrders(context);
            Console.Write("Enter order ID to update: ");
            int orderId = int.Parse (Console.ReadLine());

            var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                Console.Write("Enter new product name: ");
                order.ProductName = Console.ReadLine();
                context.SaveChanges();
                Console.WriteLine("Order was updated.");
            }
            else Console.WriteLine("Order was not found.");
        }
    }
}
