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
        private int frame;

        private Camera camera;




        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            m_windowWidth = graphicsDevice.Viewport.Width;
            m_windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(m_windowWidth, m_windowHeight);
            

            spriteBatch = new SpriteBatch(graphicsDevice);
            boxTexture = content.Load<Texture2D>("images");
        }

        internal void drawLevel(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel) 
        {                     
            spriteBatch.Begin();

            frame = rectangleToDraw.Width;
            if (rectangleToDraw.Height < rectangleToDraw.Width)
            {
                frame = rectangleToDraw.Height;
            }
            camera.setFrame(frame);

            camera.setDimentions();
            rectangleToDraw.X = (int)camera.getScale();
            rectangleToDraw.Y = (int)camera.getScale();
            rectangleToDraw.Width = (int)camera.toViewX(rectangleToDraw.X);
            rectangleToDraw.Height = (int)camera.toViewY(rectangleToDraw.Y);
            
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);
            
            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);
 
            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width, thicknessOfBorder), borderColor);
            spriteBatch.End();
        } 

        internal void drawBall(BallSimulation ball)
        {
            int vx = (int)(ball.getXPos() * frame);
            int vy = (int)(ball.getYPos() * frame);

            Rectangle newBall = new Rectangle(vx - 50, vy , 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(boxTexture, newBall, Color.White);
            spriteBatch.End();
        }
    }
}
