// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int zahl = default;
int zahl1 = 0;

string str = default;
string str1 = string.Empty;

#region nullbare Datentypen -> Interessanterer Ansatz al

int? nullableInteger = null;
decimal? nullableDecimal = null;
float? floatValue = null;
bool? nullableBool = null;



if (nullableInteger.HasValue) //Ist Wert vorhanden 
{
    Console.WriteLine(nullableInteger.Value);
}

string? nullableString = null;

if (string.IsNullOrEmpty(str1))
{
    Console.WriteLine(nullableString);
}

//Alternativ




#endregion


Console.WriteLine(zahl);

//ABC abc = new ABC();
//abc.


public class ABC
{
    private int X { get; set; }

    public void SetX(int x)
        { this.X = x; }
}