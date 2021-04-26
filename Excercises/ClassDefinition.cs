using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excercises
{
    

    public class CodeBuilder
    {
        public class ClassDefinition
        {
            public string ClassName;
            public List<Property> Properties;


            public ClassDefinition()
            {

            }
            public ClassDefinition(string className, IEnumerable<Property> properties)
            {
                ClassName = className ?? throw new ArgumentNullException(nameof(className));
                Properties = properties.ToList() ?? throw new ArgumentNullException(nameof(properties));

            }

            public string ToFormattedString(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', 1);
                sb.AppendLine($"public class {ClassName}");
                sb.AppendLine("{");
                foreach (var prop in Properties)
                {
                    sb.AppendLine($"{i} public {prop.Type} {prop.FieldName};");
                }

                sb.AppendLine("}");
                return sb.ToString();
            }
            public override string ToString()
            {
                return ToFormattedString(0);
            }
        }

        public class Property
        {
            public string FieldName, Type;

            public Property()
            {

            }
            public Property(string fieldName, string type)
            {
                FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
                Type = type ?? throw new ArgumentNullException(nameof(type));
            }
        }
        readonly ClassDefinition _classDef = new ClassDefinition();
        private readonly string _className;

        public CodeBuilder(string className)
        {
            _className = className ?? throw new ArgumentNullException(nameof(className));
            _classDef.ClassName = className;
            _classDef.Properties = new List<Property>();
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            var property = new Property(fieldName, fieldType);
            _classDef.Properties.Add(property);
            return this;
        }

        public override string ToString()
        {
            return _classDef.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb.ToString());
        }
    }
}
