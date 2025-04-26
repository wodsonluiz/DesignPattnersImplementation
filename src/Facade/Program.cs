using System;

namespace Facade;

class Program
{
    static void Main(string[] args)
    {
        var facade = new DiscontFacade();
        Console.WriteLine($"Discont percentage for customer with id 1: {facade.CalculateDiscontPercentage(1)}");
        Console.WriteLine($"Discont percentage for customer with id 10: {facade.CalculateDiscontPercentage(10)}");
    }
}
