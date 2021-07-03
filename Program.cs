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

            Vector viewUp = new Vector(0,1,0);
            Point pos = new Point(0, 0, 3);
            Point lookAt = new Point(0, 0, 0);

            Camera camera = new Camera(pos, lookAt, viewUp, img.GetWidth(), img.GetHeight(), 50);

            Point spherePoint = new Point(1,0,0);
            Material redMaterial = new Material(0.2, 0.5, 1, Color.Red);
            Sphere sphere = new Sphere(spherePoint, 0.5, redMaterial);

            Point spherePoint2 = new Point(-1, 0, 0);
            Material blueMaterial = new Material(0.2, 0.5, 4, Color.Blue);
            Sphere sphere2 = new Sphere(spherePoint2, 0.5, blueMaterial);

            Shape[] shapesList = { sphere, sphere2 };

            Point lightPoint1 = new Point(0, 3, 3);
            Light light = new Light(1, Color.White, lightPoint1);
            Light[] Lightlist = { light };

            Scene scene = new Scene(camera, shapesList, Lightlist);

            double ambient = 0.1;
            Raytracer raytracer = new Raytracer(scene, img, ambient);
            img = raytracer.Raytrace();
            img.Save();

            camera.GetViewPlaneUp().Print();
            camera.GetViewPlaneRight().Print();
            camera.GetViewPlaneNormal().Print();
            camera.GetPosition().Print();

            timer.Stop();

            Console.WriteLine($"Raytracing finished, execution time: { ((double)timer.ElapsedMilliseconds / 1000) } seconds.");
        }
    }
}
