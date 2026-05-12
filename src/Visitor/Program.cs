using System;

namespace Visitor;

class Program
{
    static void Main(string[] args)
    {
        var container = new Container();

        container.Customers.Add(new Customer("Wodson", 500));
        container.Customers.Add(new Customer("Joao", 600));
        container.Customers.Add(new Customer("Maria", 700));

        container.Employees.Add(new Employee("Thalia", 20));
        container.Employees.Add(new Employee("Antonio", 5));

        // create visitor
        var discountVisitor = new DiscountVisitor();

        //pass it through
        container.Accept(discountVisitor);

        Console.WriteLine($"Totol discount: {discountVisitor.TotalDiscountGiven}");
    }
}
