using System;
using ProjectLibrary;
using ProjectLibrary.exceptions;
using ProjectLibrary.shapes;
using Xunit;

namespace TestProject;

public class TestCircle
{
    [Theory]
    [InlineData(10)]
    [InlineData(3.1)]
    public void GetArea_ValidRadius_ReturnsArea(double radius)
    {
        //Arrange
        IShape shape = new Circle(radius);

        //Act
        double area = shape.GetArea();

        //Assert
        Assert.Equal(GetRadius(radius), area);
    }
    
    [Theory]
    [InlineData(-2)]
    [InlineData(-12.2)]
    public void GetArea_NegativeRadius_ReturnsException(double radius)
    {
        //Arrange
        IShape shape = new Circle(radius);

        //Act and Assert
        Assert.Throws<NegativeLengthException>(() => shape.GetArea());
    }

    private static double GetRadius(double r) => Math.PI * r * r;
}
