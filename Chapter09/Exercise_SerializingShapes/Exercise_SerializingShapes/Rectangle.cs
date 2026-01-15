namespace Packt.Shared
{
    public class Rectangle : Shape
    {
        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}