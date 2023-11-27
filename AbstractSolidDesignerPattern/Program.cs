using System;
 
public interface IChair
{
    bool HasLegs { get;  }
    void SitOn();


}

public interface ISofa
{
    void Lounge();

}

public interface ICoffeTable
{
    void PutCoffee();

}

public interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeTable CreateCofeeTable();

    
}

public class VictorianChair : IChair
{
    public bool HasLegs { get; } = true;

    public void SitOn()
    {
        Console.WriteLine("Sitt on Victorian chair ");
    }
}

public class VictorianSofa : ISofa
{
    public void Lounge()
    {
        Console.WriteLine("lounging Victorian Sofa ");

    }
}

public  class VictorianCofeeTable : ICoffeTable
{
    public void PutCoffee()
    {
        Console.WriteLine("put cofee table ");
    }
}

public class  VictorianFurnitureeFactory : IFurnitureFactory
{
    public IChair CreateChair ()
    {
        return new VictorianChair();


    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }

    public ICoffeTable CreateCofeeTable()
    {
        return new VictorianCofeeTable();

    }
}
public class Client
{
    private readonly IFurnitureFactory factory_;
    public Client (IFurnitureFactory factory)
    {
       
        this.factory_ = factory;


    }

    public void SitAndLounge()
    {
        var chair = factory_.CreateChair();
        var sofa = factory_.CreateSofa();
        chair.SitOn();
        sofa.Lounge();
            
    }

}

public class Program
{
    public static void Main(string[] args) 
    {
        var victorianFactory = new VictorianFurnitureeFactory();
        var client = new Client(victorianFactory);
        client.SitAndLounge();

    }

}