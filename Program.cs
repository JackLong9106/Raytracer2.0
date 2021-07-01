using System;
using System.Drawing;

namespace Raytracer2
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine("Raytracer Starting...");

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

            Point spherePoint = new Point(0,0,0);
            Sphere sphere = new Sphere(spherePoint, 0.3, Color.Red);

            Point spherePoint2 = new Point(1.5, 0.5, -0.5);
            Sphere sphere2 = new Sphere(spherePoint2, 0.5, Color.Pink);

            Shape[] shapesList = { sphere, sphere2 };

            Scene scene = new Scene(camera, shapesList);

            Raytracer raytracer = new Raytracer(scene, img);
            img = raytracer.Raytrace();
            img.Save();

            timer.Stop();

            Console.WriteLine($"Raytracing finished, execution time: { ((double)timer.ElapsedMilliseconds / 1000) } seconds.");
        }
    }
}
