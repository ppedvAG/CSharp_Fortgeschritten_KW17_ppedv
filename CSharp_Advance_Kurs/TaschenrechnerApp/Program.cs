using System.Reflection;

//Assembly - Klasse repräsentiert eine geladeneDll 
Assembly geladeneDll = Assembly.LoadFrom("TaschenrechnerDLL.dll"); //TaschenrechnerDLL.dll befindet sich im selben Verzeichnis wie die TaschenrechnerApp.exe

//Ermitteln aus Dll unsere Klassen MyCalc als Type (für weitere Fragen zur Klassen) 
Type taschenrechnerClassAsType = geladeneDll.GetType("TaschenrechnerDLL.MyCalc");

//tr -> Klassenzeiger wird hier hinterlegt 
object tr = Activator.CreateInstance(taschenrechnerClassAsType);


//Ermitteln die Methode Add
MethodInfo methodInfo = taschenrechnerClassAsType.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

//Callen die Methode Add(11,22)
object result = methodInfo.Invoke(tr, new object[] { 11, 22 });

Console.WriteLine(result);


Console.ReadLine();