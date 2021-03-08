using System;

namespace TaskSingleton
{

    class Restaurant
    {
        public Chef Chef { get; set; }

        public void ToEmploy(string name)
        {
            Chef = Chef.getInstance(name);
        }
    }

    class Chef 
    {
        private static Chef instance;
        
        public string Name { get; private set; }

        protected Chef(string name)
        {
            Name = name;
        }

        public static Chef getInstance(string name)
        {
            if (instance == null)
            {
                instance = new Chef(name);
                Console.WriteLine("Новый шеф");
            }
            else 
                Console.WriteLine("Шеф уже сущестует");
           
            return instance;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var r = new Restaurant();
            r.ToEmploy("Вася");
            Console.WriteLine(r.Chef.Name);

            var r1 = new Restaurant();
            r1.ToEmploy("Петя");
            Console.WriteLine(r1.Chef.Name);

            r.ToEmploy("Леня");
            Console.WriteLine(r.Chef.Name);

        }
    }
}
