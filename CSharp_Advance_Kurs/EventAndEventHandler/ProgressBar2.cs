using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{
    public class ProgressBar2
    {
        //Wir bieten nach außen Events an
        public event EventHandler PercentValueChanged;

        public event EventHandler ProcessCompleted;

        
        public void StartProcess()
        {
            for (int i = 0; i <= 100; i++)   
                OnPercentValueChanged(i);


            OnProcessCompleted();
        }



        //Wir kommunizieren nach außen
        protected virtual void OnPercentValueChanged(int i)
        {
            MyPercentEventArgs myPercentEventArgs = new();
            myPercentEventArgs.PercentValue = i;


            //Uuerst überprüfen wir, ob eine Event-Methode -> PercentValueChanged verwendet

            //if (PercentValueChanged != null) -> Alternative zu PercentValueChanged?.
            PercentValueChanged?.Invoke(this, myPercentEventArgs);
        }


        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, EventArgs.Empty); //Event wird gefeuert
        }
    }

    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }
    }
}
