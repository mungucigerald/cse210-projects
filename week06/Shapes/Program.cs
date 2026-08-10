using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();
        Square square = new("Blue", 16);
        shapes.Add(square);
        Rectangle rectangle = new("Green", 15, 28);
        shapes.Add(rectangle);
        Circle circle = new("Red", 17);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"Area of the {color} shape is {area}cm²");
            Console.WriteLine();
        }
    }
}