using System;

namespace SOLID.LiskovsSubstitutionPrinciple
{
    /// Comparing to the other example below, this example does not break rectangle's GetDescription() -method, or change the behavior of the 
    /// Rectangle class and therefore does not violate the Liskov's substitution principle. 
    public abstract class Shape
    {
        public abstract string GetDescription();
    }

    public class Square:Shape
    {
        public override string GetDescription()
        {
            return "Square is a rectangle which edges are the same length.";
        }
    }

    public class Rectangle : Shape
    {
        public override string GetDescription()
        {
            return "Rectangle is a shape which has four edges.";
        }
    }

    /// The example below violates Liskov's substitution principle.
    /// For example if we create an instance of a Rectangle2 in a following way: Rectangle2 r = new Square2();
    /// and call the method GetDescription(). It does not return the description of the Rectangle2, but the description of the Square2. 
    /// In other words, the inherited class Square2 breaks the GetDescription -method in the Rectangle2 class.

    public class Square2:Rectangle2
    {
        public override string GetDescription()
        {
            return "Square is a rectangle which edges are the same length.";
        }

        
    }

    public class Rectangle2
    {
        public virtual string GetDescription()
        {
            return "Rectangle is a shape which has four edges.";
        }

      
    }

}
