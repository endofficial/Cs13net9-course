using System.Xml.Serialization;
using Packt.Shared;
using FastJson = System.Text.Json.JsonSerializer;
using System.Text.Json; // Per JsonSerializerOptions
using System.Text.Json.Schema; // Per JsonSchemaExporter

#region Serialitazion

List<Person> people = new()
{
    new(initialSalary: 30_000M)
    {
        FirstName = "Jennifer",
        LastName = "Aniston",
        DateOfBirth = new(year: 1969, month: 2, day: 11)
    },
    new(initialSalary: 40_000M)
    {
        FirstName = "Courteney",
        LastName = "Cox",
        DateOfBirth = new(year: 1964, month: 6, day: 15)
    },
    new(initialSalary: 50_000M)
    {
        FirstName = "Lisa",
        LastName = "Kudrow",
        DateOfBirth = new(year: 1963, month: 7, day: 30),
        Children = new()
        {
            new(initialSalary: 0M)
            {
                FirstName = "Sonja",
                LastName = "Kudrow",
                DateOfBirth = new(year: 1998, month: 5, day: 7)
            }
        }
    }
};

SectionTitle("XML Serialization");

XmlSerializer xs = new(type: people.GetType());

//Creare un file per scriverci
string path = Combine(CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

OutputFileInfo(path);

#endregion

#region Deserialization XML

SectionTitle("Deserializing XML files");

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    // Deserializzare l'oggetto dal file e eseguirne il cast.
    // Ricordo che il cast serve per convertire un tipo generico in un tipo specifico
    List<Person>? loadPeople = 
        xs.Deserialize(xmlLoad) as List<Person>; // Eseguire il cast verso List<Person>

    if (loadPeople is not null)
    {
        foreach (Person p in loadPeople)
        {
            WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
            // la parte di children indica: Se children non è null, prendi la proprietà Count,
            // altrimenti (??) prendi 0 cioè ritorna null 
        }
    }
}

#endregion

#region Serialization JSON

// Creare un file per scriverci
string jsonPath = Combine(CurrentDirectory, "people.json");

// Usare StreamWriter per creare il file e scriverci dentro perché è specializzato 
// nello gestire i caratteri di testo (JSON è testuale); FileStream è più generico e gestisce i byte
using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();

    // Serializzare il grafico degli oggetti in una stringa.
    jss.Serialize(jsonStream, people);
}

OutputFileInfo(jsonPath);

#endregion

#region Deserialization JSON

SectionTitle("Deserializing JSON files");

// In questo caso usiamo FileStream perché FastJson supporta i flussi di byte e anche perché
// stiamo leggendo e non scrivendo. Tecnicamente potremmo usare StreamReader ma in questo caso
// non è indicato, FileStream è migliroe.
await using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    // deserializzare l'oggetto dal file in una lista di persone
    List<Person>? loadPeople =
        await FastJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if (loadPeople is not null)
    {
        foreach (Person p in loadPeople)
        {
            WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count ?? 0);
        }
    }
}

#endregion

#region

SectionTitle("JSON Schema exporter");

WriteLine(JsonSchemaExporter.GetJsonSchemaAsNode(JsonSerializerOptions.Default, typeof(Person)));

#endregion