using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    class Material
    {
        private double diffuseIntensity, specularIntensity, shine;
        Color colour;
        bool reflective;

        public Material(double diffuse, double spec, double shineIn, Color colourIn, bool reflectiveIn)
        {
            diffuseIntensity = diffuse;
            specularIntensity = spec;
            colour = colourIn;
            shine = shineIn;
            reflective = reflectiveIn;
        }

        public double GetDiffuseIntensity()
        {
            return diffuseIntensity;
        }

        public double GetSpecularIntensity()
        {
            return specularIntensity;
        }

        public Color GetColor()
        {
            return colour;
        }

        public double GetShine()
        {
            return shine;
        }

        public bool GetReflective()
        {
            return reflective;
        }
    }
}
