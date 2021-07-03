using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Raytracer2
{
    class Raytracer
    {
        Scene scene;
        Image image;
        double ambient;

        public Raytracer(Scene sceneIn, Image imageIn, double ambientIn)
        {
            scene = sceneIn;
            image = imageIn;
            ambient = ambientIn;
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

                    Intersection intersection = CastRayIntoScene(ray);

                    if (intersection.GetIntersected())
                    {
                        
                        double phong = CalculatePhong(intersection);
                        Color colour = CalculateShading(intersection.GetIntersectionShape(), phong);
                        image.GetImage().SetPixel(x, y, colour);
                    }
                    else
                    {
                        image.GetImage().SetPixel(x, y, Color.Black);
                    }

                    //Console.WriteLine("X: " + x + ", Y: " + y);
                    //screenCoord.Print();
                    //ray.Print();
                }
            }

            return image;
        }

        private Ray GenerateRay(Point screenCoord)
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

        private Intersection CastRayIntoScene(Ray ray)
        {
            Intersection intersection = new Intersection();

            foreach (Shape shape in scene.GetShapesList())
            {
                intersection = shape.CheckIntersection(ray);

                if (intersection.GetIntersected())
                {
                    return intersection;
                }
            }

            return intersection;
        }

        private double CalculatePhong(Intersection intersection)
        {
            // diffuse = shape diffuse * light intensity * (lightvector dot shape normal)
            // specular = specular intensity * (light intensity * (camera vect dot reflection vect)^ shine)
            // phong = ambient + diffuse + specular

            double diffuse, specular, phong = 0;
            Shape shape = intersection.GetIntersectionShape();
            Vector lightVector, cameraVector, reflectionVector, shapeNormal = shape.GetNormal(intersection.GetIntersectionPoint()) ;
            

            foreach (Light light in scene.GetLightList())
            {
                lightVector = new Vector(intersection.GetIntersectionPoint(), light.GetPosition());
                cameraVector = new Vector(scene.GetCamera().GetPosition(), intersection.GetIntersectionPoint());
                reflectionVector = shapeNormal.Subtract(lightVector).Multiply(2 * lightVector.DotProduct(shape.GetNormal(shapeNormal)));
                


                lightVector.Normalise();
                cameraVector.Normalise();
                reflectionVector.Normalise();

                diffuse = shape.GetDiffuse() * light.GetBrightness() * lightVector.DotProduct(shapeNormal);
                specular = shape.GetSpecular() * light.GetBrightness() * Math.Pow(lightVector.DotProduct(reflectionVector), shape.GetShine());

                phong += diffuse + specular;
            }
                
            return MinZero(phong) + ambient;
        }

        private Color CalculateShading(Shape intersectedShape, double Phong)
        {
            Color shapeColour = intersectedShape.GetColor();

            int r = Convert.ToInt32(shapeColour.R * Phong);
            int g = Convert.ToInt32(shapeColour.G * Phong);
            int b = Convert.ToInt32(shapeColour.B * Phong);

            if (r > 255)
            {
                r = 255;
            }
            else if (r < 0)
            {
                r = 0;
            }

            if (g > 255)
            {
                g = 255;
            }
            else if (g < 0)
            {
                g = 0;
            }

            if (b > 255)
            {
                b = 255;
            }
            else if (b < 0)
            {
                b = 0;
            }

            return Color.FromArgb(r, g, b);
        }

        private double MinZero(double val)
        {
            if (val < 0)
            {
                return 0;
            }

            return val;
        }
    }
}
