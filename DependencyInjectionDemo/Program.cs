// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


//dependency
// has-a relationship

//TataCar _hexa = new TataCar(new VeriCoreEngine(new StarterMotor(),new FuelPump())); //Injection By Hand
//_hexa.MediaSystem = new BoseSystem();

//TataCar _old_safari = new TataCar(new VeriCoreEngine(new StarterMotor(),new FuelPump ()));
//TataCar _harrier = new TataCar(new KryotecEngine(new StarterMotor(), new FuelPump()));
//_harrier.MediaSystem = new BoseSystem();
//TataCar _nexon = new TataCar(new RevtronEngine(new StarterMotor(),new FuelPump()));

//Autowiring
//DI Container
//Register
//Resolve

var serviceProvider = new ServiceCollection()
                            .AddTransient<TataCar>()
                            .AddTransient<IKineticEngeryProvider, RevtronEngine>()
                            .AddSingleton<StarterMotor>()
                            .AddSingleton<FuelPump>()
                            .AddTransient<IMediaSystem, BoseSystem>()
                            .BuildServiceProvider();

var _tataCar=serviceProvider.GetService<TataCar>();
var _tataCar1 = serviceProvider.GetService<TataCar>();
var _tataCar2 = serviceProvider.GetService<TataCar>();
var _tataCar3 = serviceProvider.GetService<TataCar>();
var _tataCar4 = serviceProvider.GetService<TataCar>();







class TataCar
{
    //Dependency -Mgmt
    //Dependency Inversion Principle
    IKineticEngeryProvider _engine = null;
    IMediaSystem _system = new Sony();
    //Dependency Injetcion Using Cnstructor (Constructor Injection)
    //Dependency is Must
    //Dependency will not change for the lifetime of Client
    public TataCar(IKineticEngeryProvider engine)
    {
        _engine = engine;
        Console.WriteLine("Tata Car Instantiated");
        
    }

    //Property Injection
    //Dependency is Optional , Dependency Can Change for the lifetime of Client
    public IMediaSystem MediaSystem
    {
        get { return _system; }
        set { _system = value; }
    }
}

interface IKineticEngeryProvider
{

}
class VeriCoreEngine:IKineticEngeryProvider
{
    StarterMotor motor;
    FuelPump pump;
    public VeriCoreEngine(StarterMotor motor, FuelPump pump)
    {
        this.motor = motor;
        this.pump = pump;
        Console.WriteLine("Engine Assembled an Instantiated");
    }
}

class StarterMotor
{
    public StarterMotor() {

        Console.WriteLine("Start Motor Instantiated");
    }



}
class FuelPump
{
    public FuelPump()
    {

        Console.WriteLine("Fuel Pump Instantiated");
    }
}

class KryotecEngine:IKineticEngeryProvider
{
    StarterMotor motor;
    FuelPump pump;
    public KryotecEngine(StarterMotor motor, FuelPump pump)
    {
        this.motor = motor;
        this.pump = pump;
    }
}

class RevtronEngine : IKineticEngeryProvider
{
    StarterMotor motor;
    FuelPump pump;
    public RevtronEngine(StarterMotor motor, FuelPump pump)
    {
        this.motor = motor;
        this.pump = pump;
    }
}

interface IMediaSystem { }
class BoseSystem:IMediaSystem
{

}

class Sony:IMediaSystem
{

}

class HM : IMediaSystem
{

}

