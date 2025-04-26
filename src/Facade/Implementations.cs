using System;
using Microsoft.VisualBasic;

namespace Facade
{
    /// <summary>
    /// Subsystem class
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            return (customerId > 5);
        }
    }

    /// <summary>
    /// Subsytem class
    /// </summary>
    public class CustomerDiscontBaseService
    {
        public double CalculateDiscontBase(int customerId)
        {
            return (customerId > 8) ? 10 : 20;
        }
    }

    /// <summary>
    /// Subsystem class
    /// </summary>
    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            switch (DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    return 1.2;
            }
        }
    }

    /// <summary>
    /// Facade
    /// </summary>
    public class DiscontFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscontBaseService _customerDiscontBaseService = new();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

        public double CalculateDiscontPercentage(int customerId)
        {
            if(!_orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }

            return _customerDiscontBaseService.CalculateDiscontBase(customerId) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }
    }

}