// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using HelloSerialisierung;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

Person person = new Person()
{
    Vorname = "Max",
    Nachname = "Moritz",
    Alter = 19,
    Kontostand = 5_000,
    KreditLimit = 50_000
};


Stream stream = null;


#region BinaryFormatter 

//Binär 

//schreiben 
BinaryFormatter binaryFormatter = new BinaryFormatter();
stream = File.OpenWrite("Person.bin");
binaryFormatter.Serialize(stream, person);
stream.Close();

//lesen
stream = File.OpenRead("Person.bin");
Person geladenePersonAusBinary = (Person)binaryFormatter.Deserialize(stream);
stream.Close();
#endregion



#region XML Serialiser
//benötigt Serializeable - Attribute
//Schreiben
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
stream = File.OpenWrite("Person.xml");
xmlSerializer.Serialize(stream, person);
stream.Close();

//Lesen
stream = File.OpenRead("Person.xml");
Person xmlPerson = (Person)xmlSerializer.Deserialize(stream);
stream.Close();

#endregion

#region JSON
//schreiben 
string jsonString = JsonConvert.SerializeObject(person);
File.WriteAllText("Person.json", jsonString);


//lesen
string readedJsonString = File.ReadAllText("Person.json");
Person readedJSONPerson = JsonConvert.DeserializeObject<Person>(readedJsonString);

#endregion

#region Eigener CSV Serializer für den Typ Person
person.Speichern("Person.csv");

Person p = new Person();
p.Laden("Person.csv");

Console.ReadLine();
#endregion


[Serializable]
public class Person
{
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public int Alter { get; set; }

    //[field:NonSerialized] //Binary setzt das Serialisieren bei dieser Property aus

    [XmlIgnore]
    [JsonIgnore]
    public decimal Kontostand { get; set; }

    //[field: NonSerialized] //Binary setzt das Serialisieren bei dieser Variable aus
    [XmlIgnore]
    [JsonIgnore]
    public decimal KreditLimit;
}