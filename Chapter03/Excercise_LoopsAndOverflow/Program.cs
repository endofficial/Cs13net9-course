checked
{
    try
    {
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            WriteLine(i);
        }
    }
    
    catch (OverflowException ex)
    {
        WriteLine($"{ex.GetType} says {ex.Message}");
        //WriteLine("Il codice causa un overflow poiché il tipo byte accetto un valore fino a 255");
    }
    
}

