namespace Adapter;
//namespace Adapter; ## caso queira usar a variação do padrão em ClassAdapterImplementations.cs

class Program
{
    static void Main(string[] args)
    {
        ICityAdapter adapter = new CityAdapter();
        var city = adapter.GetCity();

        System.Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
    }
}
