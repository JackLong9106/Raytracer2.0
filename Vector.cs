using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Vector
    {
        double x, y, z, length;

        public Vector(double xIn, double yIn, double zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            CalculateLength();
        }

        public Vector(Vector vect1, Vector vect2)
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

        // NEEDED METHODS

        // Add

        // Subtract

        // Multiply

        // Divide

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public double getZ()
        {
            return z;
        }

        public void Print()
        {
            Console.WriteLine("Vector X:" + x + " Y:" + y + " Z:" + z);
        }

    }
}
