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

        public Sphere(Point p, double r, Material materialIn)
        {
            position = p;
            radius = r;
            material = materialIn;
        }

        public override Intersection CheckIntersection(Ray ray)
        {
            Vector rayDirection = ray.GetDirection();
            Point rayOrigin = ray.GetOrigin().Subtract(position);
            Intersection intersection = new Intersection();

            double a = rayDirection.DotProduct(rayDirection);
            double b = 2 * rayOrigin.DotProduct(rayDirection);
            double c = rayOrigin.DotProduct(rayOrigin) - (radius * radius);

            double quadratic = (b * b) - (4 * a * c);

            if (quadratic < 0)
            {
                return intersection;
            }

            double distance1 = (-b - Math.Sqrt(quadratic)) / (2 * a); // First intersection (close)
            double distance2 = (-b + Math.Sqrt(quadratic)) / (2 * a); // Second intersection (far)

            if (distance1 < 0 && distance2 > 0)
            {
                return intersection;
            }
            else if (distance1 >= 0 && distance2 >= 0)
            {
                if (distance1 > distance2)
                {
                    intersection.Intersected(distance1, this, ray);
                    return intersection;
                }
                else
                {
                    intersection.Intersected(distance2, this, ray);
                    return intersection;
                }
            } 
            else
            {
                return intersection;
            }
        }
        
        public override Vector GetNormal(Point intersectedPoint)
        {
            Vector normal = new Vector(position, intersectedPoint);
            normal.Normalise();

            return normal;
        }
    }
}
