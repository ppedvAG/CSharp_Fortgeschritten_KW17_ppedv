Console.WriteLine("Out-Sample");

//Integer ist ein Wertetype 
int alter = 20;

//Beispiel 1 - > Wertetyp Zuweisung
Altern(alter);
Console.WriteLine(alter); //Alter 20

AlternWithOutParam(out alter);
Console.WriteLine(alter);

Person person = new Person();
person.Alter = 20;
PersonAltern (person); //Alter 21 

Console.WriteLine(person.Alter);

Console.Write("Bitte geben Sie eine Zahl ein > ");
string input = Console.ReadLine();
#region .NET Framework Implementierungen bevor  -> Out - Keyword

//Alte-Varianten (Obselete) 
try
{
    int convertedNumber = Convert.ToInt32(input); //.NET 1.1 

    int convertedNumber2 = int.Parse(input);

    if (IsIntegerValue(input)) //
    {
        convertedNumber2 = Convert.ToInt32(input);
    }
    
}
catch (FormatException ex)
{

}
     
bool IsIntegerValue(string input)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (!char.IsDigit(input[i]))
            return false;
    }

    return true;
}
#endregion


#region int.TryParse(out...)
int convertedNumber3;

if (int.TryParse(input, out convertedNumber3))
{
    // wenn TryParse -> bool zurückgegeben hat -> dann war convertedNumber3 eine Zahl

    Console.WriteLine(convertedNumber3);
}
else
{
    //Logging 
    //Message an UI (Validierungsmöglichkeit)

    //harte Variante via Exception werfen 
    throw new FormatException("bitte geben Sie eine richtige Zahl ein"); 
}
#endregion


void Altern(int theAge) //Kopie wird übergeben
{
    theAge++;
}



//Out
void AlternWithOutParam (out int theAgeReference)
{
    theAgeReference = 25;
    //theAgeReference = theAgeReference + 1; //geht leider nicht 
}

//Ref
void AlternWithRefParam1(ref int theAgeReference)
{
    theAgeReference = 30;
    theAgeReference = theAgeReference + 1; 
}

//In 
void AlternWithInParam2(in int theAgeReference)
{
    //theAgeReference = 30; -> würde einen Fehler ausgeben, weil -> 'in' ist readonly
    Console.WriteLine(theAgeReference);
    int age = theAgeReference;
}

void PersonAltern(Person person) //Zeiger -> Speicherbereich wird übegeben
{
    person.Alter++;
}

public class Person
{
    public int Alter { get; set; } 
}


