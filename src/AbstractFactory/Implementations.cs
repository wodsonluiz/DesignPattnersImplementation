namespace AbstractFactory
{
    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDicountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IDicountService
    {
        int DiscontPercentage { get; }
    }

    /// <summary>
    /// ConcretProduct
    /// </summary>
    public class BelgiumDiscontService : IDicountService
    {
        public int DiscontPercentage => 20;
    }

    /// <summary>
    /// ConcretProduct
    /// </summary>
    public class FranceDiscontService : IDicountService
    {
        public int DiscontPercentage => 10;
    }

    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// ConcretProduct
    /// </summary>
    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// ConcretProduct
    /// </summary>
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// ConcretFactory
    /// </summary>
    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDicountService CreateDiscountService()
        {
            return new BelgiumDiscontService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }

    /// <summary>
    /// ConcretFactory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDicountService CreateDiscountService()
        {
            return new FranceDiscontService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDicountService _dicountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _ordersCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _dicountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            _ordersCosts = 200;
        }

         public void CalculateCosts()
         {
            System.Console.WriteLine($"Total costs = {_ordersCosts - (_ordersCosts/100*_dicountService.DiscontPercentage) + _shippingCostsService.ShippingCosts}");
         }

    }
}