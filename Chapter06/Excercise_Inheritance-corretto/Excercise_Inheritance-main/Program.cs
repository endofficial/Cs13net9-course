using Packt.Shared;

IRect r = new Rectangle(3, 4.5);
WriteLine($"Area of rectangle with height: {r.Height} and width: {r.Width} is: \n{r.Area}");

WriteLine();
IRect s = new Square(5); //posso omettere height
WriteLine($"Area of square with height: {s.Height} is: \n{s.Area}");

WriteLine();
ICircle c = new Circle(2.5);
WriteLine($"Area of circle with radius: {c.Radius} is: \n{c.Area}");