using System;

namespace Iterator;

class Program
{
    static void Main(string[] args)
    {
        //create collection
        PeopleCollection people = new();

        people.Add(new Person("Wodson Correia", "Brazil"));
        people.Add(new Person("Joao Correia", "Brazil"));
        people.Add(new Person("Maria Correia", "Brazil"));
        people.Add(new Person("Nubia Correia", "Brazil"));

        //create iterator
        var peopleIterator = people.CreateIterator();

        for(Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
        {
            Console.WriteLine(person?.Name);
        }
    }
}
