using Labb1.Content.Model;
using Labb1.Content.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Labb1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BallView drawBall;
        BallSimulation model = new BallSimulation();
        private Texture2D pixel;
        private static int offSet = 10;


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            
            graphics.PreferredBackBufferWidth = 400;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 400;   // set this value to the desired height of your window

            //Kan rezisa med denna men den töjer allt
            /*this.Window.AllowUserResizing = true;
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            */
           
            Content.RootDirectory = "Content";   
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            spriteBatch = new SpriteBatch(GraphicsDevice);


 
// Somewhere in your LoadContent() method:
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it

            // TODO: use this.Content to load your game content here
            drawBall = new BallView(GraphicsDevice, Content, offSet);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            model.update(elapsedTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.DeepSkyBlue);

            //Ritar ut ramen
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;

            drawBall.drawLevel(titleSafeRectangle, offSet, Color.Cyan, pixel, 1);
            drawBall.drawBall(model);

            //Kan använda konsolen till att skriva ut testdata
            //System.Console.WriteLine(64 + (7-7) * 64);

            base.Draw(gameTime);
        }
    }
}
