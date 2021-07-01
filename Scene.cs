using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer2
{
    class Scene
    {
        Camera camera;
        Shape[] shapesList;

        public Scene( Camera cameraIn, Shape[] shapesListIn)
        {
            camera = cameraIn;
            shapesList = shapesListIn;
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public Shape[] GetShapesList()
        {
            return shapesList;
        }
    }
}
