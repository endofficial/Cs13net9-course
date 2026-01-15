/*using System.Data;
using System.Drawing;
using System.Xml; // to use XmlDocument
dynamic something;

object height = 1.88; // memorizzare in un oggetto double
object name = "Mario"; // memorizzare in un oggetto string
Console.WriteLine($"{name} is {height} metres tall");

//int lenght1 = name.Lenght;
int lenght2 = ((string)name).Length; // cast esplicito
Console.WriteLine($"{name} has {lenght2} characters.");

// memorizzare un array di valori int in un oggetto dinamico
something = new[] { 1, 2, 3, 4, 5 };
// something = 12; 
// something = "H"; // ora qualcosa è una stringa
Console.WriteLine("");
Console.WriteLine($"The length of something is {something.Length}");
Console.WriteLine($"something is a {something.GetType()}"); // stampa il tipo di something

// dichiarare ed assegnare un valore in una variabile locale
// utilizzando var, quando viene chiamata la variabile, il compilatore determina il tipo di dato
var population = 1000;
var weight = 70.5;
var price = 19.99M; // il suffisso 'm' indica un valore decimale
var city = "Rome";
var initial = 'R';
var happy = true;

Console.WriteLine("");
Console.WriteLine($"The population of {city} is {population} people.");
Console.WriteLine($"The average weight is {weight} kg.");

var xml1 = new XmlDocument(); // crea un nuovo documento XML. Lavora con C# 3 o successive
XmlDocument xml2 = new XmlDocument(); // crea un nuovo documento XML. Lavora con tutte le versioni di C#

// un cattivo uso di var sta nel non poter determinare il tipo di dato, dobbiamo usare una dichiarazione esplicita
var file1 = File.CreateText("something.txt"); // crea un file di testo
StreamWriter file2 = File.CreateText("something2.txt");

// nuova tipo: new. Serve per allocare o inizializzare memoria per un oggetto
short age; // alloca 2 byte di memoria
long population2; // alloca 8 byte di memoria
DateTime birthdate; // alloca 8 byte di memoria
Point location;
Person bob; // alloca memoria per un oggetto di tipo Person. Lo inizializza con valore di default (null)

// usando new con la nuova sintassi
age = 45;
population2 = 1000000;
birthdate = new (2025, 07, 16); // crea un nuovo oggetto DateTime
location = new(10, 20); // crea un nuovo oggetto Point con le coordinate (10, 20)
bob = new("Bob", "Smith", 30); // crea un nuovo oggetto Person con nome, cognome e età

// usando new con la vecchia sintassi
birthdate = new DateTime(2025, 07, 16); // crea un nuovo oggetto DateTime
location = new Point(10, 20); // crea un nuovo oggetto Point con le coordinate (10, 20)
bob = new Person("Bob", "Smith", 30); // crea un nuovo oggetto Person con nome, cognome e età
bob = new Person(); // crea un nuovo oggetto Person con valori di default (null, null, 0)

// istanziare un oggetto usando il target-typed new
// in C# 9 e versioni successive, possiamo usare il target-typed new
XmlDocument xml3 = new(); // crea un nuovo documento XML    

Person Kim = new();
Kim.Birthdate = new(1990, 01, 01);

List<Person> people = new()
{
    new () { FirstName = "Alice", LastName = "Johnson", Age = 25 },
    new () { FirstName = "Bob", LastName = "Smith", Age = 30 },
    new () { FirstName = "Charlie", LastName = "Brown", Age = 35 }
};*/

// assegnare un valore di default
Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(string) = {default(string) ?? "<NULL>"}");  
Console.WriteLine($"default(DateTime) = {default(DateTime)}");

// esempio di un oggetto con un valore di default
int number = 7;
Console.WriteLine($"number set to: {number}");
number = default; // resetta il valore a default
Console.WriteLine($"number reset to: {number}");

Console.Write("A");
Console.Write("B");