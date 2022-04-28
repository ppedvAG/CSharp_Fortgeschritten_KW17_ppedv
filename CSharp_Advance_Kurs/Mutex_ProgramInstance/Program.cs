using System;
using System.Threading;

namespace Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;
        static void Main(string[] args)
        {
            if (IsSingleInstance())
            {
                Console.WriteLine("One Instance");


                foreach (string arg in args)
                    Console.WriteLine(arg); 
            }
            else
            {
                Console.WriteLine("More than one instance");
            }

            Console.ReadLine();
        }

        static bool IsSingleInstance()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                return false; //zweite Instance erkannt
            }
            else
            {
                //erster Programmstart
                mutex = new Mutex(false, "ABC");
                return true;
            }
        }

    }
}
