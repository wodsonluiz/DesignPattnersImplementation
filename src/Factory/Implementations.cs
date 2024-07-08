using System;

namespace Factory
{
    /// <summary>
    /// Product
    /// </summary>
    public abstract class DiscontService
    {
        public abstract int DiscontPercentage { get; }
        public override string ToString() => GetType().Name;
    }

    /// <summary>
    /// Implementation 1
    /// </summary>
    public class ContryDiscontService: DiscontService
    {
        private readonly string _contryIdentifier;

        public ContryDiscontService(string contryIdentifier)
        {
            _contryIdentifier = contryIdentifier;
        }

        public override int DiscontPercentage
        {
            get
            {
                switch (_contryIdentifier)
                {
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }

    /// <summary>
    /// Implementation 2
    /// </summary>
    public class CodeDiscountService: DiscontService
    {
        private readonly Guid _code;
        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscontPercentage
        {
            get => 15;
        }
    }

    /// <summary>
    /// Creator
    /// </summary>
    public abstract class DiscountFactory
    {
        public abstract DiscontService CreateDiscountService();
    }

    /// <summary>
    /// Concrete create 1
    /// </summary>
    public class CountryDiscontFactory: DiscountFactory
    {
        private readonly string _contryIdentifier;
        public CountryDiscontFactory(string countryIdentifier)
        {
            _contryIdentifier = countryIdentifier;
        }

        public override DiscontService CreateDiscountService()
        {
            return new ContryDiscontService(_contryIdentifier);
        }
    }

    public class CodeDiscontFactory: DiscountFactory
    {
        private readonly Guid _code;
        public CodeDiscontFactory(Guid code)
        {
            _code = code;
        }

        public override DiscontService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }


}