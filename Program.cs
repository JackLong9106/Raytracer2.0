using System;
using System.Drawing;

namespace Raytracer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Raytracer Starting");

            IniReader iniReader = new IniReader();

            Image img = new Image(
                iniReader.GetResolution()[0],
                iniReader.GetResolution()[1],
                iniReader.GetFilePath(),
                iniReader.GetImageFormat(),
                Color.Black
            );

            img.PrintDimensions();
            img.Save();

            Vector viewUp = new Vector(0,1,0);
            Point pos = new Point(0, 0, 1);
            Point lookAt = new Point(0, 0, 0);

            Camera camera = new Camera(pos, lookAt, viewUp, img.GetWidth(), img.GetHeight(), 50);
            camera.Print();

            Point spherePoint = new Point(0,0,0);
            Sphere sphere = new Sphere(spherePoint, 0.3, Color.Red);
            Shape[] shapesList = { sphere };

            Scene scene = new Scene(camera, shapesList);

            Raytracer raytracer = new Raytracer(scene, img);
            img = raytracer.Raytrace();
            img.Save();
        }
    }
}
