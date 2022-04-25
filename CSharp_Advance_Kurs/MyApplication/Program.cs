using GoodApp.Entities;
using GoodApp.Entities.Interfaces;
using GoodApp.MockEntities;
using GoodApp.Services;
using GoodApp.Services.Interfaces;

ICarService service = new CarService();


//Programmierer hat 2 Tage zeit

ICar testObjekt = new MockCar();
service.Repair(testObjekt); //Vorab kann ich Testobjekte bauen 

//Nach 5 Tagen ist Programmierer B fertig 
ICar car = new Car();
Car car1 = new Car();

service.Repair(car);
service.Repair(car1);


//Versionierung in meinem Programm mit lose Kopplungen

ICar carVersion1 = new Car

