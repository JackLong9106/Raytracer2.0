using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    abstract class Shape
    {
        protected Color color;

        public abstract bool CheckIntersection(Ray ray);

        public abstract Vector GetNormal();

        public Color GetColor()
        {
            return color;
        }
    }
}
