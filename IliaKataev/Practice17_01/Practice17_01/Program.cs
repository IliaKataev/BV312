using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Practice17_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>
            {
                DateTime.Now,
                1,
                "ЧудоЙогурт",
                2.6,
            };

            Thread thread = new Thread(DoList);
            thread.Start(list);
            thread.Join();
            Console.WriteLine("Работа с потоком завершена");
            Console.ReadLine();
        }

        public static void DoList(object a)
        {
            if (a is List<object> collection)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine(item.ToString());
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("Object is not a collection");
            }
        }
    }
}
