/*string actualPassword = "Pa$$word"; // Rimosso il nullable operator "?" per evitare problemi di runtime.
string? password = null;

do
{
    if (password == null)
    {
        Write("Enter your password: ");
        password = ReadLine();
    }
    else
    {
        while (true)
        {
            if (password != actualPassword)
            {
                WriteLine("Password is incorrect, try again!");
                WriteLine();
                Write("Enter your password: ");
                password = ReadLine();
                break; // Esce dal ciclo while interno per richiedere nuovamente la password
            }
        } 
    }
}
while (password != actualPassword); // questa istruzione continua a richiedere l'input finché la password non è corretta

WriteLine("Password is correct!");*/


/*for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}

WriteLine();

for (int l = 0; l <= 10; l+=3 )
    { 
        WriteLine(l); 
    }*/

string[] names = { "Alice", "Bob", "Charlie", "Diana" };

foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}