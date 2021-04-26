using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class FuncBuilderExample
    {
        public class Person
        {
            public string Name, Position;
        }

        public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> 
                                                                 where TSubject : new()
        {
            private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

            private TSelf AddAction(Action<Person> action)
            {
                actions.Add(p =>
                {
                    action(p);
                    return p;
                });

                return (TSelf)this;
            }
            public TSelf Do(Action<Person> action) => AddAction(action);
            public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        }
        public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
        {
            public PersonBuilder Called(string name) => Do(p => p.Name = name);
        }
        //public sealed class PersonBuilder
        //{
        //    private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        //    private PersonBuilder AddAction(Action<Person> action)
        //    {
        //        actions.Add(p => { action(p);
        //            return p;
        //        });

        //        return this;
        //    }

        //    public PersonBuilder Do(Action<Person> action) => AddAction(action);

        //    public PersonBuilder Called(string name) => Do(p => p.Name = name);
        //    public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        //}

    }
    public static class PersonBuilderExtensions
    {
        public static FuncBuilderExample.PersonBuilder WorksAs
            (this FuncBuilderExample.PersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }

    public static class Program
    {
        public static void Run()
        {
            //var pb = new FuncBuilderExample.PersonBuilder();
            //var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();
            var person = new FuncBuilderExample.PersonBuilder().Called("Sarah").WorksAs("Developer").Build();
            Console.WriteLine(person);
        }
        //public static void Main(string[] args)
        //{
        //    Run();
        //}

    }

}
