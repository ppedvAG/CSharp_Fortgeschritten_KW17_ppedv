using System.Dynamic;

dynamic myObj = new ExpandoObject();

myObj.abc = 123;
myObj.def = "Hallo Welt";
myObj.ghj = DateTime.UtcNow;


//ViewBags -> in ASP.NET Core MVC / RazorPages  (ViewBags sind dynamisch) 
//ViewData -> Dictionary
//ViewBags -> verwendet intern ViewData

//https://github.com/ppedvAG/CSharp_Fortgeschritten_2022_04_20_ppedv/blob/main/AnonymeDynamischeTypen/Program.cs


