using System;
using System.Threading;

namespace _003_Thread_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread thread = new Thread(MachEtwas);
                thread.Start();

                Thread.Sleep(3000); //Wir warten 3 Sekunden


                //thread.Abort();
                //Achtung Harter Breaking Change -> thread.Abort(); //Abort() -> throw new PlatformNotSupportedException 

                thread.Interrupt(); // -> ThreadInterruptedException

                Console.WriteLine("Main Methode ist fertig");
            }
            catch (ThreadInterruptedException ex) 
            {
                Console.WriteLine("Wird niemals aufgerufen, weil der Thread in einem eigenen Context arbeitet und dort wird ThreadInterruptedException geschmissen");
            }
            
            Console.ReadLine();
        }



        //Thread arbeitet in einem eigenen Context -> eigene ThreadID 

        //Dauer dieser Methode 10Sekunden
        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("zzzZZZZzzzzzZZZZZZzzzzZZ");
                    Thread.Sleep(200);
                }
            }
            catch (ThreadInterruptedException ex) //von von thread.Interrupt eskaliert
            {
                Console.WriteLine("Methode wurde mit Interrupt (von außen) beendet" + ex.Message);
            }
        }
    }
}
