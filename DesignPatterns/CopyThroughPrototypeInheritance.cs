using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class CopyThroughPrototypeInheritance
    {
        public interface IDeepCopyable<T> where T : new()
        {
            void CopyTo(T target);

            public T DeepCopy()
            {
                T t = new T();
                CopyTo(t);
                return t;
            }
        }
        public class Address : IDeepCopyable<Address>
        {
            public string StreetName;
            public int HouseNumber;

            public Address()
            {
                
            }
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }

            public void CopyTo(Address target)
            {
                target.StreetName = StreetName;
                target.HouseNumber = HouseNumber;
            }
        }

        public class Person : IDeepCopyable<Person>
        {
            public string[] Names;
            public Address Address;

            public Person()
            {
                
            }
            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
            }

            public void CopyTo(Person target)
            {
                target.Names = (string[]) Names.Clone();
                //target.Address = Address.DeepCopy();
            }
        }

        public class Employee : Person, IDeepCopyable<Employee>
        {
            public int Salary;

            public Employee()
            {
                
            }

            public Employee(int salary)
            {
                Salary = salary;
            }
            public override string ToString()
            {
                return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
            }

            public void CopyTo(Employee target)
            {
                base.CopyTo(target);
                target.Salary = Salary;
            }
        }
    }
}
