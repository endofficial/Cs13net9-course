using System.Diagnostics.CodeAnalysis; // to use [SetRequiredMembers]

namespace PacktLibraryModern

{
    public class Book
    {
        // Si può dalla versione di .NET 7 O C# 11
        public required string? Isbn; //required serve per indicare che questo è una proprietà obbligatoria e deve essere inizializzata
        public required string? Title;

        public string? Author;
        public int PageCount;

        // Costruttore da utilizzare con la sintassi dell'inizializzatore di oggetti.
        public Book() { }

        [SetsRequiredMembers] // indica che questo costruttore imposta tutti i membri obbligatori e in Program.cs non darà errore
        // costruttore con i parametri per settare le proprietà obbligatorie
        public Book(string? isbn, string? title)
        {
            Isbn = isbn;
            Title = title;
        }
    }
}
