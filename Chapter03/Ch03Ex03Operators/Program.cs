using Microsoft.Extensions.Logging;
ILogger logger;

partial class Program
{
    private ILogger logger;

    public Program(ILogger logger)
    {
        this.logger = logger;
    }

    public void Esegui()
    {
        try
        {
            int x = 10;
            int y = 0;
            int result = x / y;
            Console.WriteLine(result);
        }

        catch (DivideByZeroException ex )
        {
            this.logger.LogError(ex, "Errore di divisione per zero.");
        }
    }
}
