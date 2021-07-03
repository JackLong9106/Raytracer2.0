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
        Ray ray;

        public Intersection()
        {
            intersected = false;
            intersectionShape = null;
            intersectionPoint = null;
            ray = null;
        }

        public void Intersected(double dist, Shape shapeIn, Ray rayIn)
        {
            intersected = true;
            intersectionShape = shapeIn;
            distance = dist;
            ray = rayIn;

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

        public Ray GetRay()
        {
            return ray;
        }
    }
}
