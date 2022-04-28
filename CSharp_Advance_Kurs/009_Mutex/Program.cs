﻿using System;
using System.Threading;

namespace _009_Mutex
{
    internal class Program
    {
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            KritischerCodeAbschnitt();
        }

        static void KritischerCodeAbschnitt()
        {
            mutex = new Mutex(false, "MyMutex");

            bool lockToken = false;

            try
            {
                //true
                lockToken = mutex.WaitOne();

                //Alternativ ohne bool-Variable
                mutex.WaitOne();


                //Kritischer Code
            }
            finally
            {
                if (lockToken)
                    mutex.ReleaseMutex(); //Freigabe 
            }
        }
    }
}
