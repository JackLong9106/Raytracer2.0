using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    abstract class Shape
    {
        protected Material material;

        public abstract Intersection CheckIntersection(Ray ray);

        public abstract Vector GetNormal(Point intersectedPoint);
       
        public double GetDiffuse()
        {
            return material.GetDiffuseIntensity();
        }

        public double GetSpecular()
        {
            return material.GetSpecularIntensity();
        }
        public Color GetColor()
        {
            return material.GetColor();
        }

        public double GetShine()
        {
            return material.GetShine();
        }
    }
}
