using System;

namespace Builder;

class Program
{
    static void Main(string[] args)
    {
        var garage = new Garage();

        var miniBuilder = new MiniBuilder();
        var bwmBuilder = new BmwBuilder();

        garage.Construct(miniBuilder);
        garage.Show();

        garage.Construct(bwmBuilder);
        garage.Show();
    }
}
