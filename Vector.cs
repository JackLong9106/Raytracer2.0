using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Vector : Point
    {
        private double length;

        public Vector(double xIn, double yIn, double zIn) : base(xIn, yIn, zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            CalculateLength();
        }

        public Vector(Point point1, Point point2) : base(point1.GetX() - point2.GetX(), point1.GetY() - point2.GetY(), point1.GetZ() - point2.GetZ())
        {
            x = point1.GetX() - point2.GetX();
            y = point1.GetY() - point2.GetY();
            z = point1.GetZ() - point2.GetZ();
            CalculateLength();
        }

        public void Normalise()
        {
            x /= length;
            y /= length;
            z /= length;
            CalculateLength();
        }

        private void CalculateLength()
        {
            length = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public double GetLength()
        {
            return length;
        }

        public double DotProduct(Vector vect)
        {
            return (x * vect.GetX()) + (y * vect.GetY()) + (z * vect.GetZ());
        }

        public Vector CrossProduct(Vector vect)
        {
            return new Vector(
                    (y * vect.GetZ()) - (z * vect.GetY()),
                    (z * vect.GetX()) - (x * vect.GetZ()),
                    (x * vect.GetY()) - (y * vect.GetX())
                );
        }

        public Vector Add(Vector vect)
        {
            return new Vector(
                    (x + vect.GetX()),
                    (y + vect.GetY()),
                    (z + vect.GetZ())
                );
        }

        public Vector Subtract(Vector vect)
        {
            return new Vector(
                    (x - vect.GetX()),
                    (y - vect.GetY()),
                    (z - vect.GetZ())
                );
        }

        public Vector Multiply(double val)
        {
            return new Vector(
                    (x * val),
                    (y * val),
                    (z * val)
                );
        }

        public Vector Divide(Vector vect)
        {
            return new Vector(
                    (x / vect.GetX()),
                    (y / vect.GetY()),
                    (z / vect.GetZ())
                );
        }

        public void Print()
        {
            Console.WriteLine("Vector X:" + x + " Y:" + y + " Z:" + z);
        }

    }
}
