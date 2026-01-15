using System.Runtime.CompilerServices;

namespace System.Runtime.CompilerServices
{
    // Questa classe è necessaria per supportare 'init' nei progetti .NET Framework o .NET Core < 5.0
    public class IsExternalInit { }
}



public class ImmutablePerson
{
   // public string? FirstName { get; init; }
   // public string? LastName { get; init; }
}

public record ImmutableVehicle 
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}

// sintassi semplice per definire un record che auto genera le proprietà, i construttori e il deconstruttore.
public record ImmutableAnimals(string Name, string Species);