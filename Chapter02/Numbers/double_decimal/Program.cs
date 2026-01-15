using System;

// darà falso poiché i numeri double sono più accurati rispetto ai float
Console.WriteLine("Usign doubles: ");
double a = 0.1;
double b = 0.2;
if (a + b == 0.3)
{
    Console.WriteLine($"{a} + {b} equals {0.3}");
}
else
{
    Console.WriteLine($"{a} + {b} does not equal {0.3}");
}

// questo darà vero poiché i numeri float sono meno accurati rispetto ai double
Console.WriteLine("Float using: ");
float c = 0.1f;  
float d = 0.2f;
if (c + d == 0.3f)
{
    Console.WriteLine($"{c} + {d} equals {0.3f}");
}
else
{
    Console.WriteLine($"{c} + {d} does not equal {0.3f}");
}

// darà vero poiché i numeri decimali sono precisi per le operazioni decimali   
Console.WriteLine("Using decimal: ");
decimal e = 0.1M;
decimal f = 0.2M;
if (e + f == 0.3M)
{
    Console.WriteLine($"{e} + {f} equals {0.3M}");
}
else
{
    Console.WriteLine($"{e} + {f} does not equal {0.3M}");
}