string[] names; // Declare a variable of type string array

names = new string[4]; // Declare an array of strings with 4 elements

names[0] = "Alice"; // Assign values to the array elements
names[1] = "Bob";
names[2] = "Charlie";
names[3] = "Diana";

/*Un altro modo per dichiarare, allocare in memoria e istanziare un array è:
  string [] names2 = {"Kate", "Andrea", etc...};*/

for (int i = 0; i < names.Length; i++)
{
    WriteLine($"{names[i]} is at position {i}.");
}

WriteLine();

string[,] grid1 =
{
    { "Alpha", "Beta", "Gamma", "Delta" },
    { "Anne", "Ben", "Charlie", "Doug" },
    { "Aardvark", "Bear", "Cat", "Dog" },
    { "Andrea", "Jennifer", "Jacqueline", "Evelyn" }
};
WriteLine($"1st dimension, lower bound: {grid1.GetLowerBound(0)}");
WriteLine($"1st dimension, upper bound: {grid1.GetUpperBound(0)}");
WriteLine($"2st dimension, lower bound: {grid1.GetLowerBound(1)}");
WriteLine($"2st dimension, upper bound: {grid1.GetUpperBound(1)}");
WriteLine();

// per esplicitare in modo chiaro la stringa di ogni singola cella si prosegue come segue

for (int row = 0; row <= grid1.GetUpperBound(0); row++)
{
    for (int col = 0; col <= grid1.GetUpperBound(1); col++)
    {
        WriteLine($"Row {row}, Column {col}: {grid1[row, col]}");
    }
}

WriteLine();

string[,] grid2 = new string[3, 4];

grid2[0, 0] = "Alpha";
grid2[0, 1] = "Beta";
grid2[2, 3] = "Dog";

#region Working with jagged arrays 

string[][] jagged =
{
    new[] { "Alpha", "Beta", "Gamma" },
    new[] { "Anne", "Ben", "Charlie", "Doug" },
    new[] { "Aardvark", "Bear" }
};

WriteLine($"Upper bound of the array of arrays is: {jagged.GetUpperBound(0)}");

for (int array = 0; array <= jagged.GetUpperBound(0); array++)
{
    WriteLine("Upper bound of array {0} is: {1}", arg0: array, arg1: jagged[array].GetUpperBound(0));
}

WriteLine();

for (int row = 0; row <= jagged.GetUpperBound(0); row++)
{
    for (int col = 0; col <= jagged[row].GetUpperBound(0); col++)
    {
        WriteLine($"Row {row}, Column {col}: {jagged[row][col]}");
    }
}
WriteLine();
#endregion

#region

int[] numsequenziali = { 1, 2, 3, 4, 5 };
int[] unodue = { 1, 2 };
int[] trequatundi = { 1, 2, 11 };
int[] quatnum = { 6, 7, 8, 9 };
int[] numprimi = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
int[] emptynum = { };
int[] trenum = { 3, 4, 5 };
int[] seinum = { 6, 7, 8, 9, 10, 11 };

WriteLine($"{nameof(numsequenziali)}: {CheckSwitch(numsequenziali)}");
WriteLine($"{nameof(unodue)}: {CheckSwitch(unodue)}");
WriteLine($"{nameof(trequatundi)}: {CheckSwitch(trequatundi)}");
WriteLine($"{nameof(quatnum)}: {CheckSwitch(quatnum)}");
WriteLine($"{nameof(numprimi)}: {CheckSwitch(numprimi)}");
WriteLine($"{nameof(fibonacci)}: {CheckSwitch(fibonacci)}");
WriteLine($"{nameof(emptynum)}: {CheckSwitch(emptynum)}");
WriteLine($"{nameof(trenum)}: {CheckSwitch(trenum)}");
WriteLine($"{nameof(seinum)}: {CheckSwitch(seinum)}");

static string CheckSwitch(int[] values) => values switch
{
    [] => "Empty Array",
    [1, 2] => "Contains 1 e 2",
    [1, 2, _, 11] => "Contains 1, 2 and only value 11",
    //[int item1, int item2, int item3 ] => $"Contains {item1} then {item2} then {item3}.",
    [_, _, _,] => "Contains 3, 4, 5",
    [1, 2, .., 5] => "Contains sequential number from 1 to 5",
    [0, ..] => "Starts with 0, then any range of numbers",
    [..] => "Any items in any order.",
};

#endregion