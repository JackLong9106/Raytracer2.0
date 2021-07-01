using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Ray
    {
        private Point origin;
        private Vector direction;
        private static readonly double RAY_DISTANCE_MINIMUM = 0.000001;
        private static readonly double RAY_DISTANCE_MAXIMUM = 1.0e30;

        public Ray(Point originIn, Vector directionIn)
        {
            origin = originIn;
            direction = directionIn;
        }

        public Point CalculatePoint(double val)
        {
            return origin.Add(direction).Multiply(val);
        }

        public Vector GetDirection()
        {
            return direction;
        }

        public Point GetOrigin()
        {
            return origin;
        }

        public double GetRayMin()
        {
            return RAY_DISTANCE_MINIMUM;
        }

        public double GetRayMax()
        {
            return RAY_DISTANCE_MAXIMUM;
        }

        public void Print()
        {
            Console.WriteLine("Printing Ray...");
            direction.Print();
            origin.Print();
        }
    }
}
