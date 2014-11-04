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
 
        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            boxTexture = content.Load<Texture2D>("Bitmap1");
        }

        internal void drawBox()
        {
            Rectangle destrect = new Rectangle(100, 100, 200, 300);

            spriteBatch.Begin();
            spriteBatch.Draw(boxTexture, destrect, Color.White);
            spriteBatch.End();
        }
    }
}
