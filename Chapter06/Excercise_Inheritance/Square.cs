namespace Packt.Shared;

public class Square : Shape
{
    public Square() : base() { }
    public Square(double height)
    {
        this.Height = height;
    }

    public override double Area => Height * Height;
}
