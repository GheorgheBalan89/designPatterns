using System;
using System.Threading.Tasks;

namespace Factories
{
   
    public class CoordinatePoint
    {
        //factory method - the name is not tied to the name of the class

        private double x, y;

        //internal  can be used within the assembly but not directly
        private CoordinatePoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static CoordinatePoint Origin => new CoordinatePoint(0,0);

        public static CoordinatePoint Origin2 = new CoordinatePoint(0,0); 

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        public static class Factory
        {
            public static CoordinatePoint NewCartesianPoint(double x, double y)
            {
                return new CoordinatePoint(x, y);
            }

            public static CoordinatePoint NewPolarPoint(double rho, double theta)
            {
                return new CoordinatePoint(rho * Math.Cos(theta), theta * Math.Sin(rho));
            }
        }
    }

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var point = CoordinatePoint.Factory.NewPolarPoint(1.0, Math.PI / 2);
    //        Console.WriteLine(point);

    //        var origin = CoordinatePoint.Origin;

    //    }
    //}
}
