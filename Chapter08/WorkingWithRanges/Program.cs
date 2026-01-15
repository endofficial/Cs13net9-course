#region indexes, ranges, and spans

string name = "Samantha Jones";

//Prendere la lunghezza della stringa, dalla prima all'ultima lettera
int lenghtOfFirst = name.IndexOf(' '); // questa riga restituisce 9, cioè la posizione dello spazio
int lenghtOfLast = name.Length - lenghtOfFirst - 1; // questa riga restituisce 5, cioè la lunghezza del cognome

//Usando Substring 
string firstName = name.Substring(startIndex: 0, length: lenghtOfFirst);
string lastName = name.Substring(startIndex: name.Length - lenghtOfLast, length: lenghtOfLast);

WriteLine($"First: {firstName}, Last: {lastName}");

// usando spans
ReadOnlySpan<char> nameAsSpan = name.AsSpan(); // converte la stringa in uno span di caratteri
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lenghtOfFirst]; // prende lo span dalla posizione 0 alla lunghezza del primo nome
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lenghtOfLast..]; // prende lo span dalla lunghezza del cognome fino alla fine

WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");

#endregion

#region

// Tutto il codice serve per sommare i numeri in una stringa separata da '+'
ReadOnlySpan<char> text = "12+23+456".AsSpan(); // converte la stringa in uno span di caratteri
int sum = 0;

foreach (Range r in text.Split('+')) // itera su ogni intervallo di caratteri separati da '+'
{
    sum += int.Parse(text[r]); // converte lo span di caratteri in un intero e lo somma a sum
}
WriteLine($"Sum using Split: {sum}"); // stampa la somma totale

#endregion