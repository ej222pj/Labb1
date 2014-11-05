using Labb1.Content.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content.View
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Texture2D boxTexture;   

        private int m_windowWidth;
        private int m_windowHeight;

        private Camera camera;




        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            m_windowWidth = graphicsDevice.Viewport.Width;
            m_windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(m_windowWidth, m_windowHeight);
            camera.setDimentions(m_windowWidth, m_windowHeight);

            spriteBatch = new SpriteBatch(graphicsDevice);
            boxTexture = content.Load<Texture2D>("images");
        }

        internal void drawLevel() 
        {
            
        }

        internal void drawBall(BallSimulation ball)
        {
            int vx = (int)(ball.getXPos() * m_windowWidth);
            int vy = (int)(ball.getYPos() * m_windowHeight);

            Rectangle destrect = new Rectangle(vx - 25, vy - 25, 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(boxTexture, destrect, Color.White);
            spriteBatch.End();
        }
    }
}
