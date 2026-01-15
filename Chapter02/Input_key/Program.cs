using System; // Necessario per Console, ConsoleKeyInfo, ReadKey, WriteLine

namespace ConsoleInputExample // Un namespace per organizzare il tuo codice
{
    class Program // La classe principale del tuo programma
    {
        static void Main(string[] args) // Il punto di ingresso del programma
        {
            // Scrive un messaggio sulla console senza andare a capo
            Console.Write("Premi una combinazione di tasti: ");

            // Legge il tasto premuto dall'utente.
            // ReadKey() attende che l'utente prema un tasto e restituisce un oggetto ConsoleKeyInfo
            // che contiene informazioni sul tasto premuto, il carattere e i modificatori (es. Shift, Ctrl, Alt).
            ConsoleKeyInfo key = Console.ReadKey();

            // Va a capo dopo che il tasto è stato premuto, per una migliore leggibilità dell'output successivo
            Console.WriteLine();

            // Scrive le informazioni sul tasto premuto utilizzando la formattazione composita.
            // {0} sarà sostituito da key.Key (il tasto, es. 'A', 'Enter', 'Escape')
            // {1} sarà sostituito da key.KeyChar (il carattere associato al tasto, es. 'a', 'b', '1')
            // {2} sarà sostituito da key.Modifiers (i tasti modificatori premuti, es. 'Shift', 'Control', 'Alt')
            Console.WriteLine("Tasto: {0}, Carattere: {1}, Modificatori: {2}",
                              arg0: key.Key,
                              arg1: key.KeyChar,
                              arg2: key.Modifiers);

            // Questa riga è opzionale, ma utile in un'applicazione console per evitare che la finestra si chiuda
            // immediatamente dopo aver mostrato l'output, permettendo all'utente di leggerlo.
            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}