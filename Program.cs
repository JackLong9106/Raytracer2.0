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

            Vector v = new Vector(5, 2, 1);
            Vector v2 = new Vector(4, 2, 4);
            Vector v3 = v.CrossProduct(v2);
            v3.Print();

            Console.WriteLine();

        }
    }
}
