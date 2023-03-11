using System;
using System.Collections.Generic;

namespace Zad5
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Do wyboru 1 lub 2
            //1
            List<string> list = new List<string>();
            foreach(var l in WczytajLiczby().ZamienWg(x => x.ToString()))
            {
                list.Add(l);
            }

            foreach (var i in list)
                Console.WriteLine(i);
            //2
            /*foreach (var l in WczytajLiczby().ZamienWg(x => x.ToString()))
            {
                Console.WriteLine(l);
            }*/
        }

        public static IEnumerable<string> ZamienWg(this IEnumerable<int> enumerator, Func<int, string> l)
        {
            foreach (var i in enumerator)
            {
                yield return l(i);
            }
        }

        public static IEnumerable<int> WczytajLiczby()
        {
            while (true)
            {
                int x;
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch
                {
                    yield break;
                }
                yield return x;
            }
        }
    }
}
