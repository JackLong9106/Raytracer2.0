using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Raytracer
    {
        Scene scene;
        Image image;

        public Raytracer(Scene sceneIn, Image imageIn)
        {
            scene = sceneIn;
            image = imageIn;
        }

        public Image Raytrace()
        {
            for (int x = 0; x < image.GetWidth(); x++)
            {
                for (int y = 0; y < image.GetHeight(); y++)
                {

                }
            }

            return image;
        }
    }
}
