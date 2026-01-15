using System.Text.RegularExpressions; // Importing the Regex class for regular
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#region Regular Expressions

//Se come input viene fornita una stringa contenente almeno una cifra, il programma risponderà con "Valid age input."

Write("Enter your age: ");
string input = ReadLine()!; // ! è un operatore di null-forgiving che indica al compilatore che input non sarà null
//Regex ageChecker = new Regex(@"\d"); // Questo pattern verifica la presenza di almeno una cifra

//Regex ageChecker = new Regex(@"^\d+$"); // questo pattern verifica che l'input sia esattamente una singola cifra e con il + gestisce anche numeri con più cifre
//Regex ageChecker = new(DigitsOnlyText);
Regex ageChecker = DigitsOnly;

WriteLine(ageChecker.IsMatch(input) ? "Valid age input." : $"Invalid age input: {input}");

#endregion

#region Splitting CSV with Regex

string films = """"Monsters, Inc.", "Tonya", "Lock, Stock and Two Smoking Barrels"""";

WriteLine($"\nFilms to split: {films}\n");

string[] filmsDumb = films.Split(','); // Metodo Split semplice che divide la stringa in base agli spazi

WriteLine("Splitting with string.Split method: ");
foreach (string film in filmsDumb)
{
    WriteLine(film);
}

//Regex csv = new("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
//Regex csv = new(CommaSeparatortext);
Regex csv = CommaSeparator;

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("\nSplitting with Regex:\n");
foreach (Match film in filmsSmart)
{
    WriteLine(film.Groups[2].Value);
}

WriteLine();

#endregion

#region Common feature of all collections

public interface ICollection : IEnumerable // con ICollections ci deve essere sempre una proprietà count e altre tre proprietà
{
    int Count { get; }
    bool IsSynchronized { get; } // indica se la collezione è thread-safe, cioè se può essere usata in modo sicuro da più thread contemporaneamente
    object SyncRoot { get; } // fornisce un oggetto che può essere usato per sincronizzare l'accesso alla collezione
    void CopyTo(Array array, int index); // copia gli elementi della collezione in un array a partire da un indice specificato
}

public interface IEnumerable // interfaccia che permette di iterare su una collezione
{
    IEnumerator GetEnumerator(); // restituisce un enumeratore che può essere usato per iterare sulla collezione
}

public interface IEnumerator // interfaccia che permette di iterare su una collezione
{
    object? Current { get; } // restituisce l'elemento corrente nella collezione
    bool MoveNext(); // sposta l'enumeratore al prossimo elemento della collezione
    void Reset(); // reimposta l'enumeratore alla posizione iniziale, prima del primo elemento della collezione
}

public interface ICollection<T> : IEnumerable<T>, IEnumerable
{
    int Count { get; } // proprietà che restituisce il numero di elementi nella collezione
    bool IsReadOnly { get; } // proprietà che indica se la collezione è di sola lettura
    void Add(T item); // metodo per aggiungere un elemento alla collezione
    void Clear(); // metodo per rimuovere tutti gli elementi dalla collezione
    bool Contains(T item); // metodo per verificare se un elemento è presente nella collezione
    void CopyTo(T[] array, int arrayIndex); // metodo per copiare gli elementi della collezione in un array a partire da un indice specificato
    bool Remove(T item); // metodo per rimuovere un elemento specifico dalla collezione
}

//[DefaultMember("Item")] // attributo che specifica il membro predefinito della classe, in questo caso l'indicizzatore "Item"
public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    T this[int index] { get; set; } // indicizzatore per accedere agli elementi della collezione tramite un indice
    int IndexOf(T item); // metodo per ottenere l'indice di un elemento specifico nella collezione
    void Insert(int index, T item); // metodo per inserire un elemento in una posizione specifica della collezione
    void RemoveAt(int index); // metodo per rimuovere l'elemento in una posizione specifica della collezione
}

#endregion