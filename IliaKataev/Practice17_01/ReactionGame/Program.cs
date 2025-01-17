using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactionGame
{
    internal class Program
    {
        private static bool signal = false;
        private static Stopwatch timer = new Stopwatch();
        private static Thread thread;
        static void Main(string[] args)
        {
            //Блок для текстового описания игры см. п1.1 и п1.2
            Console.ReadLine();
            while(true)
            {
                signal = false;
                Console.Clear();

                thread = new Thread(ShowSignal);
                thread.Start();

                
            }
        }

        private static void ShowSignal()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(3000, 7000));
            signal = true;
            Console.WriteLine("Нажмите кнопку!!!!");
            timer.Start();
        }
    }
}
