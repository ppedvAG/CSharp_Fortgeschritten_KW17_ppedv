// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IList<string> strList = new List<string>(); // im Hintergrund ein Array von 4 Felder (per default) 
strList.Add("eins");
strList.Add("zwei");
strList.Add("drei");
strList.Add("vier");

//Liste zu Array
string[] myStringArray = strList.ToArray();


//Array in Liste 
List<string> strList2 = new List<string>();
strList2.AddRange(myStringArray);

//ab einer gewissen Anzahl (bis 4) -> verdoppelt sich das Array intern in der Liste

