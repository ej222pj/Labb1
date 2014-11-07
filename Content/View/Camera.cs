using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content
{
    class Camera
    {
            private int levelWidth;
            private int levelHeight;
            private static int frame;
            public int width = 10;
            public int height = 10;
            private int offSet = 10;
            private float scale;

            public Camera(int levelWidth, int levelHeight)
            {
                this.levelWidth = levelWidth;
                this.levelHeight = levelHeight;
            }

            void setDimensions()
            {
                int scaleX = (width - offSet * 2) / levelWidth;
                int scaleY = (height - offSet * 2) / levelHeight;

                scale = scaleX;
                if (scaleY < scaleX)
                {
                    scale = scaleY;
                }
            }
        public void setFrame(int frameSize)
        {
            frame = frameSize;
        }
        public float getScale()
        {
            return scale;
        }
        public float toViewX(float x)
        {
            return x * scale + frame;
        }

        public float toViewY(float y)
        {
            return y * scale + frame;
        }
    }
}
        //private int sizeOfTile = 64;
        //private int borderSize = 64;
        //private int levelWidth = 512;
        //private int levelHeight = 512;
        //private float scale;

        //public void reScale(int width/*320*/, int height/*240*/){
        //    float scaleX = (width - borderSize * 2) / levelWidth;
        //    float scaleY = (height - borderSize * 2) / levelHeight;

        //    //Sätter skärmen efter vilken av X/Y som är minst
        //    scale = scaleX;
        //    if (scaleY < scaleX)
        //    {
        //        scale = scaleY;
        //    }
        //}

        //public float getScale()
        //{
        //    return scale;
        //}

        //public Vector2 getVisualForWhite(Vector2 logicalPos){
        //    float x = borderSize + logicalPos.X * sizeOfTile;
        //    float y = borderSize + logicalPos.Y * sizeOfTile;

        //    return new Vector2(x, y);
        //}
        ////Inverterat schackbräde
        //public Vector2 getVisualForBlack(Vector2 logicalPos)
        //{
        //    float x = borderSize + (7 - logicalPos.X) * sizeOfTile;
        //    float y = borderSize + (7 - logicalPos.Y) * sizeOfTile;

        //    return new Vector2(x, y);
        //}
 
