using System;
using System.Threading;

namespace _003_ThreadBeendenMitCancelationToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Sender
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(); //Sendestruktur

                //Empfänger
                CancellationToken cancellationToken = cancellationTokenSource.Token; //Es wird an der Empfängerstruktur, die Referenz übergeben (Referenztyp)

                ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas);

                Thread thread = new Thread(parameterizedThreadStart);
                thread.Start(cancellationToken); //MachEtwas wird gestartet

                Thread.Sleep(3000);
                cancellationTokenSource.Cancel(); //WEnn wir Cancel von der CancellationTokenSource aufrufen -> dann bekommt das cancellationToken.IsCancellationRequested mit
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("wird nie aufgerufen, Thread läuft in einem eigenen Kontext (hat eine eigene ThreadId");
            }
            Console.ReadLine();
        }


       
        private static void MachEtwas(object param) //Übergabe des CancellationToken Objekts
        {
            try
            {
                if (param is CancellationToken cancellationToken)
                {
                    //10 Sekunden mit Ausgabe 'zzZZZZzzzZZZ'

                    for (int i = 0; i < 50; i++)
                    {

                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested(); //OperationCanceldException wird danach geschmissen
                        }

                        Console.WriteLine("zzzzzZZZZZzzzzzZZZZZ");
                        Thread.Sleep(200);
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Thread wird beendet: " + ex.ToString());
            }

        }
    }
}
