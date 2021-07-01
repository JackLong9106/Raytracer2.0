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
            Ray ray;

            for (int x = 0; x < image.GetWidth(); x++)
            {
                for (int y = 0; y < image.GetHeight(); y++)
                {
                    Point screenCoord = new Point(
                        ((2f * x) / image.GetWidth() - 1f),
                        ((-2f * y) / image.GetHeight() + 1f),
                        (0));

                    ray = GenerateRay(screenCoord);

                    //Console.WriteLine("X: " + x + ", Y: " + y);
                    //screenCoord.Print();
                    //ray.Print();
                }
            }

            return image;
        }

        public Ray GenerateRay(Point screenCoord)
        {
            // Formula: forward + (x * width * right) + (y * height * up);

            Vector rightVect = scene.GetCamera().GetViewPlaneRight();
            rightVect = rightVect.Multiply(screenCoord.getX());
            rightVect = rightVect.Multiply(scene.GetCamera().GetWidth());

            Vector upVect = scene.GetCamera().GetViewPlaneUp();
            upVect = upVect.Multiply(screenCoord.getY());
            upVect = upVect.Multiply(scene.GetCamera().GetHeight());

            Vector outputVector = scene.GetCamera().GetViewPlaneNormal();
            outputVector = outputVector.Add(rightVect);
            outputVector = outputVector.Add(upVect);

            outputVector.Normalise();

            return new Ray(scene.GetCamera().GetPosition(), outputVector);
        }
    }
}
