using System.Linq.Expressions;

namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        var ticketStockService = new TicketStockService();
        var ticketResellerService = new TicketResellerService();
        var orderService = new OrderService();

        //Add two observes
        orderService.AddObserver(ticketStockService);
        orderService.AddObserver(ticketResellerService);

        // notify
        orderService.CompleteTicketSale(1, 2);

        // remove one observer
        orderService.RemoveObserver(ticketResellerService);

        // notify
        orderService.CompleteTicketSale(2, 4);
    }
}
