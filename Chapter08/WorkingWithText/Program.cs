using System.Buffers;
using System.Globalization;
using System.Runtime.CompilerServices;

OutputEncoding = System.Text.Encoding.UTF8; // Enable Euro Symbol

#region Getting the lenght of a string

string city = "New York";
WriteLine($"{city} is {city.Length} charachters long.");

#endregion

#region Getting the characters of a string

//String is an array of characters
WriteLine($"First char is {city[0]} and fifth is {city[4]}.");

#endregion

#region Splitting a string

WriteLine();
string cities = "New York,London,Madrid,Tokyo";
string[] cityArray = cities.Split(',');

WriteLine($"There are {cityArray.Length} items in the array:");
foreach (string item in cityArray)
{
    WriteLine($" {item}");
}

#endregion

#region Getting part of a string

string fullName = "John Doe";

int indexOfSpace = fullName.IndexOf(' '); // Find the first space

string firstName = fullName.Substring(startIndex: 0, length: indexOfSpace); // Get first name until space
string lastName = fullName.Substring(startIndex: indexOfSpace + 1); // Get last name after space

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

#endregion

#region checking a string for content

// Methods that return a boolean to check for content
WriteLine();
string company = "Microsoft";
WriteLine($"Text: {company}");
WriteLine("Starts with M: {0}, contains an N: {1}, and ends with t: {2}", 
    arg0: company.StartsWith('M'), 
    arg1: company.Contains('N'),
    arg2: company.EndsWith('T'));

#endregion

#region Example with different cultures

WriteLine();
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

string text1 = "Mark";
string text2 = "MARK";

WriteLine($"text1: {text1}, text2: {text2}");
// Case-sensitive comparison 
WriteLine("Compare: {0}", arg0: string.Compare(text1, text2));

// Case-insensitive comparison
WriteLine("Compare (ignorcase): {0}", arg0: string.Compare(text1, text2, ignoreCase: true));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}", arg0: string.Compare(text1, text2, StringComparison.InvariantCultureIgnoreCase)); // Use InvariantCulture for consistent results across cultures

// German culture
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

text1 = "Straße"; // German word for street
text2 = "Strasse"; // Uppercase version

WriteLine();
WriteLine($"text1: {text1}, text2: {text2}");

WriteLine("Compare: {0}", arg0: string.Compare(text1, text2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace)); // Treat 'ß' as 'ss' by ignoring non-spacing differences

WriteLine("Compare (IgnoreCase, IgnoreNonSpace): {0}", arg0: string.Compare(text1, text2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase));

WriteLine("Compare (InvariantCultureIgnoreCase): {0}", arg0: string.Compare(text1, text2, StringComparison.InvariantCultureIgnoreCase));
#endregion

#region other string methods

string recombined = string.Join(" => ", cityArray); //Join is used to recombine an array into a string
WriteLine();
WriteLine(recombined);

WriteLine();
string fruit = "  Apples  ";
decimal price = 0.39M;
DateTime when = DateTime.Today;

//Per concatenare ci sono due modi
WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}.", arg0: fruit, arg1: price, arg2: when));

#endregion

#region Searching in strings

//.NET 8
string vowels = "AEIOUaeiou";

SearchValues<char> vowelsSearchValues = SearchValues.Create(vowels); // Create SearchValues from string

ReadOnlySpan<char> text = "Fred";

WriteLine();
WriteLine($"vowels: {vowels}");
WriteLine($"text: {text}");
WriteLine($"text.IndexOfAny(vowelsSearchvalue): {text.IndexOfAny(vowelsSearchValues)}"); // Returns the index of the first vowel in text

string[] names = [ "Charlie", "Alice", "Eve", "Bob" ];

//.NET 9 and later
SearchValues<string> namesSearchValues = SearchValues.Create(names, StringComparison.OrdinalIgnoreCase); // Create SearchValues from string array

ReadOnlySpan<char> sentence = "In Andor, Alice Luna returns as the titular character Cassian Andor, to whom audiences were first introduced in Rogue One.";

WriteLine();
WriteLine($"names: {string.Join(", ", names)}");
WriteLine($"sentence: {sentence}");
WriteLine($"sentence.IndexOfAny(namesSearchValues): {sentence.IndexOfAny(namesSearchValues)}"); // Returns the index of the first name in sentence

#endregion