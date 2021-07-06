using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Triangle : Shape
    {
        Point vertex1, vertex2, vertex3, midPoint;
        Vector edge1, edge2, normal;

        public Triangle(Point v1, Point v2, Point v3, Material mat)
        {
			vertex1 = v1;
			vertex2 = v2;
			vertex3 = v3;
			material = mat;

			midPoint = new Point(
				(v1.GetX() + v2.GetX() + v3.GetX()) / 3,
				(v1.GetY() + v2.GetY() + v3.GetY()) / 3,
				(v1.GetZ() + v2.GetZ() + v3.GetZ()) / 3
				);

			edge1 = new Vector(v2, v1);
			edge2 = new Vector(v3, v1);

			normal = edge2.CrossProduct(edge1);
			normal.Normalise();
		}

		public override Intersection CheckIntersection(Ray ray)
		{
			Vector rayDirection = ray.GetDirection();
			Point rayOrigin = ray.GetOrigin();

			Vector rayCrossEdge2 = rayDirection.CrossProduct(edge2);
			double rayDotEdge2 = edge1.DotProduct(rayCrossEdge2);

			if (rayDotEdge2 < ray.GetRayMin())
			{
				return new Intersection();
			}

			double rayDot2Inverse = (double)(1.0 / rayDotEdge2);
			Point raySubEdge2 = rayOrigin.Subtract(vertex1);
			double rayDotVert1 = raySubEdge2.DotProduct(rayCrossEdge2) * rayDot2Inverse;

			if (rayDotVert1 < 0 || rayDotVert1 > 1)
			{
				return new Intersection();
			}

			Point raySubCross = raySubEdge2.CrossProduct(edge1);
			double raySubCrossDot = rayDirection.DotProduct(raySubCross) * rayDot2Inverse;

			if (raySubCrossDot < 0 || raySubCrossDot + rayDotVert1 > 1)
			{
				return new Intersection();
			}
			else
			{
				Vector raySubVert1 = new Vector(ray.GetOrigin(), vertex1);
				Vector rayCrossEdge1 = raySubVert1.CrossProduct(edge1);
				double a = edge1.DotProduct(rayCrossEdge2);
				double f = 1.0 / a;
				double distance = f * edge2.DotProduct(rayCrossEdge1);

				if (distance <= 0)
				{
					return new Intersection();
				}

				Intersection i = new Intersection();
				i.Intersected(distance, this, ray);
				return i;
			}
		}

        public override Vector GetNormal(Point intersectionPoint)
        {
			return normal;
        }


	}
}
