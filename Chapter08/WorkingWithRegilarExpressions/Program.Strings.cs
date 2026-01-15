using System.Diagnostics.CodeAnalysis; //To use StringSyntax

partial class Program
{
    [StringSyntax("Regex")]
    private const string DigitsOnlyText = @"^\d+$\A";

    [StringSyntax("Regex")]
    private const string CommaSeparatortext = "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)"; // Pattern per separare stringhe CSV con virgolette

    [StringSyntax("DateTimeFormat")]
    private const string FullDateTime = "d"; // Placeholder per una regex di data completa
}