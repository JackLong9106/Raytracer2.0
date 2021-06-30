using System;
using System.Drawing;

namespace Raytracer
{
    class Program
    {
        static void Main(string[] args)
        {
            IniReader iniReader = new IniReader();

            Console.WriteLine("Raytracer Starting");

            Image img = new Image(
                iniReader.GetResolution()[0],
                iniReader.GetResolution()[1],
                iniReader.GetFilePath(),
                iniReader.GetImageFormat(),
                Color.Black
            );

            img.PrintDimensions();
            img.Save();
        }
    }
}
