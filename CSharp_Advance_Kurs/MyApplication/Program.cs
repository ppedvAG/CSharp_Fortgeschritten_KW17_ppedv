using GoodApp.Entities;
using GoodApp.Entities.Interfaces;
using GoodApp.MockEntities;
using GoodApp.Services;
using GoodApp.Services.Interfaces;


//Version 1
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


//MockCar in Version aus. Das Interface ICar ist für Version 1 ausgelegt
ICar carVersion1 = new MockCar();

//Version2
ICarVersion2 carVersion2 = new MockCar();

//Version3
ICarVersion3 carVersion3 = new MockCar();


//Abwärstkompatibel sind alle CarVersionen

service.Repair(carVersion1);
service.Repair(carVersion2);
service.Repair(carVersion3);

ICarServiceVersion3 serviceInVersion3 = new CarService();
serviceInVersion3.Repair(carVersion1); //REpair ist für Version 1

//CarVersion1 kann man nicht in Version2 oder Version3 verwenden

//serviceInVersion3.LackiereAutoUm(carVersion1); //Geht natürlich nicht! Ein Objekt von Version 1 soll nicht Version 2 bedienen 
//serviceInVersion3.PruefeKofferRaumNachErsteHilfeSet(carVersion1);