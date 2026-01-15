using static System.Console;

partial class Program
{
    static void WhatsMyNamespace()
    {
        WriteLine("The namespace of Program class: {0}", arg0: typeof(Program).Namespace ?? "null");
    }
}
