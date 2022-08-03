using System;
using System.Collections.Generic;

namespace Lab_04
{
    internal class Program
    {
        static void Main()
        {
            ListaJednokierunkowa<Person> list1 = new();
            list1.Add(new Person("AAAAA",12));
            list1.Add(new Person("BBBBB", 21));
            list1.Add(new Person("CCCCC", 18));
            list1.Add(new Person("DDDDD", 11));
            list1.Add(new Person("EEEEE", 37));
            list1.Add(new Person("FFFFF", 45));
            list1.Add(new Person("GGGGG", 42));
            list1.Add(new Person("HHHHH", 84));
            list1.Add(new Person("IIIII", 17));
            list1.Add(new Person("JJJJJ", 69));
            foreach (var item in list1)
                item.Info();
            list1.Insert(2,new Person("ZZZZZ", 33));
            Console.WriteLine("==========");
            foreach (var item in list1)
                item.Info();
            Console.WriteLine("==========");
            list1.RemoveAt(2);
            foreach (var item in list1)
                item.Info();

            Console.WriteLine("==========");
            foreach (var item in list1)
            {
                if (item.Age >= 18)
                    item.Info();
            }
        }
    }
}
