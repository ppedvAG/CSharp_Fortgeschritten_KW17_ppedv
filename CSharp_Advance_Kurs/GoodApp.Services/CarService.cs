using GoodApp.Entities.Interfaces;
using GoodApp.Services.Interfaces;

namespace GoodApp.Services
{
    //Programmierer B benötigt 3 Tage
    public class CarService : ICarServiceVersion3
    {
        public void LackiereAutoUm(ICarServiceVersion2 car)
        {

            Console.WriteLine("Lackiere Auto um");
        }

        public void PruefeKofferRaumNachErsteHilfeSet(ICarServiceVersion3 carServiceVersion3)
        {
            Console.WriteLine("Kofferraum wird auf Hilfsset gecheckt");
        }

        public void Repair(ICar car)
        {
            //car wird repariert 
        }
    }


}