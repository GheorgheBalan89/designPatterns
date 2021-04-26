using System;
using System.Collections.Generic;
using System.Linq;

namespace Factories
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
       

    }

    public interface IPersonFactory
    {
        Person CreatePerson(string name);
    }

    public class PersonFactory : IPersonFactory
    {
        private readonly List<Person> _persons = new List<Person>();

        public Person CreatePerson(string name)
        {
            var id = 0;
            if (_persons.Any())
            {
                id = _persons.Count;
            }
            var person = new Person(id, name);
            _persons.Add(person);
            return person;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var personFactory = new PersonFactory();
            Console.WriteLine(personFactory.CreatePerson("John").Id);
            Console.WriteLine(personFactory.CreatePerson("Jane").Id);
        }
    }

}
