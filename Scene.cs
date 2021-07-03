using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Scene
    {
        Camera camera;
        Shape[] shapesList;
        Light[] lightsList;

        public Scene( Camera cameraIn, Shape[] shapesListIn, Light[] lightsListIn)
        {
            camera = cameraIn;
            shapesList = shapesListIn;
            lightsList = lightsListIn;
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public Shape[] GetShapesList()
        {
            return shapesList;
        }

        public Light[] GetLightList()
        {
            return lightsList;
        }
    }
}
