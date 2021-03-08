using System;
using System.Collections.Generic;
using System.Text;

namespace TaskBuilder
{
    public class CodeElement
    {
        public string name, type;
        public List<CodeElement> elements = new List<CodeElement>();

        private const int _indenSize = 2;

        public CodeElement() { }

        public CodeElement(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indent * _indenSize);

            if (indent == 0)
            {
            sb.Append($"public class {name} \n");
            sb.Append("{\n");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                sb.Append(new string(' ', indent * _indenSize));
                sb.AppendFormat($"public {type} {name};\n");
            }

            foreach (var e in elements)
                sb.Append(e.ToStringImpl(1));

            if (indent == 0)
                sb.Append('}');

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }

    public class CodeBuilder
    {
        private readonly string rootName;
        protected CodeElement root = new CodeElement();

        public CodeBuilder(string rootName)
        {
            this.rootName = rootName;
            root.name = rootName; 
        }

        public CodeBuilder AddChild(string childName, string childType)
        {
            var e = new CodeElement(childName, childType);
            root.elements.Add(e);
            return this;
        }
  
        public override string ToString()
        {
            return root.ToString();
        }
        
    }


    class Builder
    {
        static void Main(string[] args)
        {
            var builder = new CodeBuilder("Person");
            builder.AddChild("name", "string").AddChild("age", "string");
            Console.WriteLine(builder.ToString());
        }
    }
}
