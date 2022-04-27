using System;
using System.Threading;

namespace _006_ThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Verfügbare Thread, die sofort ausgeführt geführt 

            //Wir können die Maximale verfügbare Threadanzahl festlegen kann 
            ThreadPool.SetMaxThreads(1, 1);

            ThreadPool.QueueUserWorkItem(Methode1, 123);
            ThreadPool.QueueUserWorkItem(Methode2);

            Console.WriteLine(ThreadPool.ThreadCount); 
            ThreadPool.QueueUserWorkItem(Methode3);

            ThreadPool.QueueUserWorkItem(Methode1);
            Console.WriteLine(ThreadPool.ThreadCount);
            ThreadPool.QueueUserWorkItem(Methode1);
            Console.WriteLine(ThreadPool.ThreadCount);
            ThreadPool.QueueUserWorkItem(Methode1);
            Console.WriteLine(ThreadPool.ThreadCount);
            ThreadPool.QueueUserWorkItem(Methode1);
            Console.WriteLine(ThreadPool.ThreadCount);
            ThreadPool.QueueUserWorkItem(Methode1);

            Console.ReadLine();

        }


        static void Methode1(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {
                
                Console.WriteLine("#");
            }
        }

        static void Methode2(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {
                
                Console.WriteLine("+");
            }
        }

        static void Methode3(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {
                
                Console.WriteLine("%");
            }
        }
    }
}
