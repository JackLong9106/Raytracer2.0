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
        String filepath;
        ImageFormat imageFormat;
        int width, height;

        
        public IniReader()
        {
            // Gets current system directory and removes the sub folders to get the base folder
            String directory = Directory.GetCurrentDirectory();
            directory = directory.Remove(directory.Length - 9, 9);

            if (System.IO.File.Exists(directory + "config.ini"))
            {
                String[] lines = System.IO.File.ReadAllLines(directory + "config.ini");

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


        private void ArgReader(string[] args)
        {
            switch (args[0])
            {
                case "FilePath":
                    filepath = args[1];
                    Console.WriteLine("New filepath: " + filepath);
                    break;

                case "ImageFormat":

                    var imageFormat = args[1] switch
                    {
                        "PNG" => ImageFormat.Png,
                        "JPEG" => ImageFormat.Jpeg,
                    };

                    switch (args[1])
                    {
                        case "PNG":
                            imageFormat = ImageFormat.Png;
                            break;

                        case "JPEG":
                            imageFormat = ImageFormat.Jpeg;
                            break;

                        default:
                            Console.WriteLine("ERROR: Illformed Image Format in config.ini: " + args[1]);
                            break;
                    }

                    break;

                case "Resolution":
                    width = int.Parse(args[1]);
                    height = int.Parse(args[2]);
                    break;

                default:
                    Console.WriteLine("ERROR: Illformed arguement in config.ini: " + args[0]);
                    break;
            }
        }
    }
}
