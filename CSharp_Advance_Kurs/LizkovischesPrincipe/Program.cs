// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region BadCode
public class BadKirsche
{
    public int TagDerREife = 100;

    public string GetColor()
    {
        return "rot";
    }
}

public class BadErdbeere : BadKirsche
{
    public string GetColor()
    {
        return base.GetColor();
    }
}
#endregion



#region

//Open-Close Regeln anlehnen
public abstract class Fruits
{
    public abstract string GetColor();
}

public class Erdbeere : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}

public class Kirsche : Fruits
{
    public override string GetColor()
    {
        return "rot";
    }
}

#endregion

