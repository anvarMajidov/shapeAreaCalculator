using System;
using ProjectLibrary;
using ProjectLibrary.shapes;
using Xunit;

namespace TestProject;

public class TestCircle
{
    [Theory]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(2.2)]
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

    private static double GetRadius(double r) => Math.PI * r * r;
}
