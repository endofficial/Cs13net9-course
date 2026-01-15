#region Practice exception handling
while (true)
{
  
    // print a message to the console
    Write("Enter a number between 0 and 255: ");

    // read a line from the console
    String? number = ReadLine();

    bool Checkvalue = int.TryParse(number, out int value);

    if (Checkvalue == false)
    {
        WriteLine();
        WriteLine("The input type is not valid.");
        WriteLine();
        WriteLine("Press 'X' or 'x' to exit or press another key to continue...");
        WriteLine();
        goto exit;
    }


    WriteLine();
    Write("Enter a another number between 0 and 255: ");
    String? anotherNumber = ReadLine();

    WriteLine();

    try
    {
        // parse the input strings to byte
        byte num = byte.Parse(number!);
        byte anotherNum = byte.Parse(anotherNumber!);

        // calculate the result of division
        int result = num / anotherNum;
        WriteLine($"{num} divided by {anotherNum} is {result}");
        WriteLine();
    }

    // print a error message if the input isn't a valid type
    catch (FormatException ex)
    {
        WriteLine($"{ex.GetType}: {ex.Message}");
        //WriteLine("FormatException: Input string wasn't in a correct format");
    }

    WriteLine();
    WriteLine("Press 'X' or 'x' to exit or press another key to continue...");
    WriteLine();

  exit:
    // read a key from the console for exit or continue
    ConsoleKeyInfo tastoPremuto = ReadKey(true);

    if (tastoPremuto.Key == ConsoleKey.X)
    {
        break;
    }
}
#endregion

