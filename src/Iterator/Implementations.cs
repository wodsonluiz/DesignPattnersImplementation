using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Person(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    /// <summary>
    /// Iterator
    /// </summary>
    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person Person { get; }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    public class PeopleIterator : IPeopleIterator
    {
        private readonly PeopleCollection _collection;
        private int _current = 0;

        public PeopleIterator(PeopleCollection collection)
        {
            _collection = collection;
        }

        public bool IsDone => _current >= _collection.Count;

        public Person Person => _collection.OrderBy(p => p.Name).ToList()[_current];

        public Person First()
        {
            _current = 0;
            return _collection.OrderBy(p => p.Name).ToList()[_current];
        }

        public Person Next()
        {
            _current++;

            if(!IsDone)
            {
                return _collection.OrderBy(p => p.Name).ToList()[_current];
            }

            return null;
        }
    }

}