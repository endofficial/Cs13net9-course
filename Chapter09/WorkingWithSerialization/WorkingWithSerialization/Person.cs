using System.Xml.Serialization;

namespace Packt.Shared;

public class Person
{
    // Per la serializzazione XML è necessario un costruttore senza parametri
    public Person() { }

    public Person(decimal initialSalary)
    {
        Salary = initialSalary;
    }

    // Attributi per la serializzazione XML; riduce la size del file
    [XmlAttribute("fname")]
    public string? FirstName { get; set; }

    [XmlAttribute("lname")]
    public string? LastName { get; set; }

    [XmlAttribute("dob")]
    public DateTime DateOfBirth { get; set; }
    public HashSet<Person>? Children { get; set; } 
    protected decimal Salary { get; set; }
}

