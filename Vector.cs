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

        public Vector(Vector vect1, Vector vect2) : base(vect1.getX() - vect2.getX(), vect1.getY() - vect2.getY(), vect1.getZ() - vect2.getZ())
        {
            x = vect1.getX() - vect2.getX();
            y = vect1.getY() - vect2.getY();
            z = vect1.getZ() - vect2.getZ();
            CalculateLength();
        }

        public void Normalise()
        {
            x /= length;
            Console.WriteLine("x " + x);
            y /= length;
            Console.WriteLine("y " + y);
            z /= length;
            Console.WriteLine("z " + z);
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

        public Vector Multiply(Vector vect)
        {
            return new Vector(
                    (x * vect.getX()),
                    (y * vect.getY()),
                    (z * vect.getZ())
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
