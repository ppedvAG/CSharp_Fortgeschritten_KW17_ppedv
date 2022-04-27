using System;
using System.Threading;

namespace _004_ThreadWithParametersAndReturnValues
{
    internal class Program
    {
        private static string retString = string.Empty;
        private static string meinText = "Hello World";

        static void Main(string[] args)
        {
            //Anonyme Methode ruft die Methode StringToUpper auf und diese gibt 'retString' alle Großbuchstaben von 'meinText'
            Thread thread = new Thread(() =>
            {
                //Achtung eine Anonyme Methode in einem Thread
                retString = StringToUpper(meinText);
            });

            //Thread Methode ruft Ausgelagerte Methode auf und wäre 
            Thread thread1 = new Thread(AusgelagerteMethode);
            thread1.Start();
            thread.Join();
        }


        //Alle String werden in Groß-Buchstaben
        private static string StringToUpper(string param)
            =>param.ToUpper();

        //VARIANTE 2 -> ohne Anonyme Methode
        public static void AusgelagerteMethode()
        {
            retString = StringToUpper(meinText);
        }
    }
}
