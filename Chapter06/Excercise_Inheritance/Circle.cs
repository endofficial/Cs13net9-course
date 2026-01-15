namespace Packt.Shared;

public class  Circle : Shape
{
    public Circle() : base() { }
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double Area => Math.PI * (Radius * Radius);
}
