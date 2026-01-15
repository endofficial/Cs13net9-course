using Packt.Shared;

partial class Program //è partial perché la classe Program è divisa in più file
{
    private static void Harry_shout(object? sender, EventArgs e) //metodo che gestisce l'evento
    {
        if (sender is null) return; //se il mittente non c'è, non fare nulla

        //se il mittende non è un oggetto di person, non fare nulla altrimenti assegna
        if (sender is not Person p) return;

        WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
    }

    private static void Harry_Shout_2(object? sender, EventArgs e)
    {
        WriteLine("Stop it");
    }
}
