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

            Vector v = new Vector(3, 5, 7);
            Console.WriteLine(v.GetLength());

            v.Normalise();
            Console.WriteLine(v.GetLength());

        }
    }
}
