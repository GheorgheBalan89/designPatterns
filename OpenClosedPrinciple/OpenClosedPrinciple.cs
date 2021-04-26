using System;
using System.Collections.Generic;

namespace OpenClosedPrinciple
{
    public class OpenClosedPrinciple
    {
        public enum  Color
        {
            Red, Green, Blue
        }
        public enum Size
        {
            Small, Medium, Large, XLarge
        }

        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;

            public Product(string name, Color color, Size size)
            {
                Name = name ?? throw new ArgumentNullException(paramName:nameof(name));
                Color = color;
                Size = size;
            }
        }

        public class ProductFilter
        {
            public  IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var p in products)
                {
                    if (p.Size == size)
                    {
                        yield return p;
                    }
                }
            }
            public  IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var p in products)
                {
                    if (p.Color == color)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
            {
                foreach (var p in products)
                {
                    if ( p.Size == size && p.Color == color)
                    {
                        yield return p;
                    }
                }
            }

        }
        //open -closed principle: a class should be open for extension, but closed for modification
        //respects open - closed principle
        public interface ISpecification<T>
        {
            bool IsSatisfied(T type);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;

            public ColorSpecification(Color color)
            {
                this.color = color;
            }
            public bool IsSatisfied(Product type)
            {
                return type.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;

            public SizeSpecification(Size size)
            {
                this.size = size;
            }
            public bool IsSatisfied(Product type)
            {
                return type.Size == size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first ?? throw new ArgumentNullException(nameof(first));
                this.second = second ?? throw new ArgumentNullException(nameof(second));
            }
            public bool IsSatisfied(T type)
            {
                return first.IsSatisfied(type) && second.IsSatisfied(type);
            }
        }
        public class DynamicFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var i in items)
                {
                    if (spec.IsSatisfied(i))
                    {
                      yield return i;
                    }
                }
            }
        }

        public class Demo
        {
            static void Main(string[] args)
            {
                var apple = new Product("Apple", Color.Green, Size.Small);
                var tree = new Product("Tree", Color.Green, Size.Large);
                var house = new Product("House", Color.Blue, Size.Large);

                Product[] products = new[] {apple, tree, house};
                var pf = new ProductFilter();

                Console.WriteLine("Green products (old): ");
                foreach (var p in pf.FilterByColor(products, Color.Green))
                {
                    Console.WriteLine($"Color is {p.Color}");
                }

                var df = new DynamicFilter();
                Console.WriteLine("Green products (new) :");
                foreach (var p in df.Filter(products, new ColorSpecification(Color.Green)))
                {
                    Console.WriteLine($"Color is {p.Color}");
                }

                Console.WriteLine("Large blue items");

                foreach (var p in df.Filter(products, new AndSpecification<Product>( new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))) )
                {
                    Console.WriteLine($" - {p.Name} is big and blue");
                }
            }
        }
    }
}
