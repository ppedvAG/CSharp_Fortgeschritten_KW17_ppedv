using System;

namespace DelegatesActionsAndFuncsSamples
{

    //Delegate ist ein DatenTyp -> muss definiert werden
    //Delegate kann nur mit bestimmten Methoden zusammenarbeiten 

    //Welche Methoden wären das? 
    // Rückgabetype int / Methoden-Parameter (int) 
    delegate int ChangeNumber(int number);
    delegate void WriteLogDelegate(string msg);

    public class Program
    {
        static void Main(string[] args)
        {
            #region Delegate Beipsiel
            //Im Konstruktor eines ChangeNumber gehört der Name einer Methode (Funktionszeiger wird übergeben)
            ChangeNumber changeNumber = new ChangeNumber(ShowOffset5); //<- Funktionszeige wird von ShowOffset5 übergeben
            int offSetResult = changeNumber(7);


            //ein Delegate kann mehrere Funktionenzeiger aufnehmen. Allerdings arbeitet Multiple Delegates mit Methoden die ein void aufweisen

            WriteLogDelegate logDelegate = new WriteLogDelegate(LogToDB);
            logDelegate += LogToFile; // += Operator können wir weitere Funktionzeiger einem Delegate hinzufügen
            logDelegate("Schreibe ein Log");

            //und was ist mit Methoden, die ein Rückgabewert aufweisen? (Achtung Anti-Beispiel) 
            changeNumber += ShowOffset7;
            offSetResult = changeNumber(7); //Die letzte Methode liefert einen Rückgabewert
            #endregion

            #region Action-Delegate
            //Action kann NUR mit Methoden zusammenarbeiten, die ein void zurückgeben
            //Action kann mit Methoden zusammenarbeiten die bis zu 16 Parameter vorweisen können 

            Action<string> logAction = new Action<string>(LogToDB);
            logAction("schreibe eine Log-Message");

            //Hinzufügen einer weiteren Methoden mit += Operator
            logAction += LogToFile;
            logAction("schreibe eine Log zu mehreren Ziele");

            //Entfernen einer Methode mit -= Operator
            logAction -= LogToDB;
            logAction("schreibe ein nur in File´, nachdem wir LogToDB entfernt haben");
            #endregion

            #region Func
            //Func ist ein generisches Delegate, dass Rückgabewerte unterstützt 
            //Rückgabewert ist die letzte Stelle bei der Definition der Typen

            Func<int, int, string> addiereDelegate = new Func<int, int, string>(AddiereMitTextausgabe);
            string ausgabe = addiereDelegate(11, 22);

            Console.WriteLine(ausgabe);
            #endregion
        }

        #region Beispiel 1
        static int ShowOffset5(int zahl)
        {
            return zahl + 5;
        }

        //Verkürzte Schreibweise zu ShowOffset5
        static int ShowOffset7(int zahl)
            => zahl + 7;


        static string AddiereMitTextausgabe(int zahl1, int zahl2)
        {
            return $"{zahl1} + {zahl2} = {zahl1 + zahl2}";
        }
        #endregion


        #region Zweites Beispiel
        static void LogToDB(string message)
        {
            //.. schreibe in DB
        }

        static void LogToFile(string message)
        {

        }
        #endregion
    }
}
