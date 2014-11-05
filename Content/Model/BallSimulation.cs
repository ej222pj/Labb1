﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content.Model
{
    class BallSimulation
    {
       Ball ball = new Ball();
       internal void Update(Microsoft.Xna.Framework.GameTime gameTime)
       {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ball.m_x += elapsedTime * ball.speedX;

            if (ball.m_x > 1.0f)
            {
                ball.speedX = ball.speedX * -1.0f;
            }
            if (ball.m_x < 0.0f)
            {
                ball.speedX = ball.speedX * -1.0f;
            }

            ball.m_y += elapsedTime * ball.speedY;

            if (ball.m_y > 1.0f)
            {
                ball.speedY = ball.speedY * -1.0f;
            }
            if (ball.m_y < 0.0f)
            {
                ball.speedY = ball.speedY * -1.0f;
            }

       }
       public float getXPos()
       {
           return ball.m_x;
       }
       public float getYPos()
       {
           return ball.m_y;
       }
    }
}
