using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracer
{
    class IniReader
    {
        string filepath;
        ImageFormat imageFormat;
        int[] resolution = new int[2]; // 0 = width, 1 = height
        
        public IniReader()
        {
            // Gets current system directory and removes the sub folders to get the base folder
            string directory = Directory.GetCurrentDirectory();
            directory = directory.Remove(directory.Length - 23, 23);

            if (System.IO.File.Exists(directory + "config.ini"))
            {
                string[] lines = System.IO.File.ReadAllLines(directory + "config.ini");

                foreach (string line in lines)
                {
                    string[] args = line.Split('_');

                    ArgReader(args);
                }
            } 
                else
            {
                Console.WriteLine("ERROR: Could not find config .ini, this file should be in the following directory");
                Console.WriteLine(directory + "config.ini");
            }
        }

        public string GetFilePath()
        {
            return filepath;
        }

        public ImageFormat GetImageFormat()
        {
            return imageFormat;
        }

        public int[] GetResolution()
        {
            return resolution;
        }

        private void ArgReader(string[] args)
        {
            switch (args[0])
            {
                case "FilePath":
                    filepath = args[1];
                    Console.WriteLine("New filepath: " + filepath);
                    break;

                case "ImageFormat":

                    imageFormat = args[1] switch
                    {
                        "PNG" => ImageFormat.Png,
                        "JPEG" => ImageFormat.Jpeg,
                        _ => ImageFormat.Png,
                    };

                    break;

                case "Resolution":
                    resolution[0] = int.Parse(args[1]);
                    resolution[1] = int.Parse(args[2]);
                    break;

                default:
                    Console.WriteLine("ERROR: Illformed arguement in config.ini: " + args[0]);
                    break;
            }
        }
    }
}
