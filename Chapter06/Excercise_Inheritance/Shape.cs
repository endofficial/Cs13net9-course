namespace Packt.Shared;

public class Shape
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Radius { get; set; }
    public virtual double Area => Height * Width;
}

