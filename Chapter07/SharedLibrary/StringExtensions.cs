using System.Text.RegularExpressions; // Required for Regex

namespace Packt.Shared;

public static class StringExtensions
{
    public static bool IsValidXmlTags(this string input)
    {
        return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
    }

    public static bool IsValidPassword(this string input)
    {
        //Minimo 8 caratteri
        return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
    }

    public static bool IsValidHex(this string input)
    {
        //Tre o sei cifre esadecimali
        return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
    }
}