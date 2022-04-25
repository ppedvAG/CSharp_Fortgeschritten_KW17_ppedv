using GoodApp.Entities.Interfaces;

namespace GoodApp.Entities
{

    //Programmierer A benötigt 5 Tage
    public class Car : ICarVersion3
    {
        private string marke; 

        //Auto-Property -> bedeutet eine private Member-Variable wird beim kompilieren automatisch angelegt 
        public int Id { get; set; }
        
        //Wollen einfach mal eine Property mit seinem ganzen Potezial aus Spass anzeigen 
        public string Marke 
        { 
            get
            {
                return marke;
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                   throw new ArgumentNullException(nameof(value));

                Marke = value;
            }
        }


        public string Modell { get; set; }
        public bool MitKofferraum { get; set; }
        public string Farbe { get; set; }
    }
}