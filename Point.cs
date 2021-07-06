using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Point
    {
        protected double x, y, z;

        public Point(double xIn, double yIn, double zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
        }

        public double DotProduct(Point vect)
        {
            return (x * vect.GetX()) + (y * vect.GetY()) + (z * vect.GetZ());
        }

        public Point CrossProduct(Point vect)
        {
            return new Point(
                    (y * vect.GetZ()) - (z * vect.GetY()),
                    (z * vect.GetX()) - (x * vect.GetZ()),
                    (x * vect.GetY()) - (y * vect.GetX())
                );
        }

        public Point Add(Point vect)
        {
            return new Point(
                    (x + vect.GetX()),
                    (y + vect.GetY()),
                    (z + vect.GetZ())
                );
        }

        public Point Subtract(Point vect)
        {
            return new Point(
                    (x - vect.GetX()),
                    (y - vect.GetY()),
                    (z - vect.GetZ())
                );
        }

        public Point Multiply(double val)
        {
            return new Point(
                    (x * val),
                    (y * val),
                    (z * val)
                );
        }

        public Point Divide(Point vect)
        {
            return new Point(
                    (x / vect.GetX()),
                    (y / vect.GetY()),
                    (z / vect.GetZ())
                );
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public double GetZ()
        {
            return z;
        }

        public void Inverse()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        public void Print()
        {
            Console.WriteLine("Point X:" + x + " Y:" + y + " Z:" + z);
        }
    }
}
