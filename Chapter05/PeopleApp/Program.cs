/*using France;
using USA; */ // Non si possono usare due namespace che contengono classi con lo stesso nome dell'oggetto

using France;
using Packt.Shared;
using PacktLibraryModern;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using Env = System.Environment;
using US = USA; // Alias per il namespace USA
using Fruit = (string Name, int Number);
using System.Linq.Expressions;

/*#region

using Packt.Shared;

ConfigureCulture();

Person Andrea = new();

Andrea.Name = "Andrea Verdirrame";
Andrea.Born = new DateTimeOffset(year: 2001, month: 11, day: 11, hour: 00, minute: 00, second: 00, offset: TimeSpan.FromHours(-8));
Andrea.FavoriteAncientWonder = WondersOfTheAncientWorld.ColossusRhodes;

WriteLine(format: "{0} was born on {1:D}. {0} prefers to visit {2}. It's integer is {3}", arg0: Andrea.Name, arg1: Andrea.Born, arg2: Andrea.FavoriteAncientWonder (int)Andrea.FavoriteAncientWonder); // 1:D vuol dire data lunga
WriteLine();

// altro modo

Person Jennifer = new();
{
    Jennifer.Name = "Jennifer Scollo";
    Jennifer.Born = new DateTimeOffset(2002, 09, 23, 00, 00, 0, TimeSpan.Zero);

    WriteLine($"{Jennifer.Name} was born on {Jennifer.Born:d}");
    WriteLine();
}

// oppure -> WriteLine(Andrea.ToString())
#endregion*/

#region
Person Andrea = new();
Andrea.Name = "Andrea Verdirrame";

Person Armando = new();
Armando.Name = "Armando Verdirrame";

Andrea.BucketList = WondersOfTheAncientWorld.HangingGardensBabylon | WondersOfTheAncientWorld.MausoleumHalicarnassus;

WriteLine($"{Andrea.Name}'s bucket list is {Andrea.BucketList}.");
WriteLine();

Andrea.WriteToConsole();
WriteLine(Andrea.GetOrigin());
WriteLine();

WriteLine(Andrea.SayHello());

// utilizziamo l'overload per semplificare la chiamata
WriteLine(Andrea.SayHello("Jennifer"));
WriteLine();

WriteLine(Andrea.OptionalParameters(3));
WriteLine(Andrea.OptionalParameters(3, "Jump!", 98.5));
WriteLine(Armando.OptionalParameters (active: false, command: "Hide!", count: 3));
WriteLine(Armando.OptionalParameters(3, "Ok!", active: false));
WriteLine(Armando.OptionalParameters(3, number: 3.18, active: false));

WriteLine();

#endregion

#region
// Gestire i conflitti di nomi all'interno di classi diverse

//Paris p = new(); // errore poiché ambiguità tra France.Paris e USA.Paris

Paris p1 = new(); // Si crea un'istanza France.Paris
US.Paris p2 = new(); // Si crea un'istanza USA.Paris utilizzando l'alias US

#endregion

#region

// un altro caso in cui è utile utilizzare un'alias è per rinominare un tipo

WriteLine(Env.OSVersion);
WriteLine(Env.CurrentDirectory);

#endregion

#region
WriteLine();
// Tutte le versioni di C#
Person Alfredo = new();
Alfredo.Name = "Alfredo Verdirrame";
Alfredo.Born = new DateTimeOffset(1971, 5, 21, 0, 0, 0, TimeSpan.Zero);
Andrea.Children.Add(Alfredo);

// Dalla versione 3.0
Andrea.Children.Add(new Person { Name = "Giovanna" });

// Dalla versione 9.0
Andrea.Children.Add(new() { Name = "Jenny" });

WriteLine($"{Andrea.Name} has {Andrea.Children.Count} children:");

/*for (int childName = 0; childName < Andrea.Children.Count; childName++)
{
    WriteLine($"> {Andrea.Children[childName].Name}");
}*/

// Usiamo foreach
foreach (Person childName in Andrea.Children)
{
    WriteLine($"> {childName.Name}");
}

#endregion

#region 
// creando una classe con un membro statico
ConfigureCulture();

BankAccount.InterestRate = 0.012M; // 1.2% interesse

WriteLine();
BankAccount andreaAccount = new();
andreaAccount.AccountName = "Andrea's account";
andreaAccount.Balance = 2400; // 2400 euro
WriteLine(format: "{0} ernead {1:C} interest.", arg0: andreaAccount.AccountName, arg1: andreaAccount.Balance * BankAccount.InterestRate);

WriteLine();
BankAccount jenniferAccount = new();
jenniferAccount.AccountName = "Andrea's account";
jenniferAccount.Balance = 98; // 2400 euro
WriteLine(format: "{0} ernead {1:C} interest.", arg0: jenniferAccount.AccountName, arg1: jenniferAccount.Balance * BankAccount.InterestRate);

#endregion

#region
// creare una classe con membro costante
// la classe const non è sempre consigliata perché non può essere modificata in futuro e perché il valore si deve conoscere prima della compilazione

WriteLine($"{Andrea.Name} is a {Person.Species}.");

#endregion

#region
// creare una classe con membro readonly
// il membro readonly è preferibile al const perché può essere modificato nel costruttore della classe e una modifica futura non richiede la ricompilazione di tutti i client che usano la classe

WriteLine();   
WriteLine($"{Andrea.Name} was born on {Andrea.HomePlanet}.");

#endregion

#region
// uso di required per proprietà obbligatorie

/*Book book = new()
{
    Isbn = "978-0-13-419044-0",
    Title = "C# 9.0 in a Nutshell",
    Author = "Joseph Albahari and Ben Albahari",
    PageCount = 800,
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.", book.Isbn, book.Title, book.Author, book.PageCount);*/

Book book = new(isbn: "978-0-13-419044-0", title: "C# 9.0 in a Nutshell")
{
    Author = "Joseph Albahari and Ben Albahari",
    PageCount = 800

};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.", book.Isbn, book.Title, book.Author, book.PageCount);

#endregion

#region

Person blankPerson = new();

WriteLine();    
WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", arg0: blankPerson.Name, blankPerson.HomePlanet, blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.", arg0: gunny.Name, gunny.HomePlanet, gunny.Instantiated);

#endregion

#region Controlling how parameters are passed to methods

WriteLine();
int a = 10;
int b = 20;
int c = 30;
int d = 40;

//Per semplificare il codice si può omettere la variabile d e usare direttamente out int d nella chiamata al metodo. 
//Questo perché la variabile out viene inizializzata all'interno del metodo e non è necessario che sia inizializzata prima della chiamata al metodo.

WriteLine($"Before: a = {a}, b = {b}, c = {c}, d = {d}");
Andrea.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a = {a}, b = {b}, c = {c}, d = {d}");

#endregion

#region Params

WriteLine();
Andrea.ParamsParameters("Sum using commas", 3, 6, 1, 2);
Andrea.ParamsParameters("Sum using an array", new int[] { 3, 6, 1, 2 });
Andrea.ParamsParameters("Sum using params", [3, 6, 1, 2]);
Andrea.ParamsParameters("Sum using no values (empty)");

#endregion

#region Tuples

WriteLine();
(string, int) fruit = Andrea.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
WriteLine();

var fruitNamed = Andrea.GetNamedFruit(); //utilizzo var per evitare di scrivere -> (string Name, int Number)
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

WriteLine();
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
WriteLine();

var thing2 = (Andrea.Name, Andrea.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

//Uso di un alias per la tupla
WriteLine();
//senza alias sarebbe var fruitNamed = Andrea.GetNamedFruit();

//Con alias
Fruit fruitName = Andrea.GetNamedFruit();
WriteLine($"There are {fruitName.Number} {fruitName.Name}.");

#endregion

#region decostructing tuples

WriteLine();
// memorizza un valore di ritorno di tupla in diverse variabili
(string name, int number) namedFields = Andrea.GetNamedFruit();
WriteLine($"{namedFields.name}, {namedFields.number} there are.");

// deconstructing in singole variabili
(string name, int number) = Andrea.GetNamedFruit();
WriteLine($"{name}, {number} there are.");

WriteLine();
(string fruName, int fruNumber) = Andrea.GetFruit();
WriteLine($"Deconstructed: {fruName}, {fruNumber}.");

#endregion

#region deconstructing a class
//Assegno la data di nascita di Andrea
Andrea.Born = new DateTimeOffset(2001, 11, 11, 0, 0, 0, TimeSpan.Zero);
Andrea.FavoriteAncientWonder = WondersOfTheAncientWorld.ColossusRhodes;

// deconstructing Andrea
var (name1, dob1) = Andrea; // chiama il metodo Deconstruct() della classe Person
WriteLine($"Deconstruct person: {name1}, {dob1}");

var (name2, dob2, fav2) = Andrea;
WriteLine($"Deconstruct person: {name2}, {dob2}, {fav2}");

#endregion

#region call to a local function

WriteLine();
int num = -5;

try
{
    WriteLine($"{num}! is {Person.Factorial(num)}");
}

catch (Exception ex )
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {num}.");
}
#endregion

#region Property

Person sam = new()
{
    Name = "Sam",
    Born = new DateTimeOffset(1972, 1, 21, 0, 0, 0, TimeSpan.Zero)
};

WriteLine();
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine($"{sam.Name} is {sam.Age} years old.");

WriteLine();
sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"{sam.Name}'s favorite ice-cream flavor is {sam.FavoriteIceCream}.");

WriteLine();
string color = "Yellow";

try
{
    sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favore primary color is {sam.FavoritePrimaryColor}");
}

catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}' : {2}", nameof(sam.FavoritePrimaryColor), color, ex.Message);
}


#endregion

#region Limiting flags enum values

WriteLine();
Andrea.FavoriteAncientWonder = WondersOfTheAncientWorld.PiramideGiza;

#endregion

#region Indexer

WriteLine();
sam.Children.Add(new() { Name = "Charlie", Born = new (2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
sam.Children.Add(new() { Name = "Ella", Born = new (2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });

// get usign children list
WriteLine($"Sam's first children is: {sam.Children[0].Name}");
WriteLine($"Sam's second children is: {sam.Children[1].Name}");

// get using the int indexer
WriteLine($"Sam's first children is: {sam[0].Name}");
WriteLine($"Sam's second children is: {sam[1].Name}");

// get usinf the string indexer
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old");
#endregion

#region Pattern-matching

WriteLine();
//Un array contenente un insieme di persone
Passenger[] passengers =
{
  new FirstClassPassenger { AirMiles = 1_419, name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, name = "Lucy" },
  new BusinessClassPassenger { name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        // C# 8 syntax
        /*FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        FirstClassPassenger _                          => 2_000M,

        //C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000 => 1_500M,
            > 15_00 => 1_750M,
            _       => 2_000M
        },*/

        FirstClassPassenger { AirMiles: > 35000 } => 1500M,
        FirstClassPassenger { AirMiles: > 15000 } => 1700M,
        FirstClassPassenger => 2000M,
    

        BusinessClassPassenger _                       => 1_000M,
        /*CoachClassPassenger p when p.CarryOnKG < 10.0  => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M*/

        CoachClassPassenger p => p.CarryOnKG switch
        {
            < 10.0 => 500M,
            _      => 650M
        }
    };

    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

#endregion

#region Init-only properties

/*ImmutablePerson jeff = new()
{
    FirstName = "Roberto",
    LastName = "Verdi"
};
jeff.FirstName = "Geoff";*/

ImmutableVehicle car = new()
{
    Brand = "BMW",
    Color = "Black",
    Wheels = 4
};

WriteLine();
ImmutableVehicle repaintedCar = car with { Color = "Blue" };
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}");

WriteLine();



#endregion

#region Equality

WriteLine();

// Con la classe anche se si ha la stessa proprietà, sono due oggetti distinti che occupano spazio diverso in memoria. Per questo motivo il risultato sarà un false.
AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };

WriteLine($"ac1 == ac2: {ac1 == ac2}");

//Con record, invece, l'uguaglianza si basa sui valori per questo motivo il risultato è un true.
AnimalRecord ar1 = new() {Name = "Rex"};
AnimalRecord ar2 = new() { Name = "Rex" };

WriteLine($"ar1 == ar2: {ar1 == ar2}");

WriteLine();

// .NET compara i valori delle variabili e se hanno lo stesso risultato darà true
int number1 = 2;
int number2 = 2;
WriteLine($"number1: {number1}, number2: {number2}");
WriteLine($"number1 == number2: {number1 == number2}");

WriteLine();
// .NET compara i riferimenti ma compara in realtà l'indirizzo di memoria
Person p5 = new() { Name = "Kevin" };
Person p6 = new() { Name = "Kevin" };
WriteLine($"p5: {p5}, p6: {p6}");
WriteLine($"p5.Name: {p5.Name}, p6.Name: {p6.Name}");
WriteLine($"P5 == p6: {p5 == p6}");
// mettendo p5.Name == p6.Name => l'output sarà true

WriteLine();

// Darà true perché uguagliamo i due oggetti, assegnando la stessa referenza in memoria
Person p3 = p5;
WriteLine($"p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p5 == p3: {p5 == p3}");

ImmutableAnimals oscar = new("Oscar", "Labrador");
var (who, what) = oscar; //chiamata al decostruttore
WriteLine($"{who} is a {what}");

#endregion

#region primary constructor
WriteLine();
HeadSet vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}");

HeadSet holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}");

HeadSet mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}");

#endregion

#region excercise pg 299

WriteLine();
car fiat = new() { Wheels = 4, IsEv = true };
fiat.Start();

#endregion



