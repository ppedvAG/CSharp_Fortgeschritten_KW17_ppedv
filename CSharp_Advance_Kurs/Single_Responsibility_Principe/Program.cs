//Zuerst die Main-Methode
Console.WriteLine("Hello, World!");

//unterhalb definieren wir Typen (class, enums, struct, delegate)


//Die Klasse hat folgene nachteile: 

//- Änderungen werden meist mit refactoring in Verbindung 
//- Unübersichtlichkeit fehlt mit der Zeit
//- Ist von allen Standards außen vor
public class BadEmployee
{
    //Datenstruktur -> Wäre besser in einer eigenen Klasse zu schreiben
    public int Id { get; set; }
    public string Name { get; set; }

    //DataAccess-Layer 
    public void InsertEmployeeToTable(BadEmployee employee)
    {
        //any Code
    }


    //Report genieren möchte -> eine Ausgabe
    public void GenerateReport()
    {
        //any Code
    }
}


//Entity-Klasse (POCO-Objects) -> 

public class Employee
{
    public int Id { get; set; } 
    public string Name { get; set; }

    //Bitte keine Logik in Entites oder POCO 
    //public string VorUndNachname als Ausgabe 
}

//DataAccess Layer -> CRUD (Create, Read, Updata, Delete) 
public class EmployeeRepository //Klasse die mit einer Tabelle kommuniziert
{
    public void Insert (Employee employee)
    {
        //Datenbank
    }
}


//Generate Report 
public class EmployeeService
{
    //Report zu einem Mitarbeiter wird generiert 
    public void GenerateReport ()
    {

    }
}





