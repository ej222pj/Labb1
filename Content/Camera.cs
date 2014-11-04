using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content
{
    class Camera
    {
        int sizeOfTile = 64;
        int borderSize = 64;
        Vector2 vec;

        public Vector2 getVisualX(Vector2 logical){
            float x = borderSize + logical.X * sizeOfTile;
            float y = borderSize + logical.Y * sizeOfTile;

            return new Vector2(x, y);
        }
       
    }                                       
}
