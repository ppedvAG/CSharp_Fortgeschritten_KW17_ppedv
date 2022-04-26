// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class PersonBase
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Employee : PersonBase
{
    public decimal Salary { get; set; }
}

public class Trainee : PersonBase
{
    public decimal TraineeSalary { get; set; }
}

public class Freelance : PersonBase
{
    public decimal SalaryPerHour { get; set; }  
    public int HoursPerMonth { get; set; }
}




public abstract class PaymentService
{
    public abstract decimal Payment(PersonBase person);
}


public class EmployeePaymentService : PaymentService
{
    public override decimal Payment(PersonBase person)
    {
        if (person is not Employee)
            throw new ArgumentException("Bitte ein Employee-Objekt übergeben");
        
        Employee employee = (Employee)person;
        //weitere Employee
        return employee.Salary;
    }
}
public class TraineePayment : PaymentService
{
    public override decimal Payment(PersonBase person)
    {
        if (person is not Trainee)
            throw new ArgumentException("Bitte ein Employee-Objekt übergeben");

        Trainee trainee = (Trainee)person;

        return trainee.TraineeSalary;
    }
}

public class FreelancePayment : PaymentService
{
    public override decimal Payment(PersonBase person)
    {
        if (person is not Freelance)
            throw new ArgumentException("Bitte ein Employee-Objekt übergeben");

        Freelance trainee = (Freelance)person;

        return trainee.SalaryPerHour * trainee.HoursPerMonth;
    }
}







public abstract class ReportBase
{
    public abstract void StatisticReport(PersonBase person);
}


public class PDFReport : ReportBase
{
    public override void StatisticReport(PersonBase person)
    {
        
    }
}

 












public class CompletePersonClass

{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }



    public ContractType Contract { get; set; }
    public int Salary { get; set; }


    public int ReportType { get; set; }



    public void PaymentService()
    {
        if (Contract == ContractType.Freelance)
        {

            //Salary? 

        }

        else if (Contract == ContractType.Employee)

        {

            //.... 

        }

        else if (Contract == ContractType.Trainee)

        {

            //.... 

        }

    }



    public void InsertPerson()

    {

        //Lege Personen-Datensatz neu an 

    }



    public void UpdatePerson()

    {

        //Aktualisiere Personen-Datensatz neu an 

    }





    public void StatisticReport()

    {

        if (ReportType == 1)

        {

            //Generate PDF 

        }

        else if (ReportType == 2)

        {

            //Generate CrystalReports 

        }

        else if (ReportType == 3)

        {

            //Generate List10 

        }

    }



}



public enum ContractType

{

    Trainee, Employee, Freelance

}