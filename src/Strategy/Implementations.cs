using System;

namespace Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            System.Console.WriteLine($"Exporting {order.Name} to json ");
        }
    }

    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            System.Console.WriteLine($"Exporting {order.Name} to xml ");
        }
    }

    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            System.Console.WriteLine($"Exporting {order.Name} to csv ");
        }
    }

    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public IExportService ExportService { get; set; }

        public Order(string customer, int amount, string name)
        {
            Customer = customer;
            Amount = amount;
            Name = name;

            // value default
            //ExportService = new CSVExportService();
        }

        public void Export(IExportService exportService)
        {
            if(exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }
            
            exportService.Export(this);
        }
    }
}