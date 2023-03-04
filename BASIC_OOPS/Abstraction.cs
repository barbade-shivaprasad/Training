using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASIC_OOPS
{
    public abstract class Shape
    {
        public abstract double Area();

        public void Display()
        {
            Console.WriteLine("Shape Information:");
            Console.WriteLine("Area: {0}", Area());
        }
    }

    public class Rectangle : Shape
    {
        double length;
        double width;

        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        public override double Area()
        {
            return length * width;
        }
    }
}
