using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_04
{
    internal class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Info()
        {
            Console.WriteLine($"Imie: {Name} Wiek: {Age}");
        }

        public override string ToString()
        {
            return $"Imie: {Name} Wiek: {Age}";
        }
    }
}
