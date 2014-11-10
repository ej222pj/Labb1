﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content.Model
{
    class Ball
    {
        public float m_x = 0.5f;
        public float m_y = 0.5f;
        public float speedX = 0.7f;
        public float speedY = 0.6f;
        public float diameter = 0.1f;

        public void setSpeedX(float X) 
        {
            speedX = X;
        }
    }
}
