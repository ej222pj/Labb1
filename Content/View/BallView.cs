﻿using Labb1.Content.Model;
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

        private Camera camera;
                                                    
        public BallView(GraphicsDevice graphicsDevice, ContentManager content, int frame)
        {
            m_windowWidth = graphicsDevice.Viewport.Width;
            m_windowHeight = graphicsDevice.Viewport.Height;

            camera = new Camera(frame);
            camera.setDimensions(m_windowWidth, m_windowHeight);

            spriteBatch = new SpriteBatch(graphicsDevice);
            //circleTexture = content.Load<Texture2D>("SpinningBeachBallOfDeath");
            circleTexture = content.Load<Texture2D>("Svampen");
            background = content.Load<Texture2D>("strand");
        }

        internal void drawLevel(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel, int borderSize) 
        {  
            spriteBatch.Begin();

            int extraFrameX = 0;
            int extraFrameY = 0;
            if (rectangleToDraw.Height > rectangleToDraw.Width)
            {
                extraFrameX = rectangleToDraw.Height - rectangleToDraw.Width;
            }
            if (rectangleToDraw.Width > rectangleToDraw.Height) 
            {
                extraFrameY = rectangleToDraw.Width - rectangleToDraw.Height;
            }
            
            
            //Sätter en bakgrund
            //spriteBatch.Draw(background, new Rectangle(0, 0, m_windowWidth , m_windowHeight ), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + thicknessOfBorder, rectangleToDraw.Width - extraFrameY - (thicknessOfBorder * 2), borderSize), borderColor);
            
            //// Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + thicknessOfBorder, borderSize, rectangleToDraw.Height - (thicknessOfBorder * 2) - extraFrameX), borderColor);
 
            //// Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder - extraFrameY), rectangleToDraw.Y + thicknessOfBorder, borderSize, rectangleToDraw.Height - (thicknessOfBorder * 2) - extraFrameX), borderColor);

            //// Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X + thicknessOfBorder, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder - extraFrameX, rectangleToDraw.Width - extraFrameY - (thicknessOfBorder * 2), borderSize), borderColor);
            spriteBatch.End();
        } 

        internal void drawBall(BallSimulation ball)
        {
            int vx = (int)(ball.getXPos() * camera.getScale() + camera.getFrame());
            int vy = (int)(ball.getYPos() * camera.getScale() + camera.getFrame());
            int ballSize = (int)(ball.getDiameter() * camera.getScale());

            Rectangle newBall = new Rectangle(vx - ballSize / 2, vy - ballSize / 2, ballSize, ballSize);

            spriteBatch.Begin();
            spriteBatch.Draw(circleTexture, newBall, Color.White);             
            spriteBatch.End();
        }
    }
}
