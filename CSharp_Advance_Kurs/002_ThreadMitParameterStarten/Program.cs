using System;
using System.Threading;

namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Wrapper-Klasse die angibt, dass wir einen Parameter in einem Thread verwenden
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread thread = new Thread(parameterized);
            thread.Start(600);
            
            //thread.Join(); //Zuerst wird die Methode MachEtwasInEinemThread abgearbeitet und danach der Rest der Main-Methode
            
            for (int i = 0; i <= 600; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread(object obj) //Wert 600 wird als Parameter übergeben 
        {
            if (obj is int until) //Wenn die Variable obj ein integer ist, wird diese in die Variable until gecastet
            {
                for (int i = 0; i <= until; i++)
                {
                    Console.WriteLine(i.ToString() + " #");
                }
            }
        }
    }
}
