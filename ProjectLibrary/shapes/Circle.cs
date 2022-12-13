using ProjectLibrary.exceptions;

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
        if (Radius < 0) throw new NegativeLengthException("Radius's length cannot be negative");
        
        return Math.PI * Radius * Radius;
    }
}
