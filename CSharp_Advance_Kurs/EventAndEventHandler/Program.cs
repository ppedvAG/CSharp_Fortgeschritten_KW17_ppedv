using System;

namespace EventAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgressBar1 progressBar1 = new ProgressBar1();
            progressBar1.ChangePercentValue += ProgressBar1_ChangePercentValue; //Funktionzeiger wird an ChangePercentValue übetragen 
            progressBar1.ResultCompletedDelegate += ProgressBar1_ResultCompletedDelegate; //Funktionzeiger wird an ResultCompletedDelegate übetragen 

            progressBar1.StartProcess();
        }

        private static void ProgressBar1_ChangePercentValue(int percentValue)
        {
            Console.WriteLine(percentValue);
        }


        //Wie komme ich zu dieser Methode ->

        /*
         *  protected virtual void OnProcessPercentStatus(int perconet)
            {
                ChangePercentValue?.Invoke(perconet); //Jetzt teilen wir nach außen mit, dass es ein neuer Prozentwert gibt
            }
         */
        private static void ProgressBar1_ResultCompletedDelegate(string msg)
        {
            Console.WriteLine(msg);
        }

      
    }
}
