using System;

class Program
{
    static void Main(string[] args)
    {
        /*ConsoleKeyInfo keyInfo;

        string password = Console.ReadLine();

        if (password.Length < 8)
        {
            WriteLine("Your password is short. Use at least 8 chars");
        }
        else
        {
            WriteLine("Your password is strong");
        }

        // fare in modo che se la variabile O è uguale a un int, assegnare alla variabile i
        while (true)
        {
            WriteLine("Inserisci un numero: ");
            var o = Console.ReadLine();
            int j = 2;

            if (int.TryParse(o, out int i)) // int.tryparse è un metodo che prova a convertire una stringa in un int. Fornisce un valore true se la conversione ha successo, altrimenti false. Out int i significa che se la conversione ha successo, i conterrà il valore convertito.
            {
                WriteLine($"{i} x {j} = {i * j}");
            }

            else
            {
                WriteLine("The variable is not an int");
            }

            WriteLine("Press any key to continue or 'q' to quit");
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar=='q' || keyInfo.KeyChar=='Q')
            {
                WriteLine("\nUscita dal programma");
                break; // interrompe il ciclo while
            }
        }

        // utilizzo di Switch. 
        // Generare un numero casuale tra  1 e 6

        for (int i = 0; i < 7; i++)
        {
            int number = Random.Shared.Next(minValue: 1, maxValue: 7);
            WriteLine($"Il numero generato è: {number}");
                
            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break; // il break serve per uscire dallo switch
                case 2:
                    WriteLine("Two");
                    goto case 1; // il goto serve per saltare a un'etichetta specifica
                case 3:
                    WriteLine("three");
                    goto case 1;
                case 4:
                    WriteLine("four");
                    goto case 1;
                case 5:
                    WriteLine("five");
                    goto A_label; // il goto serve per saltare a un'etichetta specifica
                default:
                    WriteLine("Default");
                    break;
            }
            WriteLine("After end of switch");
            A_label:
            WriteLine($"After A_label");
        }*/

        // Esempio di utilizzo di classi e oggetti

        var animals = new Animal?[]
            {
                new Cat { Name = "Micio", Born = new(year: 2022, month: 8, day: 23), Legs = 4, IsDomestic = true },
                null,
                new Cat { Name = "Felix", Born = new(year: 2021, month: 5, day: 15) },
                new Spider { Name = "Aragog", Born = DateTime.Today, Legs = 8, IsVenomous = true },
                new Spider { Name = "Charlotte", Born = new(year: 2020, month: 3, day: 10), Legs = 8 }
            };

        foreach (Animal? animal in animals) // foreach itera ogni singolo elemento della collezione animals e la variabile animal assume il valore di ogni singolo elemento della collezione
        {
            // commento tutto il codice seguente per mostare un altro modo per ottenere lo stesso risultato con le semplificazioni switch
            /*string message;

            switch (animal)
            {
                case Cat fourLeggedCat when fourLeggedCat.Legs == 4: message = $"The cat named {fourLeggedCat.Name} has four legs.";
                break;
                case Cat wildcat when wildcat.IsDomestic == false: message = $"The non-domestic cat is named {wildcat.Name}.";
                break;
                case Cat cat: message = $"The cat is named {cat.Name}";
                break;

                // il default viene eseguito se nessuno dei casi precedenti viene soddisfatto
                default: message = $"{animal.Name} is a {animal.GetType().Name}."; // stampa il nome dell'animale e il tipo di animale
                break;

                case Spider spider when spider.IsVenomous: message = $"{spider.Name} is a venomous spider.";
                break;
                case null: message = "This animal is null.";
                break;
            }*/

            string message = animal switch
            {
                Cat fourLeggedCat when fourLeggedCat.Legs == 4 => $"The cat named {fourLeggedCat.Name} has four legs.",
                Cat wildcat when wildcat.IsDomestic == false => $"The non-domestic cat is named {wildcat.Name}.",
                Cat cat => $"The cat is named {cat.Name}",
                Spider spider when spider.IsVenomous => $"{spider.Name} is a venomous spider.",
                null => "This animal is null",
                
                // default è: _
                _ => $"{animal.Name} is a {animal.GetType().Name}."
            };

            WriteLine($"Switch statements: {message}");
        }

    }
}



