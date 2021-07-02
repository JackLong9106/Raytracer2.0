using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    class Material
    {
        private double diffuseIntensity, specularIntensity;
        Color colour;

        public Material(double diffuse, double spec, Color colourIn)
        {
            diffuseIntensity = diffuse;
            specularIntensity = spec;
            colour = colourIn;
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
    }
}
