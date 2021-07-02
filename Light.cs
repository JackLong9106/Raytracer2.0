using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    class Light
    {
        private double brightness;
        private Color colour;
        private Point position;

        public Light(double brightnessIn, Color colourIn, Point positionIn)
        {
            brightness = brightnessIn;
            colour = colourIn;
            position = positionIn;
        }

        public double GetBrightness()
        {
            return brightness;
        }
        public Color GetColour()
        {
            return colour;
        }

        public Point GetPosition()
        {
            return position;
        }

        
    }
}
