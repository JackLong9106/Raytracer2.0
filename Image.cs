using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracer
{
    class Image
    {
        Bitmap bitmapImage;
        String filePath;
        ImageFormat imageFormat;

        public Image(int width, int height, string filePathIn, ImageFormat imageFormatIn, Color backGroundColour)
        {
            bitmapImage = new Bitmap(width, height);
            filePath = filePathIn;
            imageFormat = imageFormatIn;

            SetImageBackgroundColour(backGroundColour);
        }

        public Bitmap GetImage()
        {
            return bitmapImage;
        }

        public void PrintDimensions()
        {
            Console.WriteLine("Image dimensions, height: " + bitmapImage.Height + ", width: " + bitmapImage.Width + ".");
        }

        public void Save()
        {
            bitmapImage.Save(filePath, imageFormat);
        }

        public void SetImageBackgroundColour(Color backgroundColour)
        {
            for (int x = 0; x < bitmapImage.Width; x++)
            {
                for (int y = 0; y < bitmapImage.Height; y++)
                {
                    bitmapImage.SetPixel(x, y, backgroundColour);
                }
            }
        }
    }
}
