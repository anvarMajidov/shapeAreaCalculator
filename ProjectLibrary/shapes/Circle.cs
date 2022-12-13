namespace ProjectLibrary.shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
