using System;

namespace Bridge;

class Program
{
    static void Main(string[] args)
    {
        var noCoupon = new NoCoupon();
        var oneEuroCoupon = new OneEuroCoupon();
        var twoEuroCoupon = new TwoEuroCoupon();

        var meatBasedMenu = new MeatBasedMenu(noCoupon);
        Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");

        meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
        Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");

        meatBasedMenu = new MeatBasedMenu(twoEuroCoupon);
        Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");

        var vegetarianMenu = new VegetarianMenu(noCoupon);
        Console.WriteLine($"Vegetarian menu based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");

        vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
        Console.WriteLine($"Vegetarian menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");

        vegetarianMenu = new VegetarianMenu(twoEuroCoupon);
        Console.WriteLine($"Vegetarian menu, no coupon: {meatBasedMenu.CalculatePrice()} euro");


    }
}
