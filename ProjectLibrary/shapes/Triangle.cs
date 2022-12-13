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
        if (IsTriangleRight()) return GetAreaOfRightTriangle();

        return CalculateArea();
    }
    
    private double CalculateArea()
    {
        double semiPerimeter = (S1 + S2 + S3) / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - S1) * (semiPerimeter - S2) * (semiPerimeter - S3));
        return area;
    }

    private double GetAreaOfRightTriangle()
    {
        if (IsTriangleRight(S1, S2, S3)) return S2 * S3 / 2;
        if (IsTriangleRight(S2, S1, S3)) return S1 * S3 / 2;
        return S1 * S2 / 2;
    }

    private bool IsTriangleRight(double h, double l1, double l2) => h * h == l1 * l1 + l2 * l2;
        
    private bool IsTriangleRight()
    {
        return IsTriangleRight(S1, S2, S3) || IsTriangleRight(S2, S1, S3) || IsTriangleRight(S3, S1, S2);
    }
}
