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

        public Vector(Point point1, Point point2) : base(point1.getX() - point2.getX(), point1.getY() - point2.getY(), point1.getZ() - point2.getZ())
        {
            x = point1.getX() - point2.getX();
            y = point1.getY() - point2.getY();
            z = point1.getZ() - point2.getZ();
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
            return (x * vect.getX()) + (y * vect.getY()) + (z * vect.getZ());
        }

        public Vector CrossProduct(Vector vect)
        {
            return new Vector(
                    (y * vect.getZ()) - (z * vect.getY()),
                    (z * vect.getX()) - (x * vect.getZ()),
                    (x * vect.getY()) - (y * vect.getX())
                );
        }

        public Vector Add(Vector vect)
        {
            return new Vector(
                    (x + vect.getX()),
                    (y + vect.getY()),
                    (z + vect.getZ())
                );
        }

        public Vector Subtract(Vector vect)
        {
            return new Vector(
                    (x - vect.getX()),
                    (y - vect.getY()),
                    (z - vect.getZ())
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
                    (x / vect.getX()),
                    (y / vect.getY()),
                    (z / vect.getZ())
                );
        }

        public void Print()
        {
            Console.WriteLine("Vector X:" + x + " Y:" + y + " Z:" + z);
        }

    }
}
