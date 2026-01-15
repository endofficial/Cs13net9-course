/*using System.Globalization;

// cultureInfo imposta la cultura corrente. In questo caso, la cultura è impostata su "en-US" (inglese degli Stati Uniti).
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int numberOfApples = 12;
decimal pricePerApple = 0.35M;
string personName = "Alice";

Console.WriteLine(format: "{2} buy {0} apples cost {1:C}", arg0: numberOfApples, arg1: pricePerApple * numberOfApples, arg2: personName);

string formatted = string.Format(format: "{2} buy {0} apples cost {1:C}", arg0: numberOfApples, arg1: pricePerApple * numberOfApples, arg2: personName);*/

// formattare il testo 
string applesText = "Apples";
int applesCount = 12;
string bananasText = "Bananas";
int bananasCount = 8;

Console.WriteLine();

Console.WriteLine(format: "{0, -10} {1, 6}", arg0: "Name", arg1: "Count");
Console.WriteLine(format: "{0, -10} {1, 6:}", arg0: applesText, arg1: applesCount);
Console.WriteLine(format: "{0, -10} {1, 6:}", arg0: bananasText, arg1: bananasCount);