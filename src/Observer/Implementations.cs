using System;
using System.Collections.Generic;

namespace Observer
{
    public class TicketChange
    {
        public TicketChange(int artistId, int amount)
        {
            ArtistId = artistId;
            Amount = amount;
        }

        public int ArtistId { get; private set; }
        public int Amount { get; private set; }
    }

    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        public void AddObserver(ITicketChangeListener observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ITicketChangeListener observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach (var observer in _observers)
            {
                observer.ReceiveTicketChangeNotification(ticketChange);
            }
        }
    }

    /// <summary>
    /// Observer
    /// </summary>
    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }

    public class OrderService: TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            Console.WriteLine($"{nameof(OrderService)} is changing its state. ");
            Console.WriteLine($"{nameof(OrderService)} is notifying observers... ");
            Notify(new TicketChange(artistId, amount));
        }
    }

    public class TicketResellerService: ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change artist change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }

    public class TicketStockService: ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change artist change: artist {ticketChange.ArtistId}, amount {ticketChange.Amount}");
        }
    }

    
}