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


        // NEEDED METHODS

        // Normalise

        // dot Product

        // Cross Product

        // Add

        // Subtract

        // Multiply

        // Divide

        // ToString

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

    }
}
