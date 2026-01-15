namespace Packt.Shared;

// creo le interfacce perché Shape è astratta e non posso istanziarla, ma voglio comunque definire dei tipi concreti Circle e Rect
public interface ICircle:IShape
{
    double Radius { get; set; }
}

public interface IRect:IShape
{
     double Width { get; set; }
     double Height { get; set; }
}

public interface IShape // interfaccia base
{
    double Area { get; } 
}