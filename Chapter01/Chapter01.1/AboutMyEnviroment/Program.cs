namespace AboutMyEnviroment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory); //stampa il percorso
            Console.WriteLine(Environment.OSVersion.VersionString); //stampa il sistema operativo utilizzato
            Console.WriteLine("Namespace: {0}", typeof(Program).Namespace ?? "<null>"); //stampa il nome del namespace
        }
    }
}
