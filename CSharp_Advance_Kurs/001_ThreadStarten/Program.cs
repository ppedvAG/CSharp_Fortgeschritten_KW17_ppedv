using System;
using System.Threading;

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Threading.Thread;
            Thread thread = new Thread(MachEtwasInEinemThread); //Funktionszeiger wird von der Methode 'MachEtwasInEinemThread' übergeben
            thread.Start(); //Main-Methode und MachEtwasInEinemThread werden 'parallel' ausgeführt

            //Wenn wir erzwingen wollen, dass der Thread zuerst abgearbeitet wird 
            thread.Join(); //-> Main-Methode wartet hier bis MacheEtwasInEinemThread fertig ist

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }

    }
}
