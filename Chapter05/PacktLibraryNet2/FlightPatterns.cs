namespace Packt.Shared;

public class Passenger
{
    public string? name {  get; set; }
}

public class BusinessClassPassenger : Passenger // ereditarietà
{
    public override string ToString() //Override indica che si sta sostituendo l'implementazione di un metodo predefinita che la classe ha ereditato 
    {
        return $"Business Class: {name}";
    }
}

public class FirstClassPassenger : Passenger
{
    public int AirMiles { get; set; }
    public override string ToString()
    {
        return $"First Class with {AirMiles:N0} air miles: {name}";
    }
}

public class CoachClassPassenger : Passenger
{
    public double CarryOnKG { get; set; }
    public override string ToString()
    {
        return $"Coach Class with {CarryOnKG} KG carry on: {name}";
    }
}