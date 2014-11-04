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

        public Vector2 getVisualForWhite(Vector2 logicalPos){
            float x = borderSize + logicalPos.X * sizeOfTile;
            float y = borderSize + logicalPos.Y * sizeOfTile;

            return new Vector2(x, y);
        }
        //Inverterat schackbräde
        public Vector2 getVisualForBlack(Vector2 logicalPos)
        {
            float x = borderSize + (7 - logicalPos.X) * sizeOfTile;
            float y = borderSize + (7 - logicalPos.Y) * sizeOfTile;

            return new Vector2(x, y);
        }
       
    }                                       
}
