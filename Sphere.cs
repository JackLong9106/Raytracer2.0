using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    class Sphere : Shape
    {
        Point position;
        double radius;

        public Sphere(Point p, double r, Color colorIn)
        {
            position = p;
            radius = r;
            color = colorIn;
        }

        public override bool CheckIntersection(Ray ray)
        {
            Vector rayDirection = ray.GetDirection();
            Point rayOrigin = ray.GetOrigin();

            double a = rayDirection.DotProduct(rayDirection);
            double b = 2 * rayOrigin.DotProduct(rayDirection);
            double c = rayOrigin.DotProduct(rayOrigin) - (radius * radius);

            double quadratic = (b * b) - (4 * a * c);

            if (quadratic < 0)
            {
                return false;
            }

            double distance1 = (-b - Math.Sqrt(quadratic)) / (2 * a); // First intersection (close)
            double distance2 = (-b + Math.Sqrt(quadratic)) / (2 * a); // Second intersection (far)

            if (distance1 < 0 && distance2 > 0)
            {
                return false;
            }
            else if (distance1 >= 0 && distance2 >= 0)
            {
                if (distance1 <= distance2)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            } 
            else
            {
                return false;
            }
        }
        
        public override Vector GetNormal()
        {
            return new Vector(0, 0, 0); // TODO temp just to make compliler work
        }
    }
}
