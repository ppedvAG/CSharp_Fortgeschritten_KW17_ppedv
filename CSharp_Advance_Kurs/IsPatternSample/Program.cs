// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");




void CheckTyp (object obj) //Alle Datentypen kann object annehmen 
{
    if (obj.GetType () == typeof (string)) //.NET Alte Variante
    {
        Console.WriteLine("obj ist ein string");
    }

    if (obj is not null) //alternativ -> if (obj is null)
    {
        
    }

    if (obj is string)
    {
        Console.WriteLine("ob ist ein string");
    }

    if (obj is string str)
    {
        Console.WriteLine("ob ist ein string und wird gleich in str gecastet " + str);
    }
}