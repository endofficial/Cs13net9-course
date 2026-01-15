namespace Packt.Shared;
using System.Xml.Serialization;

// Per includere le classi derivate Rectangle e Circle nella serializzazione XML
[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]

public abstract class Shape
{ 
    public string? Colour { get; set; }
    public abstract double Area { get; }
}