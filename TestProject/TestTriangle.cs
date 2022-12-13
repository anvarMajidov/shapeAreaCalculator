using System;
using ProjectLibrary;
using ProjectLibrary.exceptions;
using ProjectLibrary.shapes;
using Xunit;

namespace TestProject;

public class TestTriangle
{
    [Theory]
    [InlineData(3,4,5)]
    [InlineData(7.1,10,5.5)]
    public void GetArea_ValidTriangle_ReturnsArea(double s1, double s2, double s3)
    {
        //Arrange
        IShape triangle = new Triangle(s1, s2, s3);

        //Act
        double area = triangle.GetArea();

        //Assert
        Assert.Equal(GetArea(s1, s2, s3), area);
    }
    
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(100,1,2)]
    public void GetArea_InvalidTriangleSides_ThrowsException(double s1, double s2, double s3)
    {
        //Arrange
        IShape triangle = new Triangle(s1, s2, s3);

        //Act and Assert
        Assert.Throws<InvalidTriangleException>(() => triangle.GetArea());
    }
    
    [Theory]
    [InlineData(1,-2,3)]
    [InlineData(-100,1,2)]
    public void GetArea_NegativeTriangleSides_ThrowsException(double s1, double s2, double s3)
    {
        //Arrange
        IShape triangle = new Triangle(s1, s2, s3);

        //Act and Assert
        Assert.Throws<NegativeLengthException>(() => triangle.GetArea());
    }
    
    private double GetArea(double s1, double s2, double s3)
    {
        double semiPerimeter = (s1 + s2 + s3) / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - s1) * (semiPerimeter - s2) * (semiPerimeter - s3));
        return area;
    }
}
