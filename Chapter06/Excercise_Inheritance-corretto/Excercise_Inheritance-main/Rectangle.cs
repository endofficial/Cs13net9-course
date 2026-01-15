namespace Packt.Shared;

public sealed class Rectangle(double height, double width) : Shape(height, width), IRect;