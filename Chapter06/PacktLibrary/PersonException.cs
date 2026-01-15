namespace Packt.Shared;

public class PersonException : Exception
{
    //è il costruttore di default che nel caso in cui viene chiamato, genera un'eccezione senza messaggio come di default del costruttore della classe base
    public PersonException() : base()
    {
    }

    // questo costruttore consente di passare un messaggio di errore personalizzato. Il messaggio viene passato al costruttore della classe base Exception
    public PersonException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

