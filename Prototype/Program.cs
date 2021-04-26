using System;
using System.Net.Sockets;

namespace Prototype
{
    /// <summary>
    /// Don't use ICloneable
    /// it creates a shallow copy of the objects and nested objects
    /// create a deep copy instead
    /// </summary>
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            Names.Clone()
            return new Person(Names, (Address)Address.Clone());
        }
    }

    public class Address :ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));
          var jane = (Person)john.Clone();
          jane.Address.HouseNumber = 320;
          
          Console.WriteLine(john);
          Console.WriteLine(jane);
        }
    }
}
