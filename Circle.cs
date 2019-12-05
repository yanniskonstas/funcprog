using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static System.Linq.Enumerable;

namespace funcprog {
    public class Circle {
        public Circle(double radius) 
            => Radius = radius;
        public double Radius { get; }
        public double Circumference
            => PI * 2 * Radius;
        public double Area {
            get {
                double Square(double d) => Pow(d, 2);
                return PI * Square(Radius);
            }
        }
        public (double Circumference, double Area) Stats
            => (Circumference, Area);      

    }
}