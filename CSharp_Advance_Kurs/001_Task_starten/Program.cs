using System;
using System.Threading.Tasks;

namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MacheEtwasInEinemTask); //Funktionzeiger wird übergeben

            task.Start();

            task.Wait(); //wir können warten, bis der Task zuende ist 

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");

            Console.ReadLine();
        }

        private static void MacheEtwasInEinemTask()
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
