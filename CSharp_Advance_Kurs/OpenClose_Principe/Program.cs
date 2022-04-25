//#nullable disable

ReportType reportAuswahl;

Employee employee = new Employee() { Id = 123, Name = "Otto Walkes" };


#region Variante 1
//In diesem Fall wird via UI PDF ausgewählt
reportAuswahl = ReportType.PDF;


BaseReportGenerator generator;

if (reportAuswahl == ReportType.CR)
{
    generator = new CrystalReportGenerator();
    generator.GenerateReport(employee);
}
else if (reportAuswahl == ReportType.List10)
{
    generator = new List10ReportGenerator();
    generator.GenerateReport(employee);
}

#endregion

#region Variante 2
//Klasse als Basistyp 
CRReporter cRReporter = new CRReporter();

cRReporter.GenerateReport(employee);
cRReporter.OutputDirectory = @"C:\Temp\";
cRReporter.CRPRint();
((IReportGenerator)cRReporter).SaveTemplates();


//Interface als Basistyp 

IReportGenerator reportGenerator = new CRReporter();
reportGenerator.SaveTemplates();
reportGenerator.GenerateReport(employee);
reportGenerator.OutputDirectory = @"C:\Temp";

((CRReporter)reportGenerator).CRPRint();

#endregion

#region Variante 3 (selten) 

IReportBaseGenerator crReportGenerator = new CRReportImp();
crReportGenerator.GenerateReport(employee);
crReportGenerator.SaveTemplates();
crReportGenerator.OutputDirectory = @"C:\\Temp";


((ReportBaseGenerator)crReportGenerator).LoadTemplates();

#endregion

#region Variante 4

IMyCrystalReportGenerator myCrystalReportGenerator = new MyCrystalReportGenerator();
myCrystalReportGenerator.Generate(employee);
myCrystalReportGenerator.PrintCrystalReports();

//Was stelle ich mit IMyReportGenerator (hat es einen UseCase) -> Polymorphie

List<IMyBaseGenerator> generatorsCollection = new List<IMyBaseGenerator>();
generatorsCollection.Add(myCrystalReportGenerator); //Polymorphie - Ansatz 

//Auslesen

IMyCrystalReportGenerator myCrystalReportGenerator1 = (IMyCrystalReportGenerator)generatorsCollection[0];
#endregion




public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } //Nullable Warnings kann man auch abschalten
} 


//Eine Klasse, die sich für verschiede Reportausgaben kümmert


//BadReportGenerator wird sehr sehr viele Code-Zeilen aufgebläht werden
//Klasse überladen 

public class BadReportGenerator
{
    public string ReportType { get; set; } = string.Empty;

    private string CrystalReportsTemplateDirectory { get; set; }
    private string List10TemplateDirectory { get; set; }

    private string OutputDirectory { get; set; }    


    private object PDFCompressRate { get; set; }


    public void GenerateReport(Employee em)
    {
        
        if (ReportType == "CR") //Crystal Reports (Drittanbieter mit einer eigenen DLL-Library
        {
            // 200 Zeilen
        }
        else if (ReportType == "List10") //List10 (Drittanbieter mit einer eigenen DLL-Library
        {
            // 350 Zeilen
        }
        else if (ReportType == "PDF")//PDF (Drittanbieter mit einer eigenen DLL-Library
        {
            // 150 Zeilen
        }
    }
}



#region Variante 1

//Open-Part (Die Abstraktion)
public abstract class BaseReportGenerator
{
    //abstrakte Methoden sind eine Schablone und eine Muss-Implementierung
    public abstract void GenerateReport(Employee em);

    public string OutputDirectory { get; set; }

    public void LoadTemplates()
    {
        //Man könnte in einer abstrakte Klasse auch Methoden implementieren 
    }
}

//Close-Part 

//Für die Library CrystalReports haben wir eine Klasse die sich nur um CrystalReports kümmert
//Weiterer Vorteil 
public class CrystalReportGenerator : BaseReportGenerator
{
    private string CrystalReportsTemplateDirectory { get; set; }

    public override void GenerateReport(Employee em)
    {
       
    }
}


public class List10ReportGenerator : BaseReportGenerator
{
    private string List10ReportsTemplateDirectory { get; set; }

    public override void GenerateReport(Employee em)
    {

    }
}



public enum ReportType {CR, List10, PDF }
#endregion


#region Variante 2

//Open Part
public interface IReportGenerator
{
    void GenerateReport(Employee em);

    string OutputDirectory { get; set; }

    
    //Um Reduanz  zu vermeiden -> gibt es Default-Methoden
    public void SaveTemplates()
    {
        //Default - Implementierung 

    }
}


//Close
public class CRReporter : IReportGenerator
{
    public string OutputDirectory { get; set; }

    public void GenerateReport(Employee em)
    {
        //report wird generiert 
    }


    public void CRPRint()
    {

    }
}

#endregion


#region Variante 3

public interface IReportBaseGenerator
{
    void GenerateReport(Employee em);

    string OutputDirectory { get; set; }

    public void SaveTemplates();
}

public abstract class ReportBaseGenerator : IReportBaseGenerator
{
    public abstract string OutputDirectory { get; set; }

    public abstract void GenerateReport(Employee em);

    public abstract void SaveTemplates();

    public void LoadTemplates()
    {
        //Man könnte in einer abstrakte Klasse auch Methoden implementieren 
    }
}


public class CRReportImp : ReportBaseGenerator
{
    
    public override string OutputDirectory { get; set; }

    public override void GenerateReport(Employee em)
    {
       
    }

    public override void SaveTemplates()
    {
        
    }
}

#endregion

#region Variante 4 (ohne Cast, mit Interfaces)
public interface IMyBaseGenerator
{
    void Generate(Employee employee);
}

public interface IMyCrystalReportGenerator : IMyBaseGenerator
{
    void PrintCrystalReports();
}

public class MyCrystalReportGenerator : IMyCrystalReportGenerator
{
    public void Generate(Employee employee)
    {
        
    }

    public void PrintCrystalReports()
    {
        
    }
}

#endregion

