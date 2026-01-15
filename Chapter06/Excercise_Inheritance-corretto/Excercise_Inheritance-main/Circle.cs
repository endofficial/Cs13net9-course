namespace Packt.Shared;

public class  Circle : Shape, ICircle
{
    public Circle(double radius):base(0,0) // chiamata al costruttore della classe base. L'ho chiamata perché Shape è astratta e non posso istanziarla
        => Radius = radius;
    
    public override double Area => Math.PI * (Radius * Radius);
}
