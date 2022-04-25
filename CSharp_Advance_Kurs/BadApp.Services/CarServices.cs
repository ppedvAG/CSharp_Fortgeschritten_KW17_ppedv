using BadApp.Entities;

namespace BadApp.Services
{

    //Programmierer B: 3 Tage -> Programmierer B müsste warten, bis Programmierer A fertig ist
    public class CarServices
    {
        //Hier verwenden wir eine feste - Kopplung 
        public void Repair (BadCar car)
        {
            //Auto wird repariert

            //weiterer Nachteil -> bei Änderungen in der Klasse BadCar, habe ich eventuell Auswirklungen auf meine Logik in dieser Methode
        }
    }
}