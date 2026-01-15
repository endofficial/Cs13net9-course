using System.Text.RegularExpressions; //questo serve per Regex: libreria per le espressioni regolari che servono per manipolare le stringhe 

namespace Packt.Shared;

public static class StringExtensions //con static non serve istanziare la classe per usare i suoi metodi
{
    public static bool IsValidEmail(this string input) //this string input indica che questo metodo è un'estensione della classe string
    {
        //utilizza una espressione regolare per validare che la stringa sia una email
        //a-z comprende tutte le lettere minuscole; A-Z tutte le maiuscole; 0-9 tutti i numeri;
        //\. il punto; \- il trattino; _ il sottolineato. Dopodiché si mette la chiocciola @ e si ripete
        //perché dopo la chiocciola c'è di nuovo il nome del dominio che può contenere gli stessi caratteri
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+"); 
    }
}