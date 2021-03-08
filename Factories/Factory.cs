using System;

namespace TaskFactory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public void Print()
        {
            Console.WriteLine($"ID - {Id} Name - {Name}");
        }
    }

    public class FactoryPerson
    {
        static int id = 0;

        public static Person Create(string name)
        {
            Person pr = new Person();
            pr.Id = id;
            pr.Name = name;
            id++;

            return pr;
        }

    }

    class Factory
    {
        static void Main(string[] args)
        {
            var pr1 = FactoryPerson.Create("Vova");
            var pr2 = FactoryPerson.Create("Jora");
            var pr3 = FactoryPerson.Create("Vasia");

            pr1.Print();
            pr2.Print();
            pr3.Print();
        }
    }
}
