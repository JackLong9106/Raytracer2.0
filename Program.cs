using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracer
{
    class Program
    {
        static void Main(string[] args)
        {
            IniReader inigReader = new IniReader();
            Console.WriteLine("Hello World");
            String filePath = "C:\\Users\\Jack Long\\source\\repos\\Raytracer\\Raytracer\\Output.png";
            ImageFormat imageFormat = ImageFormat.Png;

            Image img = new Image(1000, 1000, filePath, imageFormat, Color.Black);

            img.PrintDimensions();
            img.Save();

            Console.ReadLine();

        }
    }
}
