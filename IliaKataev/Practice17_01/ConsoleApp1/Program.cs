using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Sber", 10000, 15);

            bank.Name = "Alpha";
            bank.Money = 5;
            bank.Percent = 5;

            Console.WriteLine("Изменения внесены");
            Console.ReadLine();
            
        }
    }
}
