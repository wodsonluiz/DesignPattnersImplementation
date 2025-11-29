using System;

namespace Strategy;

public class Program
{
    static void Main(string[] args)
    {
        var order = new Order("Wodson", 5, "VS License");
        order.Export(new CSVExportService());
        order.Export(new JsonExportService());
    }
}
