// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");


#region Class vs Record  -> = - Operator
if (myPerson1Class == myPerson2Class)
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
}


if (personRecord1 == personRecord2)
{
    Console.WriteLine("personRecord1 == personRecord2 -> gleich");
}
else
{
    Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
}
#endregion

if (myPerson1Class.Equals(myPerson2Class))
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
}

if (personRecord1.Equals(personRecord1))
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
}
else
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
}

//personRecord1.Name = "Das geht so nicht";

//1 und Mario Bart
(int id, string name) = personRecord1; //Dekonstruktion per Default mit dabei 


EmployeeRecord employee = new EmployeeRecord(2, "Kevin", 65000);

Console.WriteLine(employee.ToString());



//Person Record Sample with With

Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };


Person person2 = person1 with { FirstName = "John" }; //Kopieren von person1 auf person2 und manipulieren dabei eine Property (init) 
//person2.FirstName = "Geht nicht"; 

Console.ReadLine();

public record PersonRecord(int Id, string Name);


public record EmployeeRecord : PersonRecord
{
    public decimal Gehalt { get; set; } //Record könnenn auch Set Variablen 


    public EmployeeRecord(int Id, string Name)
         : base(Id, Name)
    {

    }

    public EmployeeRecord(int Id, string Name, decimal Gehalt)
       : base(Id, Name)
    {
        this.Gehalt = Gehalt;
    }

}


public record Person(string FirstName, string LastName)
{
    //Nicht vergessen FirstName und LastName {get;init}
    public string[] PhoneNumbers { get; init; }

    public string Haribo { get; set; }
}


public class PersonClass
{
    public PersonClass(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}