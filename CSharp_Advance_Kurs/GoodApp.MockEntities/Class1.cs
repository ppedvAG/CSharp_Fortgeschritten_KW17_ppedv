using GoodApp.Entities.Interfaces;

namespace GoodApp.MockEntities
{
    public class MockCar : ICarVersion3
    {
        public int Id { get; set; } = 1;
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public bool MitKofferraum { get; set; } = true;
        public string Farbe { get; set; } = "blau";
    }
}