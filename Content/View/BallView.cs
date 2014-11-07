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
        private Texture2D circleTexture;
        private Texture2D background;

        private int m_windowWidth;
        private int m_windowHeight;
        private int frame;
        private int frameOffset = 10;

        private Camera camera;




        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            m_windowWidth = graphicsDevice.Viewport.Width;
            m_windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(m_windowWidth, m_windowHeight);
            

            spriteBatch = new SpriteBatch(graphicsDevice);
            circleTexture = content.Load<Texture2D>("SpinningBeachBallOfDeath");
            background = content.Load<Texture2D>("strand");
        }

        internal void drawLevel(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel) 
        {                     
            spriteBatch.Begin();
            //Sätter en bakgrund
            spriteBatch.Draw(background, new Rectangle(0, 0, m_windowWidth, m_windowHeight), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
 
            //Sätter ramen till stolek av den minsta sidan av skärmen
            frame = rectangleToDraw.Width;
            if (rectangleToDraw.Height < rectangleToDraw.Width)
            {
                frame = rectangleToDraw.Height;
            }
            camera.setFrame(frame);

            
            rectangleToDraw.Width = frame - frameOffset;
            rectangleToDraw.Height = frame - frameOffset;

            
            
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + frameOffset, rectangleToDraw.Y + frameOffset, rectangleToDraw.Width - frameOffset, thicknessOfBorder), borderColor);
            
            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + frameOffset, rectangleToDraw.Y + frameOffset, thicknessOfBorder, rectangleToDraw.Height - frameOffset), borderColor);
 
            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y + frameOffset, thicknessOfBorder, rectangleToDraw.Height - frameOffset), borderColor);

            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + frameOffset, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width - frameOffset, thicknessOfBorder), borderColor);
            spriteBatch.End();
        } 

        internal void drawBall(BallSimulation ball)
        {
            int vx = (int)(ball.getXPos() * frame - 10);
            int vy = (int)(ball.getYPos() * frame + 10);
            int ballSize = (int)(ball.getDiameter() * frame);

            Rectangle newBall = new Rectangle(vx - ballSize / 2, vy - ballSize / 2, ballSize, ballSize);
            spriteBatch.Begin();
            spriteBatch.Draw(circleTexture, newBall, Color.White);             
            spriteBatch.End();
        }
    }
}
