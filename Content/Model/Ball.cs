using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content.Model
{
    class Ball
    {
        public float centerX = 1;
        public float centerY = 1;
        public float diameter = 0.1f;
        private float speedX = 1.0f;
        private float speedY = 1.0f;

        public void setSpeedX(float speedX){
            this.speedX = speedX;
        }

        public void setSpeedY(float speedY)
        {
            this.speedY = speedY;
        }

        //public Ball(float speedX, float speedY)
        //{
        //    this.speedX = speedX;
        //    this.speedY = speedY;
        //}
    }
}
