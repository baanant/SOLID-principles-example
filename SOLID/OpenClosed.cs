

using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosedPrinciple
{
    /// This example describes Open/Closed principle which means that modules should be OPEN for EXTENSIONS, but CLOSED for modification.
    /// As you can see, all the specific shapes inherits the abstract class Shape and its abstract method called Calculate area.
    /// This way it is possible to calculate sum of the areas neatly with area calculator. It is also possible to write more shape classes without
    /// breaking (and without the need to change) the AreaCalculator class. 
  
    public static class AreaCalculator
    {
        public static double SumAreas(IEnumerable<Shape> shapes)
        {
            return shapes.Sum(i =>i.CalculateArea());
        }
    }

    public abstract class Shape
    {
        public abstract double CalculateArea();

    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }
    }

    public class Circle : Shape
    {

        public Circle(double radius)
        {
            this.Radius = radius;
        }       

        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius,2);
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }

        public double Height { get; set; }



        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    /// The following example describes how things should NOT be done. 
    /// We would like not to change the code of AreaCalculator, but now (if we don't follow the O/C principle)
    /// we have to change its code every time a new shape class is introduced. 
    public static class AreaCalculator2
    {
        public static double SumAreas(IEnumerable<object> shapes)
        {
            var sum = new double();
            foreach(var shape in shapes)
            {
                if(shape.GetType() == typeof(Rectangle2))
                {
                    sum += ((Rectangle2)shape).CalculateArea();
                }
                else if(shape.GetType() == typeof(Circle2))
                {
                    sum += ((Circle2)shape).CalculateArea();
                }
                //Every time a new shape is introduced, we have to write a new condition for it. Not good!
                //It works, but it ain't neat.
            }
            return sum;
        }
    }

    public class Rectangle2
    {
        public Rectangle2(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public double CalculateArea()
        {
            return this.Height * this.Width;
        }
    }

    public class Circle2
    {
        public Circle2(double radius)
        {
            this.Radius = radius;
        }       

        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius,2);
        }
    }
}
