using CallStackExceptionHandlingLib;
using static System.Console;

WriteLine("In Main");
Alpha();

void Alpha()
{
    WriteLine("In Alpha");
    Beta();
}

void Beta()
{
    WriteLine("In Beta");

    /*throw ex: Questo re-lancia l'eccezione originale, 
      ma il punto in cui è stata re-lanciata diventa il nuovo punto di origine nello stack di chiamate. 
      In altre parole, la traccia dello stack (stack trace) perde l'informazione 
      originale sul metodo dove è stata inizialmente creata l'eccezione.*/

    /*throw (senza specificare la variabile): Questo continua la propagazione dell'eccezione originale 
      mantenendo intatta la traccia dello stack. Questo è il metodo preferito per re-lanciare un'eccezione, 
      perché mantiene tutte le informazioni diagnostiche utili per il debug, mostrando l'intera catena di 
      chiamate che ha portato all'errore.*/
    
    try
    {
        Processor.Gamma();
    }

    catch (Exception ex)
    {
        WriteLine($"caught this: {ex.Message}");
        throw ex; // re-throws the exception
    }
}