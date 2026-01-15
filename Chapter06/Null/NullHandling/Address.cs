namespace Packt.Shared;

public class Address
{
    public string? Building;
    public string Street = string.Empty; // serve per evitare warning di non inizializzazione
    public string City;
    public string Region;

    public Address()
    {
        City = string.Empty;
        Region = string.Empty;
    }

    public Address(string city) : this() // chiamata al costruttore di default
    {
        City = city;
    }
}


