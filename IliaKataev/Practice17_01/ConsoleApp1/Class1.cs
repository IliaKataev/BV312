using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bank
    {
        private string name;
        private int money;
        private int percent;
        private readonly object objectForLock = new object();

        public int Money
        {
            get => money;
            set 
            {
                money = value;
                StartThread();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                StartThread();
            }
        }

        public int Percent
        {
            get => percent;
            set
            {
                percent = value;
                StartThread();
            }
        }

        public Bank(string name, int money, int percent)
        {
            this.name = name;
            this.money = money;
            this.percent = percent;
        }

        private void StartThread()
        {
            Thread loggingThread = new Thread(logToFile);
            loggingThread.Start();
            loggingThread.Join();
        }

        private void logToFile()
        {
            lock (objectForLock)
            {
                try
                {
                    string path = "logForBank.txt";
                    string logData = $"\n[{DateTime.Now}] Name: {Name}, Money: {Money}, Percent: {Percent}";
                    File.AppendAllText(path, logData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errorr!!! Ошибка записи данных в файл: {ex.Message}"); 
                }
            }
        }
    }
}
