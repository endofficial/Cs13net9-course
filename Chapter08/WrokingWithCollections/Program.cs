// Definisco un alias per un dizionario di stringhe
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Frozen; // per usare FrozenDictionary<T, T>

#region List Collection Example

//sintassi semplice per creare una lista e aggiungere poi tre elementi 

List<string> cities = new();
cities.Add("Rome");
cities.Add("Milan");
cities.Add("Naples");

/* Alternative syntax that is converted by the compiler into
   the three Add method calls above.
List<string> cities = new()
  { "London", "Paris", "Milan" }; */

/* Alternative syntax that passes an array
   of string values to AddRange method.
List<string> cities = new();
cities.AddRange(new[] { "London", "Paris", "Milan" }); */

OutputCollection("Initial list", cities); // serve per stampare la lista
WriteLine($"The first city is {cities[0]}.");
WriteLine($"The last city is {cities[cities.Count - 1]}.");
WriteLine($"Are all cities longer than four characters? {cities.TrueForAll(city => city.Length > 4)}."); // verifica se tutte le città hanno più di 4 caratteri
WriteLine($"Do all cities contain the character 'e'? {cities.TrueForAll(city => city.Contains('e'))}.");

cities.Insert(0, "Sydney");
OutputCollection("After inserting Sydney at index 0", cities); // inserisce Sydney all'inizio della lista

cities.RemoveAt(1);
cities.Remove("Naples");
OutputCollection("After removing two cities", cities); // rimuove due città

#endregion

#region Working with dictionary

//sintassi semplice per creare un dizionario e aggiungere poi tre coppie chiave-valore
/*[DefaultMember("Item")]
public interface IDictionary<TKey, TValue>
    : ICollection<KeyValuePair<TKey, TValue>>,
      IEnumerable<KeyValuePair<TKey, TValue>>,
      IEnumerable
{
    TValue this[TKey key] { get; set; } // indicizza il dizionario tramite la chiave
    ICollection<TKey> Keys { get; } // restituisce una raccolta di tutte le chiavi nel dizionario
    ICollection<TValue> Values { get; } // restituisce una raccolta di tutti i valori nel dizionario
    void Add (TKey key, TValue value); // aggiunge una coppia chiave-valore al dizionario
    bool ContainsKey(TKey key); // determina se il dizionario contiene una chiave specifica
    bool Remove(TKey key); // rimuove la coppia chiave-valore con la chiave specificata
    bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) // tenta di ottenere il valore associato alla chiave specificata
}*/

#endregion

#region Dictionary Collection Example
WriteLine();
//dichiarare senza alias
//Dictionary<string, string> capitals = new Dictionary<string, string>();

// dichiarare un dizionario di stringhe con alias
StringDictionary Keywords = new();

Keywords.Add(key: "int", value: "32-bit integer data type");
Keywords.Add("long", "64-bit integer data type");
Keywords.Add("float", "Single precision floating point number");

//Sintassi alternativa per aggiungere coppie chiave-valore
/*Dictionary<string, string> keywords = new()
{
    {  "int", "32-bit integer data type" },
    { "long", "64-bit integer data type" },
    { "float", "Single precision floating point number" }
};*/

//altra sintassi alternativa
/*Dictionary<string, string> keywords = new()
{
    ["int"] = "32-bit integer data type",
    ["long"] = "64-bit integer data type",
    ["float"] = "Single precision floating point number"
};*/

OutputCollection("Dictionary keys", Keywords.Keys);
OutputCollection("Dictionary values", Keywords.Values);

WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in Keywords)
{
    WriteLine($"  {item.Key}: {item.Value}");
}

// prendere un valore usando una chiave
string key = "long";
WriteLine($"The definition of {key} is {Keywords[key]}.");

#endregion

#region sets, stacks and queues

HashSet<string> names = new(); // crea un insieme di stringhe

foreach (string name in new[] { "Adam", "Barry", "Charlie", "Betty" })
{
    bool added = names.Add(name); // Add ritorna true se l'elemento è stato aggiunto, false se era già presente
    WriteLine($"{name} was added: {added}");
}

WriteLine($"names set: {string.Join(',', names)}.");

WriteLine();
bool adding = names.Add("Adam"); // prova ad aggiungere un elemento già presente
WriteLine($"Trying to add Adam again: {adding}");
WriteLine();

//Modi comuni per lavorare con queues
Queue<string> coffe = new();

coffe.Enqueue("Damir"); 
coffe.Enqueue("Barbara");
coffe.Enqueue("Jasna");
coffe.Enqueue("Ivan");
coffe.Enqueue("Ana");

OutputCollection("Initial queue from front to back", coffe);

//servire la prima persona nella coda
string served = coffe.Dequeue();
WriteLine($"Served: {served}");

//servire la persona successiva
served = coffe.Dequeue();
WriteLine($"Served: {served}");

// mostrare lo stato attuale della coda
OutputCollection("Current queue from front to back", coffe);

WriteLine();
// mostrare la prossima persona 
WriteLine($"Next person to be served: {coffe.Peek()}"); // Peek mostra il primo elemento senza rimuoverlo
OutputCollection("Current queue from front to back", coffe);

WriteLine();
// Modi comuni per lavorare con queues prioritario
PriorityQueue<string, int> vaccine = new();

//Aggiungo alcune persone
// 1 = alta priorità, 2 = media priorità, 3 = bassa priorità

vaccine.Enqueue("Damir", 2);
vaccine.Enqueue("Barbara", 1);
vaccine.Enqueue("Jasna", 3);
vaccine.Enqueue("Ivan", 1);

OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);

WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

//Aggiungo un'altra persona con priorità media
WriteLine("Adding Mark to queue with priority 2.");
vaccine.Enqueue("Mark", 2);

WriteLine($"{vaccine.Peek()} will be next to be vaccinated.");
OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);



#endregion

#region Read-only, immutable, and frozen collections

void ReadCollection<T> (ICollection<T> collection)
{
    //Possiamo controllare se la collezione è read-only
    if (collection.IsReadOnly)
    {
        //Leggi la collezione
    }
    else
    {
        WriteLine();
        WriteLine("You have given me a collection that I could change!\n");
    }
}

//UseDictionary(Keywords); // Passa un dizionario modificabile. Così non viene generata un'eccezione

//Crea un dizionario di sola lettura a partire da uno esistente
//UseDictionary(Keywords.AsReadOnly()); // Passa un dizionario di sola lettura. Viene generata un'eccezione
UseDictionary(Keywords.ToImmutableDictionary()); // Passa un dizionario immutabile. Non funziona

//Istruzione per convertire keywords in immutabile
ImmutableDictionary<string, string> immutableKeywords = Keywords.ToImmutableDictionary();

//chiama il metodo Add con ritorno di un valore
ImmutableDictionary<string, string> newDictionary = immutableKeywords.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

OutputCollection("Immutable keywords dictionary", immutableKeywords);
OutputCollection("New dictionary after adding an item", newDictionary);

//Creare un FrozenDictionary da un dizionario esistente
FrozenDictionary<string, string> frozenKeywords = Keywords.ToFrozenDictionary();

OutputCollection("Frozen keywords dictionary", frozenKeywords); // stampa il dizionario congelato

WriteLine();
WriteLine($"Define long: {frozenKeywords["long"]}"); // accede a un elemento del dizionario congelato

#endregion