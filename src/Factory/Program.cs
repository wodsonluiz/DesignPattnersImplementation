using System;
using System.Collections.Generic;

namespace Factory;

class Program
{
    static void Main(string[] args)
    { 
        var factories = new List<DiscountFactory>
        {
            new CodeDiscontFactory(Guid.NewGuid()),
            new CountryDiscontFactory("BE")
        };

        foreach (var factory in factories)
        {
            var discontService = factory.CreateDiscountService();

            Console.WriteLine($"Percentage {discontService.DiscontPercentage} coming form {discontService}");
        }
    }
}
