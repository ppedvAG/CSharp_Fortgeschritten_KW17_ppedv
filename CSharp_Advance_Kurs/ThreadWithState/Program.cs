using System;
using System.Threading;

namespace ThreadWithState
{
    public delegate void MyResultDelegate(MyReturnObject myReturnObject);
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState threadWithState = new ThreadWithState("Hallo liebe Teilnehmer", 111, new MyResultDelegate(ResultCallback));

            Thread thread = new Thread(threadWithState.ThreadProc);
            thread.Start();

            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }


        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewerte-> {myReturnObject.Text} und {myReturnObject.Zahl}");
        }
            
    }

    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;

        private MyResultDelegate resultDelegate; // -> Funktionszeiger von ->  public static void ResultCallback(MyReturnObject myReturnObject)


        //Parameterübergabe 
        public ThreadWithState(string text, int zahl, MyResultDelegate myResultDelegate) //myResultDelegate hat den Funktionszeiger ->  public static void ResultCallback(MyReturnObject myReturnObject)
        {
            myStringText = text;
            myNumberValue = zahl;

            resultDelegate = myResultDelegate;
        }


        //Diese Methode läuft innerhalb eines Thread und gibt via Callback zurück, wann Sie fertig ist und beschenkt uns mit einer RückgabeKlasse (MyReturn Object)die Text und Zahl beinhaltet
        public void ThreadProc()
        {
            //Rechenintensives.... 

            MyReturnObject myReturnObject = new MyReturnObject();
            myReturnObject.Text = myStringText;
            myReturnObject.Zahl = myNumberValue;

            if (resultDelegate != null) 
                resultDelegate(myReturnObject); //Wir callen ResultCallback 
        }
    }


    //Dieses Objekt benötigen wir um das Ergebnis aus ThreadProc zurück zugeben
    public class MyReturnObject
    {
        public MyReturnObject()
        {

        }

        public string Text { get; set; }    
        public int Zahl { get; set; }   
    }
}
