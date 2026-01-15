using static System.Console;

namespace CallStackExceptionHandlingLib
{
    public class Processor
    {
        public static void Gamma() //pubblic vuol dire che è accessibile anche dall'esterno
        {
            WriteLine("In Gamma");
            Delta();
        }

        private static void Delta() //private vuol dire che è accessibile solo all'interno della classe
        {
            WriteLine("In Delta");
            File.OpenText("bad file path");
        }
    }
}
