using System;

namespace AbstractFactory;

static class Program
{
    static void Main(string[] args)
    {
         Console.Title = "Abstract Factory";
         var factory = new BelgiumShoppingCartPurchaseFactory();
         var shoppingCart = new ShoppingCart(factory);

         shoppingCart.CalculateCosts();
    }
}
