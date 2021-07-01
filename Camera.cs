using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Camera
    {
        Point position, lookAt;
        Vector viewPlaneUp, viewPlaneRight, viewPlaneNormal;
        double fov, aspectRatio, height, width;

        public Camera(Point positionIn, Point lookAtIn, Vector viewPlaneUpIn, int imageWidth, int imageHeight, double fovIn)
        {
            position = positionIn;
            lookAt = lookAtIn;
            aspectRatio = imageWidth/ imageHeight;
            fov = fovIn;

            viewPlaneNormal = new Vector(lookAtIn, positionIn);
            viewPlaneNormal.Normalise();

            viewPlaneRight = viewPlaneNormal.CrossProduct(viewPlaneUpIn);
            viewPlaneRight.Normalise();

            viewPlaneUp = viewPlaneRight.CrossProduct(viewPlaneNormal);
            viewPlaneUp.Normalise();

            height = Math.Atan(ToRadians(fovIn));
            width = aspectRatio * height;
        }

        private double ToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public Point GetPosition()
        {
            return position;
        }

        public Point GetLookAt()
        {
            return lookAt;
        }

        public double GetFov()
        {
            return fov;
        }

        public Vector GetViewPlaneUp()
        {
            return viewPlaneUp;
        }

        public Vector GetViewPlaneRight()
        {
            return viewPlaneRight;
        }

        public Vector GetViewPlaneNormal()
        {
            return viewPlaneNormal;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public void Print()
        {
            Console.WriteLine("Printing Camera...");
            Console.WriteLine("Position:");
            position.Print();

            Console.WriteLine("LookAt:");
            lookAt.Print();

            Console.WriteLine("View Up:");
            viewPlaneUp.Print();

            Console.WriteLine("View Normal:");
            viewPlaneNormal.Print();

            Console.WriteLine("View Right:");
            viewPlaneRight.Print();

            Console.WriteLine("FOV: " + fov);

            Console.WriteLine("Height: " + height);

            Console.WriteLine("Width: " + width);
        }
    }
}
