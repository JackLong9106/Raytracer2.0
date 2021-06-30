using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Scene
    {
        Image image;
        Camera camera;
        Shape[] shapesList;

        public Scene(Image imageIn, Camera cameraIn, Shape[] shapesListIn)
        {
            image = imageIn;
            camera = cameraIn;
            shapesList = shapesListIn;
        }
    }
}
