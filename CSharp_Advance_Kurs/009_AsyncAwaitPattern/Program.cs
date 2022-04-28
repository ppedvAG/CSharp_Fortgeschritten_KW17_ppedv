using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;


//using System.Data.SqlClient -> früheres Namespace um eine Datenbankverbindung mit MSSQL herzustellen 
namespace _009_AsyncAwaitPattern
{
    internal class Program
    {

        //async wird in der Methodendefinition geschrieben, wenn ein await innerhalb des Methodenbodys aufgerufen wird
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("");


            #region Methoden mit void
            //Task, wie wir es kennen
            Task task = sqlConnection.OpenAsync();
            task.Wait();
            
            
            SqlCommand command = new SqlCommand("select * From Countries", sqlConnection);
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            
            Task<SqlDataReader> sqlDataReaderTask = command.ExecuteReaderAsync();
            SqlDataReader sqlDataReader = sqlDataReaderTask.Result;

            SqlDataReader sqlDataReader2 = await command.ExecuteReaderAsync();

            //await 
            await sqlConnection.OpenAsync();
            #endregion


            #region Methode mit Rückgabewert

            //TASK-Beispiel
            Task<string> taskWithResult = Task.Run(DayTime);
            taskWithResult.Wait();
            string result1 = taskWithResult.Result;


            //await
            string result2 = await Task.Run(DayTime);
            #endregion



        }


        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }
    }
}
