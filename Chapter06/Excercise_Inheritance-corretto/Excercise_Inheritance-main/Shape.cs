namespace Packt.Shared;

public abstract class Shape(double height, double width):IShape 
{
    public double Height { get; set; } = height;
    public double Width { get; set; } = width;
    public double Radius { get; set; } //utile per Circle

    public virtual double Area => Height * Width;
}

