using System;
using System.Threading.Tasks;

namespace _007_ContinueWithParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Beispiel 1
            Task<string> task = Task.Run(DayTime);
            task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            #endregion

            #region Beispiel 2
            Task<string> folgeTask = task.ContinueWith<string>(task => GiveMessage(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            folgeTask.ContinueWith(folgeTask => ShowDayTime(folgeTask.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            #endregion
            Console.ReadLine();
        }


        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now; //Aktuelle Uhrzeit ermitteln wird

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static string GiveMessage(string daytime)
        {
            if (daytime == "evening")
                return "Guten Abend";
            else if(daytime == "afternoon")
                return "Guten Nachmittag";
            else  
                return "Guten Morgen";

        }

        public static void ShowDayTime(string result)
            => Console.WriteLine(result + " liebe Teilnehmer");
    }
}
