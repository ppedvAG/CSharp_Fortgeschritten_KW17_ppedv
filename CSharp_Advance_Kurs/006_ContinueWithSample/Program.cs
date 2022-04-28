using System;
using System.Threading.Tasks;

namespace _006_ContinueWithSample
{
    internal class Program
    {
        private static int[] Lottozahlen = new int[7];

        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                //Anonyme Methode 
                Console.WriteLine("Task 1 arbeitet");
                Lottozahlen[0] = 2;
                Lottozahlen[1] = 12;
                Lottozahlen[2] = 22;
                Lottozahlen[3] = 32;
                Lottozahlen[4] = 42;
                Lottozahlen[5] = 52;
                Lottozahlen[6] = 62;

                throw new Exception();
            });


            t1.Start();

            t1.ContinueWith(t => AllgemeinerFolgetask());
            t1.ContinueWith(t => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);
            t1.ContinueWith(t => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadLine(); //Main Task wartet hier
        }

        private static void AllgemeinerFolgetask()
        {
            Console.WriteLine("Ich muss immer augerufen werden ");
        }

        private static void FolgetaskBeiErfolg()
        {
            //Workflow? Transaction->Comit 
            Console.WriteLine("Ich werde aufgerufen, wenn der vorige Task ohne Fehler durchgelaufen ist");
        }

        private static void FolgetaskBeiFehler()
        {
            //Workflow? Transaction->Rollback 
            //SqlConnection -> Dispose();
            Console.WriteLine("Ich werde aufgerufen, wenn der vorige Task einen Fehler verursacht hat");
        }
    }
}
