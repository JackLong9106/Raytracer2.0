using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Intersection
    {
        bool intersected;
        Point intersectionPoint;
        Shape intersectionShape;
        double distance;

        public Intersection()
        {
            intersected = false;
            intersectionShape = null;
            intersectionPoint = null;
        }

        public void Intersected(double dist, Shape shapeIn, Ray ray)
        {
            intersected = true;
            intersectionShape = shapeIn;
            distance = dist;

            intersectionPoint = ray.GetOrigin().Add(ray.GetDirection().Multiply(dist));
        }

        public bool GetIntersected()
        {
            return intersected;
        }

        public Point GetIntersectionPoint()
        {
            return intersectionPoint;
        }

        public Shape GetIntersectionShape()
        {
            return intersectionShape;
        }
    }
}
