using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15._01._2025_Theory
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //Пример работы Thread
            //ThreadStart threadstart = new ThreadStart(ThreadMethod);
            //Thread thread = new Thread(threadstart);

            //thread.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine("Hello in main");
            //}

            //-------------------------------------------------------------------------------

            //Пример работы Thread c данными

            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(ThreadNew);
            //Thread thread1 = new Thread(threadStart);
            //thread1.Start((object)"One");
            //Thread thread2 = new Thread(threadStart);
            //thread2.Start((object)"\t\t\tTwo");

            //-------------------------------------------------------------------------------

            //Привер работы метода Sleep
            //Console.WriteLine("Main thread стартовал");

            //Thread thread = new Thread(Do);

            //thread.Start();

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"основной thread {i}");
            //    Thread.Sleep(1000);
            //}

            //thread.Join();
            //Console.WriteLine("Main thread завершился");

            //-------------------------------------------------------------------------------

            //Пример остановки потока с помощью метода Suspend/Resume

            //ThreadStart threadStart = new ThreadStart(SuspendResume);
            //Thread t = new Thread(threadStart);
            //t.Start();

            //Console.WriteLine("Нажмите, чтобы остановить поток");

            //Console.ReadKey();
            //t.Suspend(); //t.Abort();
            //Console.WriteLine("остановился поток");

            //Console.WriteLine("Нажмите, чтобы возобновить поток");
            //Console.ReadKey();
            //t.Resume();

            //-------------------------------------------------------------------------------

            //Пример работы c приоритетностью потоков
            ParameterizedThreadStart ts = new ParameterizedThreadStart(PMethod);
            Thread t1 = new Thread(ts);
            Thread t2 = new Thread(ts);

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t2.Start((object)"\t\t\tt2");
            t1.Start((object)"t1");

            //-------------------------------------------------------------------------------

            //Пример работы класса Timer
            //TimerCallback callback = new TimerCallback(TimerMethod);
            //Timer timer = new Timer(callback);
            //timer.Change(2000, 2000);
            //Console.ReadLine();
            //timer.Dispose();
            //Console.WriteLine("Таймер остановился");
            Console.ReadLine();
        }

        public static void TimerMethod(object a)
        {
            Console.WriteLine("Hello world!!!1");
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("\t\t\tHello in thread");
            }
        }

        public static void ThreadNew(object a)
        {
            string ID = (string)a;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(ID);
            }
        }

        public static void Do()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\t\t\tрабочий thread {i}");
                Thread.Sleep(2000);
            }
        }

        public static void SuspendResume()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        public static void PMethod(object str)
        {
            string text = (string)str;

            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine("{0} #{1}", text, i.ToString());
            }
        }
    }
}
