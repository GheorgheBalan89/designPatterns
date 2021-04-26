using System;

namespace Factories
{
    //the constructor becomes cumbersome when trying to initialize 2 objects with the same type of arguments
    //public enum CoordinateSystem
    //{
    //    Cartesian, 
    //    Polar
    //}
    //public class Point
    //{
    //    private double x, y;

    //    public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
    //    {
    //        switch (system)
    //        {
    //            case CoordinateSystem.Cartesian:
    //                x = a;
    //                y = b;
    //                break;
    //            case CoordinateSystem.Polar:
    //                x = a * Math.Cos(b);
    //                y = a * Math.Sin(a);
    //                break;
    //            default:
    //                throw new ArgumentOutOfRangeException(nameof(system), system, null);
    //        }
    //    }
    //}

    public class Point
    {
        //factory method - the name is not tied to the name of the class
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), theta * Math.Sin(rho));
        }
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var point = Point.NewPolarPoint(1.0, Math.PI / 2);
    //        Console.WriteLine(point);
    //    }
    //}
}
