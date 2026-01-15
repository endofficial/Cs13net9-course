partial class Program
{
    // Helper method to output a collection with a title
    private static void OutputCollection<T>(string title, IEnumerable<T> collection)
    {
        WriteLine(title);

        // itera attraverso gli elementi della collezione e li stampa
        foreach (T item in collection)
        {
            WriteLine($"    {item}");
        }
    }

    private static void OutputPQ<TElement, TPriority>(string title, IEnumerable<(TElement Element, TPriority Priority)> collection)
    {
        WriteLine($"{title}:");
        foreach ((TElement, TPriority) item in collection)
        {
            WriteLine($"    {item.Item1}:  {item.Item2}");
        }
    }

    //creare un metodo a cui dovrebbe essere fornito un dizionario readonly con stringa
    private static void UseDictionary(IDictionary<string, string> dictionary)
    {
        WriteLine();
        WriteLine($"Count before is {dictionary.Count}."); // stampa il conteggio degli elementi nel dizionario
        try
        {
            WriteLine("Adding new item with GUID values.");
            //Aggiungi un metodo che ritorna un tipo di void
            dictionary.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
        catch (NotSupportedException ex)
        {
            WriteLine($"This dictionary does not supported the Add method");
        }
        WriteLine($"Count after is {dictionary.Count}."); // stampa il conteggio degli elementi nel dizionario
    }
}