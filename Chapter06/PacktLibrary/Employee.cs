namespace Packt.Shared;

//classe employee che eredita da Person
public class Employee : Person
{
    //aggiungo due proprietà che riguardano il codice dipendente e la data di assunzione
    public string? EmployeeCode { get; set; }
    public DateOnly HireDate { get; set; }

    //potrei voler modificare il metodo WriteToConsole per ogni dipendente
    // 'Employee.WriteToConsole()' nasconde il membro ereditato 'Person.WriteToConsole()'. Se questo comportamento è intenzionale, usare la parola chiave new.
    /*
    public void WriteToConsole()
    {
        WriteLine(format: "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}.", arg0: Name, arg1: Born, arg2: HireDate);
    }*/
    public new void WriteToConsole()
    {
        WriteLine(format: "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}.", arg0: Name, arg1: Born, arg2: HireDate);
    }

    public override string ToString()
    {
        return $"{Name}'s code is {EmployeeCode}";
    }
}