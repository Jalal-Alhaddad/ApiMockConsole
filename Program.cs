namespace ApiMockConsole;

using System;
using System.Collections.Generic;

class Program
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }

    static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Position = "Developer" },
        new Employee { Id = 2, Name = "Jane Doe", Position = "Designer" },
        new Employee { Id = 3, Name = "Bob Smith", Position = "Manager" }
        // Add more fake data as needed
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Get Employee List");
            Console.WriteLine("2. Get Employee by Id");
            Console.WriteLine("3. Add New Employee");
            Console.WriteLine("4. Delete Employee by Id");
            Console.WriteLine("5. Exit");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    GetEmployeeList();
                    break;
                case "2":
                    GetEmployeeById();
                    break;
                case "3":
                    AddNewEmployee();
                    break;
                case "4":
                    DeleteEmployeeById();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void GetEmployeeList()
    {
        Console.WriteLine("Employee List:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}");
        }
        Console.WriteLine();
    }

    static void GetEmployeeById()
    {
        Console.Write("Enter Employee Id: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                Console.WriteLine($"Employee Found: Id: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Id.");
        }
        Console.WriteLine();
    }

    static void AddNewEmployee()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Employee Position: ");
        string position = Console.ReadLine();

        var newEmployee = new Employee
        {
            Id = employees.Count + 1, // You might want to use a more robust way to generate IDs in a real-world scenario
            Name = name,
            Position = position
        };

        employees.Add(newEmployee);
        Console.WriteLine($"Employee added successfully. Id: {newEmployee.Id}");
        Console.WriteLine();
    }

    static void DeleteEmployeeById()
    {
        Console.Write("Enter Employee Id to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($"Employee with Id {id} deleted.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Id.");
        }
        Console.WriteLine();
    }
}
