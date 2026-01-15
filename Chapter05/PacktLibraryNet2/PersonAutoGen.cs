namespace Packt.Shared;

// Questo file simula una classe generata automaticamente

public partial class Person
{
    #region Properties: Method to get and/or set data or state

    // property di sola lettura definita usando la sintassi da C#1 a 5
    // Questo non è il miglior modo per calcolare l'età di qualcuno
    public string Origin
    {
        get
        {
            return string.Format("{0} was born on {1}.", arg0: Name, arg1: HomePlanet);
        }
    }

    // due property di sola lettura definite usando la sintassi da C#6 in poi
    public string Greeting => $"{Name} says 'Hello'!";

    public int Age => DateTime.Today.Year - Born.Year;

    public string? FavoriteIceCream { get; set; } // a read-write property with C# 3 syntax

    // per memorizzare i dati, creare una backing field privata
    private string? _favoritePrimaryColor; // backing field

    public string? FavoritePrimaryColor
    {
        get
        {
            return _favoritePrimaryColor;
        }

        set
        {// con value si indica che è un valore stringa
            switch (value?.ToLower()) // Tolower serve per rendere il confronto case 'insensitive', cioè non fa differenza tra maiuscole e minuscole
            {
                case "red":
                case "green":
                case "blue":
                    _favoritePrimaryColor = value;
                    break;
                default:
                    throw new ArgumentException($"{value} is not a primary color. Choose from: red, green, blue.");
            }
        }
    }

    private WondersOfTheAncientWorld _favoriteAncientWonder; // backing field

    public WondersOfTheAncientWorld FavoriteAncientWonder
    {
        get
        {
            return _favoriteAncientWonder;
        }
        set
        {
            string wondername = value.ToString();

            if (wondername.Contains(','))
            {
                throw new ArgumentException(message: "Favorite ancient wonder can only have a single enum value.", paramName: nameof(FavoriteAncientWonder));
            }

            /* Questo blocco di codice, come hai notato con il commento,
             usa il metodo statico Enum.IsDefined per verificare
             se il valore assegnato (value) fa effettivamente parte
             dell'enumerazione WondersOfTheAncientWorld.
             Se il valore non corrisponde a nessuno dei membri definiti
             (ad esempio, un numero intero casuale come 999),
             il codice lancia un'altra ArgumentException, fornendo un messaggio chiaro*/
            if (!Enum.IsDefined(typeof(WondersOfTheAncientWorld), value))
            {
                throw new ArgumentException(
                  $"{value} is not a member of the WondersOfTheAncientWorld enum.",
                  paramName: nameof(FavoriteAncientWonder));
            }

            _favoriteAncientWonder = value;
        }
    }
    #endregion

    #region Indexers: Properties that use array syntax to access them

    //Per definire un indicizzatore, si usa la parola chiave this seguita da una lista di parametri tra parentesi quadre.
    public Person this[int index]
    {
        get
        {
            return Children[index];
        }
        set
        {
            Children[index] = value;
        }
    }

    // Questo indicizzatore cerca un figlio per nome
    public Person this[string name]
    {
        get
        {
            return Children.Find(p => p.Name == name);
        }
    }

    #endregion
}