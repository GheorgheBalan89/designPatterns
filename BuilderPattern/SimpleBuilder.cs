using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public HtmlElement()
        {
            
        }
        public string ToStringImplementation(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImplementation(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");


            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImplementation(0);
        }
    }

    public class HtmlBuilder
    {
        HtmlElement root = new HtmlElement();
        private readonly string rootName;

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName ?? throw new ArgumentNullException(nameof(rootName));
            root.Name = rootName;
        }

        //allows method chaining => fluent interface
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement(){Name = rootName};
        }
    }
    public class SimpleBuilder
    {
        public static void Run()
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");

            var words = new[] { "hello", "world" };
            sb.Clear();

            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            Console.WriteLine(sb.ToString());

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }
        //public static void Main(string[] args)
        //{
        //    Run();
        //}
    }
}
