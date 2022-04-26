using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{

    public delegate void ChangePercentValueDelegate(int percentValue);
    public delegate void ResultDelegate(string msg);


    public class ProgressBar1
    {
        //Wir wollen von Aussen eine Methode für unseren Callback anbinden
        public event ChangePercentValueDelegate ChangePercentValue; //Für Funktionzeiger (Methoden mit einen void MethodeABC(int)) bieten wir eine GET/SETTER 
        public event ResultDelegate ResultCompletedDelegate;

        public void StartProcess()
        {
            for (int i = 0; i < 100; i++)
            {
                // Nach außen kommunizieren 
                OnProcessPercentStatus(i);
                
            }

            // Nach außen kommunizieren 
            OnFertig("bin fertig");
        }

        protected virtual void OnProcessPercentStatus(int perconet)
        {
            //Wenn eine Methode dran hängt, dann rufen wir diese auch auf
            ChangePercentValue?.Invoke(perconet); //Jetzt teilen wir nach außen mit, dass es ein neuer Prozentwert gibt
        }

        protected virtual void OnFertig(string msg)
            => ResultCompletedDelegate?.Invoke("PercentBar ist fertig");
    }
}
