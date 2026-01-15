using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;

//Sto implemetando l'interfaccia IComparer<T> per confrontare due oggetti di tipo Person. Questo è utile 
//quando voglio ordinare ma non ho accesso alla classe Person per implementare IComparable<T>.
public class  PersonComparer : IComparer<Person?>
{
    public int Compare(Person? x, Person? y)
    {
        int position;
        if ((x is not null) && (y is not null))
        {
            if ((x.Name is not null) && (y.Name is not null))
            {
                int result = x.Name.Length.CompareTo(y.Name.Length); //confronta le lunghezze dei nomi

                if (result == 0)
                {
                    return x.Name.CompareTo(y.Name);
                }
                else
                {
                    position = result;
                }
            }
            else if ((x.Name is not null) && (y.Name is null))
            {
                position = -1; //se x ha un nome e y no, x viene prima
            }
            else if ( (x.Name is null) && (y.Name is not null))
            {
                position = 1; //se x non ha un nome e y si, y viene prima
            }
            else
            {
                position = 0; //se entrambi non hanno un nome, sono uguali
            }
        }
        else if ((x is not null) && (y is null))
        {
            position = -1; 
        }
        else if ((x is null) && (y is not null))
        {
            position = 1;
        }
        else
        {
            position = 0;
        }
        return position;
    }
}