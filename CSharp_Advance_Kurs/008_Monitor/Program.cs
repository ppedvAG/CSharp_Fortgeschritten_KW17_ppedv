using System;
using System.Threading;

namespace _008_Monitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1;

            if (Monitor.TryEnter(x)) //Flag wird gesetzt
            {
                try
                {
                    //Deadlock potenzieller Code
                }
                finally
                {
                    Monitor.Exit(x);
                }


                //Alternativ
                CleanRessoure(x);
            }
        }

        private static void CleanRessoure(int x)
        {
            Monitor.Exit(x);
        }
    }
}
