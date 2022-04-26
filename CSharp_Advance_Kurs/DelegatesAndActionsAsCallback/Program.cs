using System;

namespace DelegatesAndActionsAsCallback
{
    public delegate void ResultDelegate(string msg);
    public delegate void PercentChangeDelegate(int percent);


    internal class Program
    {
        static void Main(string[] args)
        {
            MyApp app = new MyApp(); //Objekt MyApp liegt im Arbeitsspeicher vor + der Methode app.Result (diese hat eine Funktion-Adresse)
            
            ResultDelegate resultDelegate = new ResultDelegate(app.ShowResult); //ShowResult Funktionszeiger wird übergeben
            PercentChangeDelegate percentChangeDelegate = new PercentChangeDelegate(app.ShowPercent);//ShowPercent Funktionszeiger wird übergeben


            Process(percentChangeDelegate, resultDelegate);
        }

        public static void Process(PercentChangeDelegate percentChangeDelegate, ResultDelegate resultDelegate)
        {
            
            for (int i = 0; i <= 100; i++)
            {
                //Wollen wir unserem Programm MyApp mitteilen, welcher Prozentwert die Berechnung erreicht hat

                percentChangeDelegate(i);
            }


            //Callback -> Wir sagen MyApp, dass die Berechnung fertig ist
            resultDelegate("sind mit der Methode Program.Process fertig");
        }
    }

    public class MyApp
    {
        public void ShowResult(string msg)
            => Console.WriteLine(msg);
        
        public void ShowPercent(int percent)
            => Console.WriteLine(percent);
    }
}
