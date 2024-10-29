using System.IO;
using System.Text.Json;

namespace Prototype
{
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone);
    }

    public class Manager : Person
    {
        public override string Name { get; set; }

        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone = false)
        {
            if(deepClone)
            {
                var objctAsJson = JsonSerializer.Serialize(this);
                return JsonSerializer.Deserialize<Manager>(objctAsJson);
            }
              
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public override string Name { get; set; }
        public Manager Manager { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person Clone(bool deepClone = false)
        {
            if(deepClone)
            {
                var objctAsJson = JsonSerializer.Serialize(this);
                return JsonSerializer.Deserialize<Employee>(objctAsJson);
            }

            return (Person)MemberwiseClone();
        }
    }
}