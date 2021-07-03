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
            return (x * vect.getX()) + (y * vect.getY()) + (z * vect.getZ());
        }

        public Point CrossProduct(Point vect)
        {
            return new Point(
                    (y * vect.getZ()) - (z * vect.getY()),
                    (z * vect.getX()) - (x * vect.getZ()),
                    (x * vect.getY()) - (y * vect.getX())
                );
        }

        public Point Add(Point vect)
        {
            return new Point(
                    (x + vect.getX()),
                    (y + vect.getY()),
                    (z + vect.getZ())
                );
        }

        public Point Subtract(Point vect)
        {
            return new Point(
                    (x - vect.getX()),
                    (y - vect.getY()),
                    (z - vect.getZ())
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
                    (x / vect.getX()),
                    (y / vect.getY()),
                    (z / vect.getZ())
                );
        }

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
