namespace Packt.Shared;

public sealed class Square(double height) : Shape(height, height), IRect;
