using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4.0 -> Task 

            Task task = Task.Factory.StartNew(MacheEtwasInEinemThread); //Task wird sofort gestartet 
            task.Wait();

            //.NET 4.5 eine verkürzte Schreibvariante angeboten 
            Console.WriteLine("Starte Taks.Run(....)");
            Task.Run(MacheEtwasInEinemThread);

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }


        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");
        }
    }
}
