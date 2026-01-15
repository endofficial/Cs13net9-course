#region Special float and double values

// Epsilon è un numero molto piccolo che rappresenta la differenza minima tra 1 e il numero più vicino a 1 che può essere rappresentato come un float o double.
Console.WriteLine($"double.Epsilon: {double.Epsilon}");
// Epsilon è rappresentato in notazione scientifica, quindi può essere difficile visualizzarlo in modo preciso. Così, possiamo visualizzarlo in modo più dettagliato.
Console.WriteLine($"double.Epsilon to 324 decimal places: {double.Epsilon:N324}");
Console.WriteLine($"double.Epsilon to 330 decimal places: {double.Epsilon:N330}");

// stiamo costruendo una stringa di linee per separare le sezioni del nostro output
const int col1 = 37;
const int col2 = 6;
string line = new string('-', col1 + col2 + 3); 

Console.WriteLine(line);
Console.WriteLine($"{"Exspression", -col1} | {"Value", -col2}");
Console.WriteLine(line);
Console.WriteLine($"{"double.NaN",-col1} | {double.NaN,-col2}");
Console.WriteLine($"{"double.PositiveInfinity", -col1} | {double.PositiveInfinity, -col2 }");
Console.WriteLine($"{"double.NegativeInfinity", -col1} | {double.NegativeInfinity, -col2 }");
Console.WriteLine(line);
Console.WriteLine($"{"0.0 / 0.0",-col1} | {0.0 / 0.0,col2}");
Console.WriteLine($"{"3.0 / 0.0",-col1} | {3.0 / 0.0,col2}");
Console.WriteLine($"{"-3.0 / 0.0",-col1} | {-3.0 / 0.0,col2}");
Console.WriteLine($"{"3.0 / 0.0 == double.PositiveInfinity",-col1} | {3.0 / 0.0 == double.PositiveInfinity,col2}");
Console.WriteLine($"{"-3.0 / 0.0 == double.NegativeInfinity",-col1} | {-3.0 / 0.0 == double.NegativeInfinity,col2}");
Console.WriteLine($"{"0.0 / 3.0",-col1} | {0.0 / 3.0,col2}");
Console.WriteLine($"{"0.0 / -3.0",-col1} | {0.0 / -3.0,col2}");
Console.WriteLine(line);

#endregion