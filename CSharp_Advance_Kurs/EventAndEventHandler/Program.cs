using EventAndEventHandler.Components;
using System;

namespace EventAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Beispiel 1
            ProgressBar1 progressBar1 = new ProgressBar1();
            progressBar1.ChangePercentValue += ProgressBar1_ChangePercentValue; //Funktionzeiger wird an ChangePercentValue übetragen 
            progressBar1.ResultCompletedDelegate += ProgressBar1_ResultCompletedDelegate; //Funktionzeiger wird an ResultCompletedDelegate übetragen 

            progressBar1.StartProcess();
            #endregion

            ProgressBar2 progressBar2 = new ProgressBar2();
            //progressBar2.PercentValueChanged += ProgressBar2_PercentValueChanged;
            progressBar2.ProcessCompleted += ProgressBar2_ProcessCompleted;
            progressBar2.StartProcess();
        }

       



        #region Beispiel ProgressBar1
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
        #endregion

        private static void ProgressBar2_PercentValueChanged(object sender, EventArgs e)
        {
            MyPercentEventArgs percentEventArgs = (MyPercentEventArgs)e;

            Console.WriteLine(percentEventArgs.PercentValue);
        }

        private static void ProgressBar2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("ProgressBar ist fertig");
        }


    }
}
