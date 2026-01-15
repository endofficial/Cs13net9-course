namespace Packt.Shared;

public class Circle : Shape
{
    public override double Area
    {
        get
        {
            return Math.PI * Math.Pow(Radius, 2); // πr²
        }
    }

    public double Radius { get; set; }
}
