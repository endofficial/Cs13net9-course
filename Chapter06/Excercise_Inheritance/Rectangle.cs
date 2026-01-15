namespace Packt.Shared;

public class Rectangle : Shape
{
    public Rectangle() : base() { }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public override double Area => Height * Width;
}