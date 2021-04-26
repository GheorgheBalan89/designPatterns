using System;

namespace DesignPatterns
{
    public class Observer
    {
        public class FallsIllEventArgs
        {
            public string Address;
        }
        public class Person
        {
            public void CatchACold()
            {
                FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "123 London Rd" });
            }
            public event EventHandler<FallsIllEventArgs> FallsIll;
        }
        //static void Main(string[] args)
        //{
        //    var person = new Person();
        //    person.FallsIll += CallDoctor;
        //    person.CatchACold();
        //    person.FallsIll -= CallDoctor;
        //}

        private static void CallDoctor(object? sender, FallsIllEventArgs e)
        {
           Console.WriteLine($"A doctor has been called to {e.Address}");
        }
    }
}
