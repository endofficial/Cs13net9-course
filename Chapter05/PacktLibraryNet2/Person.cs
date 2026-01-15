using System;
using System.Collections.Generic;
using System.Text;
using UnnamedParameters = (string, int);


namespace Packt.Shared;

// ereditiamo 2 valori: nome e data di nascita

// partial class: la definizione della classe può essere divisa in più file
public partial class Person : Object
{
    #region

    public string? Name;
    public DateTimeOffset Born;

    //E' stato spostato in PersonAutoGen.cs
    //public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    #endregion

    #region

    public List<Person> Children = new List<Person>();

    #endregion

    #region

    public const string Species = "Homo Sapiens";

    #endregion

    #region

    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    #endregion

    #region Constructor: Called When using new to instatiate a type

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    // altro modo
    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    #endregion

    #region Methods: Actions the type can perform

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    #endregion

    #region Defining and passing parameters to methods

    public string SayHello()
    {
        return $"{Name} says 'Hello'!";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello {name}'!";
    }

    #endregion

    #region Another method to simplify methods

    public string OptionalParameters(int count, string command = "Run!", double number = 0.0, bool active = true)
    {
        return string.Format(format: "command is {0}, number is {1}, active is {2}", arg0: command, arg1: number, arg2: active);
    }

    #endregion

    #region other parameters

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        // out parameters cannot have a default value; you must be assigned inside the method
        z = 100;

        w++;
        // x++; // cannot change value of in parameter
        y++;
        z++;

        WriteLine($"In the method: w:{w}, x: {x}, y: {y}, z: {z}");
    }

    #endregion

    #region Passing a variable number of parameters

    public void ParamsParameters(string text, params int[] numbers)
    {
        int total = 0;

        foreach (int number in numbers)
        {
            total += number;
        }

        WriteLine($"{text}: {total}");
    }

    #endregion

    #region Tuples

    
    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    //Si possono aggiungere nomi agli elementi della tupla
    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    // Da C#12 è stato introdotto l'aliasing delle tuple

    #endregion

    #region other deconstruction methods

    public void Deconstruct(out string? name, out DateTimeOffset dob)
    {
        name = Name;
        dob = Born;
    }

    public void Deconstruct(out string? name, out DateTimeOffset dob, out WondersOfTheAncientWorld fav)
    { 
        name = Name;
        dob = Born;
        fav = FavoriteAncientWonder;
    }
    #endregion

    #region local functions

    // Example of a method that uses a local function
    public static int Factorial(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException($"{nameof(num)} cannot be less than zero.");
        }
        return localFactorial(num);

        // local function
        int localFactorial(int localNumber)
        {
            if (localNumber == 0) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }

    #endregion

}

#region

public class BankAccount
{
    public string? AccountName; //Istanziare il membro. Potrebbe essere null
    public decimal Balance; //Istanziare il membro. Default 0

    public static decimal InterestRate; // condividire tra tutte le istanze della classe. Default 0
}

#endregion

#region excercise pg 299
public class car
{
    public int Wheels {  get; set; }
    public bool IsEv {  get; set; }
    public void Start()
    {
        WriteLine("Starting...");
    }
}

#endregion





