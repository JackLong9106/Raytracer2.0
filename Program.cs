using System;
using System.Drawing;

namespace Raytracer2
{
    class Program
    {
        static void Main(string[] args)
        {
            // - - - Materials - - -
            double diffuseMatt = 0.5;
            double specMatt = 0.08;
            double shineMatt = 8;

            Material diffuseRedMaterial = new Material(diffuseMatt, specMatt, shineMatt, Color.Red, false);
            Material diffuseBlueMaterial = new Material(diffuseMatt, specMatt, shineMatt, Color.Blue, false);

            double diffuseMetal = 1;
            double specMetal = 0.8;
            double shineMetal = 6;

            Material diffuseSteelBlueMetal = new Material(diffuseMetal, specMetal, shineMetal, Color.SteelBlue, true);
            Material diffuseGoldMetal = new Material(diffuseMetal, specMetal, shineMetal, Color.Gold, true);

            // - - - Shapes - - -
            Point spherePoint = new Point(1, 0, 0);
            Point spherePoint2 = new Point(-1, 0, 0);

            double radius05 = 0.5;

            Sphere sphere = new Sphere(spherePoint, radius05, diffuseSteelBlueMetal);
            Sphere sphere2 = new Sphere(spherePoint2, radius05, diffuseBlueMaterial);

            Triangle tri = new Triangle(
                new Point(-1, 2, 0),
                new Point(-1, -2, 0),
                new Point(1, -2, 0),
                diffuseRedMaterial
                );

            Shape[] shapesList = { sphere, tri };

            // - - - Image - - -
            IniReader iniReader = new IniReader();

            Image img = new Image(
                iniReader.GetResolution()[0],
                iniReader.GetResolution()[1],
                iniReader.GetFilePath(),
                iniReader.GetImageFormat(),
                Color.Black
            );

            // - - - Camera - - -
            Vector viewUp = new Vector(0, 1, 0);
            Point pos = new Point(0, 0, 3);
            Point lookAt = new Point(0, 0, 0);

            Camera camera = new Camera(pos, lookAt, viewUp, img.GetWidth(), img.GetHeight(), 50);

            // - - - Lights - - -
            Light light1 = new Light(1, Color.White, new Point(2, 1, 2));

            Light light2 = new Light(1, Color.White, new Point(0, 1, 1));

            Light[] Lightlist = { light1 };

            // - - - Scene - - -
            Scene scene = new Scene(camera, shapesList, Lightlist);

            // - - - Renderer - - -
            Console.WriteLine("Raytracer Starting...");
            var timer = System.Diagnostics.Stopwatch.StartNew();

            double ambient = 0.025;

            Raytracer raytracer = new Raytracer(scene, img, ambient);

            img = raytracer.Raytrace();
            img.Save();

            timer.Stop();

            Console.WriteLine($"Raytracing finished, execution time: { ((double)timer.ElapsedMilliseconds / 1000) } seconds.");
        }
    }
}
