namespace Packt.Shared;

public class Person : IComparable<Person?>
{
    #region Properties

    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    public List<Person> Children { get; set; } = new();

    public List<Person> Spouses { get; set; } = new();
    public bool Married => Spouses.Count > 0; //Questa proprietà è vera solo se la lista children ha almeno un elemento

    #endregion

    #region Methods

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}");
    }

    public void WriteChildrenToConsole()
    {
        string term = Children.Count == 1 ? "child" : "children"; // è un if-else; se è vera darà child altrimenti children
        WriteLine($"{Name} has {Children.Count} {term}");
    }

    //Metodo statico
    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        // Se entrambi sono veri, viene lanciato l'errore
        if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(string.Format("{0} is already married to {1}", arg0: p1.Name, arg1: p2.Name));
        }

        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }

    //Metodo di istanza
    public void Marry(Person partner)
    {
        Marry(this, partner); //this rappresenta la persona corrente
    }

    public void OutputSpouses()
    {
        if (Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";

            WriteLine($"{Name} is married to {Spouses.Count} {term}");

            foreach (Person spouse in Spouses)
            {
                WriteLine($"    {spouse.Name}");
            }
        }
        else
        {
            WriteLine($"{Name} is a singleton.");
        }
    }

    /// <summary>
    /// Static method to "multiply" aka procreate and have a child together.
    /// </summary>
    /// <param name="p1">Parent 1</param>
    /// <param name="p2">Parent 2</param>
    /// <returns>A Person object that is the child of Parent 1 and Parent 2.</returns>
    /// <exception cref="ArgumentNullException">If p1 or p2 are null.</exception>
    /// <exception cref="ArgumentlException">If p1 and p2 are not married.</exception>
    //Metodo statico per la procreazione
    public static Person Procreate(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
        {
            throw new ArgumentNullException(string.Format("{0} must be married to {1} to procreate with them.", arg0: p1.Name, arg1: p2.Name));
        }

        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}.",
            Born = DateTimeOffset.Now
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }

    //Metodo di instanza
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner); //si utilizza return perché il metodo statico non è un void, si aspetta un ritorno
    }

    #endregion

    #region Operators

    public static bool operator +(Person p1, Person p2)
    {
        Marry(p1, p2);

        return p1.Married && p2.Married;
    }

    public static Person operator *(Person p1, Person p2)
    {
        return Procreate(p1, p2);
    }

    #endregion

    #region Events

    public event EventHandler? Shout; //delegate per definire il tipo di evento

    public int AngerLevel; //serve per tenere traccia del livello di rabbia. E' public perché deve essere accessibile dall'esterno

    public void Poke()
    {
        AngerLevel++;

        if (AngerLevel < 3) return;

        /*if (Shout is not null)
        {
            Shout(this, EventArgs.Empty);
        }*/

        //In maniera più elegante
        Shout?.Invoke(this, EventArgs.Empty); //se shout non è null, invoca l'evento. In questo caso non passo nessun argomento, quindi uso EventArgs.Empty
    }

    public int CompareTo(Person? other) //perché ho aggiunto IComparable<Person?> all'inizio della classe
    {
        int position;

        if (other is not null)
        {
            if ((Name is not null) && (other.Name is not null))
            {
                position = Name.CompareTo(other.Name);
            }
            else if ((Name is not null) && (other.Name is null))
            {
                position = -1; //se this ha un nome e other no, this viene prima
            }
            else if ((Name is null) && (other.Name is not null))
            {
                position = 1;
            }
            else
            {
                position = 0;
            }
        }
        else if (other is null)
        {
            position = -1; //se other è null, this viene prima
        }
        else
        {
            position = 0;
        }
        return position;
    }

    #endregion

    #region Overriding members

    public virtual string ToString()
    {
        return $"{Name} is a {base.ToString()}.";
    }

    #endregion

    #region Method Exception 

    public void TimeTravel(DateTime when)
    {
        //se la data in input è minore della data di nascita
        if (when <= Born)
        {
            throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode", null);
        }
        else
        {
            WriteLine($"Welcome to {when:yyyy}!");
        }
    }

    #endregion
}

#region Implicit and explicit interface implementation

//creo un'interfaccia per l'implementazione implicita ed esplicita
public interface  IGamePlayer
{
    void lose();
}

public interface  IKeyHolder
{
    void lose();
}

public class Human : IGamePlayer, IKeyHolder
{
    //implementazione implicita
    public void lose()
    {
        WriteLine("You lost the key.");
    }
    //implementazione esplicita
    void IGamePlayer.lose()
    {
        WriteLine("You lost the game.");
    }
}

#endregion