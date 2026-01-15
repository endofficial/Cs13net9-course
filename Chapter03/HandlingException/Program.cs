#region Wrapping error-prone code in a try block

WriteLine("Before parsing");
Write("What is your age? ");
string? input = ReadLine();


if (input is null)
{
  WriteLine("You did not enter a value so the app has ended.");
  return; // Exit the app.
}


try
{
    int age = int.Parse(input!);
    WriteLine($"You are {age} years old.");
}
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it's either too big or small.");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
    // WriteLine(ex.StackTrace);  specifica dove avviene l'errore
}

WriteLine("After parsing");

#endregion 

#region

Write("Enter the amount: ");
string amount = ReadLine()!;
if (string.IsNullOrEmpty(amount)) return;

try
{
    decimal amountValue = decimal.Parse(amount);
    WriteLine($"The amount is {amountValue:C}.");
}
catch (FormatException) when (amount.Contains('$'))
{
    WriteLine("The amount cannot contain a dollar sign.");
}
catch (FormatException)
{
    WriteLine("Amounts must only contain digits!");
}
#endregion

#region overflow

checked // checked è utile per verificare gli overflow 
{
    try
    {
        int x = int.MaxValue - 1;
        WriteLine($"Initial value: {x}");
        x++;
        WriteLine($"After incrementing: {x}");
        x++;
        WriteLine($"After incrementing again: {x}");
        x++;
        WriteLine($"After incrementing again: {x}");
    }
    catch (OverflowException)
    {
        WriteLine("The code overflowed but i caught the exception");
    }
}


#endregion

#region Disabling compiler overflow checks

unchecked // This disables overflow checking for the code block
{
    int y = int.MaxValue + 1; // senza unchecked, il compilatore segnala un errore di overflow
    WriteLine($"The value of y is {y}.");
    y--;
    WriteLine($"After decrementing, the value of y is {y}.");
    y--;
    WriteLine($"After decrementing again, the value of y is {y}.");
}


#endregion