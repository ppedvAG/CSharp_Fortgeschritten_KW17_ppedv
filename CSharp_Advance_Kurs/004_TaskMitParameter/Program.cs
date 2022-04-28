﻿using System;
using System.Threading.Tasks;

namespace _004_TaskMitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new Katze();

            //Task mit Konsturktor + expliziet Start-Methode
            Task<string> task1 = new Task<string>(MachEtwas, katze);
            task1.Start();
            Console.WriteLine(task1.Result);

            //Wir verwenden eine anonyme Methode und können daher die Methode mit Parameter wie gewohnt aufrufen 
            Task<string> task2 = new Task<string>(()=>MachEtwas(katze));
            task2.Start();
            task2.Wait();
            Console.WriteLine(task2.Result);

            //Factory
            Task<string> task3 = Task.Factory.StartNew(MachEtwas, katze);
            task3.Wait(); 
            Console.WriteLine(task3.Result);

            //Task.Run 
            Task<string> task4 = Task.Run(() => MachEtwas(katze));
            task4.Wait();
            string result = task4.Result;

        }

        private static string MachEtwas(object input)
        {
            if(input is Katze katze)
            {
                return katze.Name;
            }

            throw new ArgumentException();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
