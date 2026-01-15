using Packt.Shared;

Rectangle r = new(height: 3, width: 4.5);
WriteLine($"Area of rectangle with height: {r.Height} and width: {r.Width} is: \n{r.Area}");

WriteLine();
Square s = new(5); //posso omettere height
WriteLine($"Area of square with height: {s.Height} is: \n{s.Area}");

WriteLine();
Circle c = new(radius: 2.5);
WriteLine($"Area of circle with radius: {c.Radius} is: \n{c.Area}");