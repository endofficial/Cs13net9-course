//definizione di un costruttore primario. Questo si può definire insieme alla classe
namespace Packt.Shared;

public class HeadSet (string manufacturer, string productName) //solo così non sono automaticamente pubbliche
{
    public string Manufacturer { get; set; } = manufacturer;
    public string ProductName { get; set; } = productName;

    // Default parameterless constructor calls the primary constructor.
    public HeadSet() : this("Microsoft", "HoloLens") { }
}