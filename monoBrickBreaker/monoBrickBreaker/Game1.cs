using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace monoBrickBreaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Paddle trampoline;
        Ball brickball;
        SpriteFont font;
        Texture2D pixel;

        List<Brick> bricks = new List<Brick>();
       public int numberOfBricks = 10;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D paddleTexture = Content.Load<Texture2D>("rectangle");
            Vector2 paddlePos = new Vector2(500, 700);
            Color paddleTint = Color.White;
            trampoline = new Paddle(paddlePos, paddleTexture, paddleTint);
            Texture2D ballTexture = Content.Load<Texture2D>("brickball");
            Vector2 ballPos = new Vector2(50, 50);
            Color ballTint = Color.White;
            brickball = new Ball(ballPos, ballTexture, ballTint);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
            Texture2D brickTexture = Content.Load<Texture2D>("brick");
            Color brickTint = Color.White;
            for (int i = 0; i < numberOfBricks; i++)
            {
                
                Vector2 brickPos = new Vector2((i*128), 50);
                
               bricks.Add(new Brick(brickPos, brickTexture, brickTint, 2));
            }



        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            trampoline.Update(Keys.S, Keys.F, GraphicsDevice.Viewport, Keys.I, brickball.position);
            brickball.Update(GraphicsDevice.Viewport, trampoline.HitBox, bricks, numberOfBricks);
            
            foreach(Brick brick in bricks)
            {
                brick.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            trampoline.Draw(spriteBatch);
            brickball.Draw(spriteBatch);

            foreach (Brick brick in bricks)
            {
                brick.Draw(spriteBatch);
                
                spriteBatch.Draw(pixel, brick.HitBoxBottom, Color.Orange);
               spriteBatch.Draw(pixel, brick.HitBoxTop, Color.Yellow);
                spriteBatch.Draw(pixel, brick.HitBoxLeft, Color.Green);
                spriteBatch.Draw(pixel, brick.HitBoxRight, Color.Blue);
               //fffspriteBatch.Draw(pixel, brick.HitBox, Color.Black);
                brick.tint = brick.color;
            }
            spriteBatch.DrawString(font, "Top Of Hitbox", trampoline.position, Color.Black);
            spriteBatch.Draw(pixel, trampoline.HitBox, Color.DarkRed);
            spriteBatch.Draw(pixel, brickball.HitBox, Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
            
        }
    }
}
