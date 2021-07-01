using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracer2
{
    class Image
    {
        Bitmap bitmapImage;
        string filePath;
        ImageFormat imageFormat;
        int width, height;

        public Image(int widthIn, int heightIn, string filePathIn, ImageFormat imageFormatIn, Color backGroundColour)
        {
            bitmapImage = new Bitmap(widthIn, heightIn);
            filePath = filePathIn;
            imageFormat = imageFormatIn;

            width = widthIn;
            height = heightIn;

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

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}
