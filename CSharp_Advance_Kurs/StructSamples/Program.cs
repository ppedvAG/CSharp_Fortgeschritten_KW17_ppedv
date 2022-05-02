#nullable disable

SPerson sPerson = new SPerson();
sPerson.MyWork = new Work(1, "Maler");
sPerson.MyCar = new Car ("VW");
sPerson.Alter = 20;
sPerson.Augenfarbe = "grün";

ref SPerson sPerson2 = ref sPerson; //Jede einzelene Property wird kopiert -> Alles Wertetypen 

ChangeAll(sPerson); //Strcut ist ein Wertetyp und gibt eine Kopie 

Console.WriteLine(sPerson);



void ChangeAll(SPerson person) //struct ist ein Wertetyp -> Wertypen übergeben Kopien ->
{
    person.Alter++;

    person.MyWork = new Work(2, "Lackierer");

    person.MyCar = new Car("Mercendes");

    person.Augenfarbe = "violett";

}


public struct SPerson
{
    public int Alter { get; set; }

    public string Augenfarbe { get; set; }  

    public double Size { get; set; }    

    public double Weigth { get; set; }  

    public string Anschrift { get; set; }   

    public Work MyWork { get; set; }

    public Car MyCar { get; set; }
    //
}

public struct  Work
{
    public int Id { get; set; } 
    public string Name { get; set; }

    public Work(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}

public class Car
{
    public Car(string brand)
    {
        Brand = brand;  
    }
    public string Brand { get; set; }   
}