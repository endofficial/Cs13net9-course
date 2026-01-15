using System.Text;

//Indichiamo la variabile phrase
var phrase = "JACQUELINE E' SPERTA ";

//nomino la classe StringBuilder come manyPhrases
var manyPhrases = new StringBuilder();

//creo il ciclo
for (var i = 0; i < 10000; i++)
{
    //prende la stringa phrase e la aggiunge alla fine dell'oggetto StringBuilder chiamato manyPhrase
    manyPhrases.Append(phrase);
}

// si può scrivere in questo modo ma io preferisco andare a capo dopo il punto e virgola
int sum = 2 + 1; int sum1 = 3 + 1;

Console.WriteLine("tra" + manyPhrases);
Console.WriteLine(sum + sum1);

Console.WriteLine( $"Computer named {Environment.MachineName} says \"No.\"");
