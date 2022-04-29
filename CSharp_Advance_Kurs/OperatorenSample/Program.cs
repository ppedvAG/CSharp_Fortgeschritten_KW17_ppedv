// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



Bruch bruch1 = new Bruch(1, 4);
Bruch bruch2 = new Bruch(2, 4);

if (bruch1 != bruch2)
{
    Console.WriteLine("ungleich");
}
else
    Console.WriteLine("gleich");

public class Bruch
{

    public int Zähler { get; set; }
    public int Nenner { get; set; }

    public Bruch(int Zähler, int Nenner)
    {
        this.Zähler = Zähler;
        this.Nenner = Nenner;
    }


    #region == | != Operator
    // == Operator -> müssen dann auch != implementieren (geht nur als Paar) 
    public static bool operator == (Bruch left, Bruch right)
    {
        if (left.Zähler != right.Zähler || (left.Nenner != right.Nenner))
            return false;

        return true; 
    }

    // 1/4 != 2/4 -> false
    public static bool operator != (Bruch left, Bruch right)
    {
        if (left.Nenner == right.Nenner && left.Zähler == right.Zähler)
            return false;

        return true;
    }
    #endregion




    #region Verbund < und >
    public static bool operator >(Bruch left, Bruch right)
    {
        return true;
    }
    public static bool operator <(Bruch left, Bruch right)
    {
        return true;
    }

    #endregion


    #region >= und <= 
    public static bool operator >=(Bruch left, Bruch right)
    {
        return true;
    }

    public static bool operator <=(Bruch left, Bruch right)
    {
        return true;
    }
    #endregion

    //Operatoren sind Überladbar

    public static Bruch operator * (Bruch left, Bruch right)
            => new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);


    public static Bruch operator * (Bruch left, int zaehler)
    {
        return new Bruch(left.Zähler * zaehler, left.Nenner);
    }


}