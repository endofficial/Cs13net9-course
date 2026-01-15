using Packt.Shared;

#region

Person harry = new()
{
    Name = "Harry",
    Born = new(2001, 3, 25, 0, 0, 0, TimeSpan.Zero)
};

harry.WriteToConsole();
WriteLine();

#endregion

#region
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

//chiama il metodo di instanza per far sposare i due
lamech.Marry(adah);

//Chiama ora il metodo statico per gli altri due 
//Person.Marry(lamech, zillah);

if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

//chiama il metodo di istanza per procreare un bambino
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

//chiama il metodo statico per procreare
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

//uso dell'operatore *
Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = lamech * zillah;
baby4.Name = "Namaah";

lamech.WriteChildrenToConsole();
adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();

for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine(format: "{0}'s child #{1} is named \"{2}\".", arg0: lamech.Name, arg1: i, arg2: lamech.Children[i].Name);
}

#endregion

#region Non-generic types

System.Collections.Hashtable lookUpObject = new();

lookUpObject.Add(key: 1, value: "Alpha");
lookUpObject.Add(key: 2, value: "Beta");
lookUpObject.Add(key: 3, value: "Gamma");

//Non da errore perché a livello di compilazione, qualsiasi cosa è un object.
//Il problema non è di tipo, ma di comportamento. Di default,
//queste due funzioni confrontano gli oggetti per riferimento in memoria,
//non per il loro contenuto. Se due istanze della stessa classe hanno gli stessi
//dati ma sono oggetti diversi in memoria, la Hashtable li considererà chiavi diverse
//e potresti non trovare mai l'elemento che cerchi. L'errore non si manifesta in fase di compilazione,
//ma a runtime con risultati inaspettat
lookUpObject.Add(key: harry, value: "Delta");

int key = 2;

WriteLine();
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookUpObject[key]);
WriteLine(format: "Key {0} has value: {1}", arg0: harry, arg1: lookUpObject[harry]);

#endregion

#region Generic types

Dictionary<int, string> lookUpIntString = new();

lookUpIntString.Add(key: 1, value: "Alpha");
lookUpIntString.Add(key: 2, value: "Beta");
lookUpIntString.Add(key: 3, value: "Gamma");
//lookUpIntString.Add(key: harry, value: "Delta"); //output: non si può convertire packt.shared.person a int
// Il compilatore si aspetta che la classe che usi come TKey implementi un metodo per confrontare correttamente
// le sue istanze. Se la tua classe non sovrascrive i metodi Equals() e GetHashCode(), la Dictionary non sa
// come confrontare i tuoi oggetti basandosi sul loro contenuto. Di conseguenza, il Dictionary utilizza il
// comportamento predefinito che confronta gli oggetti per riferimento in memoria, il che è raramente ciò che
// si desidera. Se provi a recuperare una chiave con un oggetto diverso ma con lo stesso contenuto, la ricerca fallirà.
// Questo comportamento scorretto viene spesso percepito come un errore o porta a una KeyNotFoundException a runtime
lookUpIntString.Add(key: 4, value: "Delta");

key = 3;

WriteLine();
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookUpIntString[key]);

#endregion

#region Events

WriteLine();
harry.Shout += Harry_shout; //assegnare il metodo all'evento delegato Shout
harry.Shout += Harry_Shout_2;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

WriteLine();
Person?[] people= //creiamo un array di persone, alcune con nome null, altre con l'oggetto null
{
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Eve" }
};

OutputPeopleNames(people, "Initial list of people:"); //mostra la lista iniziale

Array.Sort(people); //ordina l'array

OutputPeopleNames(people, "After sorting using Person's IComparable implementation:"); 
WriteLine();

Array.Sort(people, new PersonComparer()); //ordina l'array usando la classe PersonComparer
OutputPeopleNames(people, "After sorting using PersonComparer:");

#endregion

#region Implicit and Explicit interfaces implementation

Human human = new();

human.lose(); //chiama il metodo lose di Human in modo implicito

//Per chiamarlo in modo esplicito, ci sono due modi
((IGamePlayer)human).lose(); //cast esplicito

IGamePlayer player = human as IGamePlayer;
player.lose();

#endregion

#region Inheritance from classes

Employee john = new()
{
    Name = "John Jones",
    Born = new(1990, 7, 28, 0, 0, 0, TimeSpan.Zero)
};

WriteLine();
john.WriteToConsole();

WriteLine();
john.EmployeeCode = "JJ001";
john.HireDate = new(2014, 11, 23);
WriteLine($"{john.Name} was hired on {john.HireDate:yyyy-MM-dd} and has employee code {john.EmployeeCode}.");

#endregion

#region Overriding methods

WriteLine(john.ToString());

WriteLine();
Employee aliceInEmployee = new()
{
    Name = "Alice",
    EmployeeCode = "AA123"
};

Person aliceInPerson = aliceInEmployee; //upcasting, non serve il cast esplicito
aliceInEmployee.WriteToConsole(); //chiama Employee.WriteToConsole()
aliceInPerson.WriteToConsole(); //chiama Person.WriteToConsole()
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString()); //chiama Employee.ToString() perché è override

#endregion

#region Cast

// per controllare il tipo, aggiungo un if
WriteLine();
if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} is an employee.");

    //Per ridurre il codice, posso evitare di scrivere questa riga e inserire il cast direttamente nell'if
    //Employee explictAlice = (Employee)aliceInPerson; 
}

#endregion

#region cast with 'as'

//uso 'as' per il cast sicuro
Employee? aliceAsEmployee = aliceInPerson as Employee;

//se il cast fallisce, aliceAsEmployee sarà null
if (aliceInPerson is not null)
{
    WriteLine($"{nameof(aliceInPerson)} is an employee.");
}

#endregion

#region PersonException

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1990, 7, 1));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}

#endregion

#region Regular expressions

string email1 = "andrea1@test.com";
string email2 = "andrea2test.com"; //non è una email valida

WriteLine();
WriteLine("{0} is a valid email address: {1}", arg0: email1, arg1: email1.IsValidEmail());
WriteLine("{0} is a valid email address: {1}", arg0: email2, arg1: email2.IsValidEmail()); //esce anche IsNormalized perché fa parte delle estensioni (this)

#endregion

#region record

C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill"; //posso cambiare il valore perché è mutabile

C2 c2 = new( Name: "Bob");
//c2.Name = "Bill"; //errore: non posso cambiare il valore perché è immutabile

S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill"; //posso cambiare il valore perché è mutabile

S2 s2 = new( Name: "Bob");
s2.Name = "Bill"; //posso cambiare il valore perché è mutabile

S3 s3 = new( Name: "Bob");
//s3.Name = "Bill"; //errore: non posso cambiare il valore perché è immutabile

#endregion

#region memory

WriteLine();
DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1+dv2;

WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

WriteLine();
DisplacementVector dv4 = new();
WriteLine($"({dv4.X}, {dv4.Y})");

WriteLine();
DisplacementVector dv5 = new(3, 5);
WriteLine($"dv1.Equals(dv5): {dv1.Equals(dv5)}");
WriteLine($"dv1 == dv5: {dv1 == dv5}"); //errore perché è struct e non si può comparare con "=="; con "record" però non generà errore

#endregion