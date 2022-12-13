using ProjectLibrary.exceptions;

namespace ProjectLibrary.shapes;

public class Triangle : IShape
{
    public double S1 { get; set; }
    public double S2 { get; set; }
    public double S3 { get; set; }

    public Triangle(double s1, double s2, double s3)
    {
        S1 = s1;
        S2 = s2;
        S3 = s3;
    }

    public double GetArea()
    {
        if (IsAnySideNegative()) throw new NegativeLengthException("Side length cannot be negative");
        if (!IsTriangleValid()) throw new InvalidTriangleException("Triangle cannot exist with such sides");
        
        if (IsTriangleRightAngled()) return GetAreaOfRightTriangle();

        return CalculateArea();
    }

    private bool IsAnySideNegative()
    {
        return S1 < 0 || S2 < 0 || S3 < 0;
    }

    //треугольник можно построить только при условии что 
    //сумма любых двух сторон превышает третью
    private bool IsTriangleValid()
    {
        return S1 + S2 > S3 && S1 + S3 > S2 && S2 + S3 > S1;
    }
    
    private double CalculateArea()
    {
        double semiPerimeter = (S1 + S2 + S3) / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - S1) * (semiPerimeter - S2) * (semiPerimeter - S3));
        return area;
    }

    private double GetAreaOfRightTriangle()
    {
        if (IsTriangleRightAngled(S1, S2, S3)) return S2 * S3 / 2;
        if (IsTriangleRightAngled(S2, S1, S3)) return S1 * S3 / 2;
        return S1 * S2 / 2;
    }

    private bool IsTriangleRightAngled(double h, double l1, double l2) => h * h == l1 * l1 + l2 * l2;
        
    private bool IsTriangleRightAngled()
    {
        return IsTriangleRightAngled(S1, S2, S3) || IsTriangleRightAngled(S2, S1, S3) || IsTriangleRightAngled(S3, S1, S2);
    }
}
