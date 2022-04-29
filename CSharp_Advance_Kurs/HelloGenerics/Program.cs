// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Was sind generische Typen
List<string> stringListe = new List<string>();
stringListe.Add("Hallo");
stringListe.Add("Welt");


//Klassen müssen unterhalb beschrieben werden 
IDictionary<int, string> stringDictionary = new Dictionary<int, string>();
stringDictionary.Add(new KeyValuePair<int, string>(123, "Hallo Welt"));
stringDictionary.Add(124, "Hallo Welt");

if (stringDictionary.ContainsKey(123))
{
    Console.WriteLine("Key gefunden");
}

Dictionary<int, string> stringDictionary2 = new Dictionary<int, string>();
stringDictionary2.Add(123, "Hallo Welt");

foreach(KeyValuePair<int, string> kvp in stringDictionary)
{
    //kvp.Key -> readonly
    //kvp.Value -> readonly
}

#endregion


DataStore<DateTime> dataStore = new DataStore<DateTime>();

dataStore.AddIryUpdate(0, DateTime.Now);
dataStore.AddIryUpdate(1, DateTime.Now);

//Methoden könnte man auch expliziet generisch verwenden 
dataStore.DisplayDefault<int>();



//Variable T wird quasi durch verwendung eines Datentypen ersetzt
public class DataStore<T>
{
    
    private T[] _data = new T[10];

    //Generische Property
    public T[] Data
    {
        get => _data;
        set => _data = value;
    }
    public void AddIryUpdate(int index, T item)
    {
        if(index >= 0 && index < 10)
        {
            _data[index] = item;
        }
    }

    //Instanz von einer Klasse können wir auch diese Methode + Datentypangabe verwenden
    public void DisplayDefault<MyType>()
    {

        //Default - Definitionen gibt es in zwei Varianten
        MyType item1 = default!;

        MyType item = default(MyType);
        //Bitte nicht bei POCO-Klassen mit EF-Core  oder noch schlimmer bei POCO - Klassen mit Relationen 


        Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
    }


    //Statisch Generische Methoden -> besser bei Klassen verwenden, die keinen Generic verfolgen -> Pseudo Typen vergaben sind 
    public static void PrintDefaultValueStatischeMethode<MyType>()
    {
        //Default Initialisierung eines Datentypen
        MyType item1 = default!;
        MyType item = default(MyType);
    }
}

public class MyKeyValueItem<TKey, TItem>
{

    public MyKeyValueItem(TKey key, TItem value)
    {
        Key = key;
        Value = value;
    }

    public TKey Key { get; }
    public TItem Value { get; }
}




#region Constraints -> Wir schränken T ein 

//Referenztypen -> string, class, record(ist eine Klasse), interface, 

public class DataStore1<T> where T : class 
{

}


//Wertetypen -> Ganzahlige Datentypen, Komma-Datentypen, bool, struct
public class DataStore2<T> where T : struct
{

}



//Alle Objekte aus der Vererbungs-Hierachy von Animal 
public class DataStore3<T> where T : Animal
{

}

public class Animal
{

}

public class Dog : Animal
{
    
}


public class DataStore4<T> where T : new() //Alle Klassen mit einem Default-Konstruktor
{

}




public class MyKeyValueItem1<TKey, TItem> 
    where TKey : struct 
    where TItem : class 
{

}

#endregion