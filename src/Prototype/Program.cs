using System;

namespace Prototype;

class Program
{
    static void Main(string[] args)
    {
        var manager = new Manager("Wodson");
        var managerCloned = (Manager)manager.Clone();

        Console.WriteLine($"Manager was clone with name {managerCloned.Name}");

        var employee = new Employee("Wodson", managerCloned);
        var employeeCloned = (Employee)employee.Clone(true);
        Console.WriteLine($"Employee was clone with name {employeeCloned.Name}");

        managerCloned.Name = "Joao";
        Console.WriteLine($"Employee was clone with name {employeeCloned.Name}, with manager name {employeeCloned.Manager.Name}");
    }
}
