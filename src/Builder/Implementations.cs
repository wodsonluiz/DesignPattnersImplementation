using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}. ");
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Builder
    /// </summary>
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    /// <summary>
    /// Concret Builder 1
    /// </summary>
    public class MiniBuilder: CarBuilder
    {
        public MiniBuilder(): base("Mini")
        {
            
        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a v8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with stripes'");
        }
    } 

    public class BmwBuilder: CarBuilder
    {
        public BmwBuilder(): base("BMW")
        {
            
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a fancy V8 engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }
     
    public class Garage
    {
        private CarBuilder _carBuilder;
        
        public void Construct(CarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
            _carBuilder.BuildEngine();
            _carBuilder.BuildFrame();
        }

        public void Show()
        {
            System.Console.WriteLine(_carBuilder.Car.ToString());
        }
    }
}