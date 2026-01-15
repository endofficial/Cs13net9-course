using Packt.Shared;

#region Making a value type nullable

int thisCannotBeNull = 4;
//thisCannotBeNull = null; // Compile-time error
WriteLine(thisCannotBeNull);

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault()); // Outputs 0; questo serve per evitare eccezioni

thisCouldBeNull = 7;

//una buona pratica è sempre controllare se è null
if (thisCouldBeNull is not null)
{
    WriteLine(thisCouldBeNull);
    WriteLine(thisCouldBeNull.GetValueOrDefault()); // Outputs 7
}

//alternative synatax
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);

WriteLine();

Address address = new(city: "London");
{
    address.Building = null;
    address.Street = null!; //Con ! dico al compilatore che so quello che sto facendo
    address.Region = "UK";
};

WriteLine(address.Building?.Length); // darà null e non eccezione
//WriteLine(address.Street.Length); // darà eccezzione

if (address.Street is not null)
{
    WriteLine(address.Street.Length); 
}
#endregion
