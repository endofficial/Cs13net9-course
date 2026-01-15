using System.Xml.Serialization; // For XML serialization
using Packt.Shared; // For Shape, Circle, Rectangle classes

string path = Combine(CurrentDirectory, "shape.xml");

List<Shape> listOfShapes = new()
{
    new Circle { Colour = "Red", Radius = 2.5 },
    new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
    new Circle { Colour = "Green", Radius = 8.0 },
    new Circle { Colour = "Purple", Radius = 12.3 },
    new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
};

XmlSerializer xs = new(type: listOfShapes.GetType());

using (FileStream filexml = File.Create(path))
{
    xs.Serialize(filexml, listOfShapes); 
}

WriteLine("Loading shapes from XML files.");

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    List<Shape>? loadedshapes = xs.Deserialize(xmlLoad) as List<Shape>; // Cast to List<Shape>, utile per accedere alle proprietà specifiche delle classi derivate

    if (loadedshapes is not null)
    {
        foreach (Shape item in loadedshapes)
        {
            WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Colour, item.Area);
        }
    }
}