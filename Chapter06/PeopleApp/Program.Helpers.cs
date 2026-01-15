using Packt.Shared;

partial class Program
{
    private static void OutputPeopleNames(IEnumerable<Person?> people, string title)
    {
        WriteLine(title);
        foreach (Person? p in people)
        {
            WriteLine(" {0}", p is null ? "<null> Person" : p.Name ?? "<null> Name"); //se p è null, scrivi <null> Person, altrimenti se p.Name è null scrivi <null> Name, altrimenti scrivi p.Name
        }
    }
}
