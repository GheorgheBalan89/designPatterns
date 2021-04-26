using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BuilderPattern
{
    public class FacetedBuilderExample
    {
        public class Person
        {
            //address
            public string StreetAddress, PostCode, City;
            
            //employment
            public string CompanyName, Position;
            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }
        public class PersonBuilder //Facade
        {
            //reference!
            protected Person person = new Person();
            public PersonJobBuilder Works => new PersonJobBuilder(person);
            public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

            public static implicit operator Person(PersonBuilder pb)
            {
                return pb.person;
            }
        }
        public class PersonAddressBuilder: PersonBuilder
        {
            public PersonAddressBuilder(Person person)
            {
                this.person = person;
            }

            public PersonAddressBuilder At(string streetAddress)
            {
                person.StreetAddress = streetAddress;
                return this;
            }

            public PersonAddressBuilder WithPostcode(string postcode)
            {
                person.PostCode = postcode;
                return this;
            }

            public PersonAddressBuilder In(string city)
            {
                person.City = city;
                return this;
            }
        }
        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person)
            {
                this.person = person;
            }

            public PersonJobBuilder At(string companyName)
            {
                person.CompanyName = companyName;
                return this;
            }

            public PersonJobBuilder AsA(string position)
            {
                person.Position = position;
                return this;
            }

            public PersonJobBuilder Earning(int amount)
            {
                person.AnnualIncome = amount;
                return this;
            }
        }

        
        public static void Run()
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives.At("123 London Road")
                    .In("London")
                    .WithPostcode("123LON")
                .Works.At("SimCorp")
                    .AsA("Software developer")
                    .Earning(500000);

            Console.WriteLine(person.ToString());
        }

        public static void Main(string[] args)
        {
            Run();
        }
    }
}
