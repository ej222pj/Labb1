using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content
{
    class Camera
    {
        private int sizeOfTile = 64;
        private int borderSize = 64;
        private int levelWidth = 512;
        private int levelHeight = 512;
        private float scale;

        public void reScale(int width/*320*/, int height/*240*/){
            float scaleX = (width - borderSize * 2) / levelWidth;
            float scaleY = (height - borderSize * 2) / levelHeight;

            //Sätter skärmen efter vilken av X/Y som är minst
            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public float getScale()
        {
            return scale;
        }

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
