using static System.Console;
using Exercise_PrimeFactorsLib;

while (true)
{
    Write("Inserisci un numero scelto nell'intervello tra 1 e 1000: ");

    if (int.TryParse(ReadLine(), out int number))
    { 
        WriteLine("Il numero scelto è: {0}. La sua scomposizione in fattori primi è: {1}", arg0: number, arg1: PrimeFactorsLib.PrimeFactors(number));
    }

    WriteLine("Premi 'e' per uscire o 'invio' per continuare");
    string? E = ReadLine();
    if (E == "e")
    {
        break;
    }
}
