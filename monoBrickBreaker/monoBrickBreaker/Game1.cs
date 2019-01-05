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
        Ball ball;
        bool youWin = false;
        SpriteFont font;
        Texture2D pixel;
        Brick bigBrick;
        int lives = 3;

        List<Brick> bricks = new List<Brick>();
       public int numberOfBricks = 10;
        public int numberOfRows = 0;

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

            numberOfRows = numberOfBricks / 10;

            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D paddleTexture = Content.Load<Texture2D>("trampoline");
            Vector2 paddlePos = new Vector2(640, 650);
            Color paddleTint = Color.White;
            trampoline = new Paddle(paddlePos, paddleTexture, paddleTint);
            Texture2D ballTexture = Content.Load<Texture2D>("brickball");
            Vector2 ballPos = new Vector2(640, 640);
            Color ballTint = Color.White;
            ball = new Ball(ballPos, ballTexture, ballTint);
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });
           Texture2D brickTexture = Content.Load<Texture2D>("brick");
            Color brickTint = Color.White;
            for (int j = 0; j < numberOfRows; j++)
            {
                for (int i = 0; i < numberOfBricks; i++)
                {

                    Vector2 brickPos = new Vector2((i * 128), 30 * j);

                    bricks.Add(new Brick(brickPos, brickTexture, brickTint, numberOfRows - j ));
                }
            }

             //bigBrick = new Brick(new Vector2(640, 310), brickTexture, brickTint, 2);



        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(bricks.Count == 0)
            {
                youWin = true;
            }
            // TODO: Add your update logic here

            // bigBrick.Update();
            // brickball.debugTest(bigBrick, bigBrick.health);
            Brick toRemove = null;

            foreach (Brick brick in bricks)
            {

                if (brick.health == 0)
                {
                    toRemove = brick;
                }
                brick.Update();
            }

            if (toRemove != null)
            {
                bricks.Remove(toRemove);
            }
            if (lives >= 0)
            {
                ball.Update(GraphicsDevice.Viewport, trampoline.HitBox, bricks, numberOfBricks, Keys.Y);
                trampoline.Update(Keys.S, Keys.F, GraphicsDevice.Viewport, Keys.I, ball.position);
            }

            if (ball.gameCheck())
            {
                lives--;
                ball.position = new Vector2(610, 360);
                ball.speed.X = 0;
                ball.speed.Y = 0;
                ball.ResetGaneCheck();
            }
            if (ball.Reset())
            {
                lives = 3;

                ball.position = new Vector2(640, 360);

            }
                base.Update(gameTime);
            
        }

        
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            trampoline.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            if(youWin)
            {
                spriteBatch.DrawString(font, "GG! You Won! Press R to Restart.", new Vector2(640, 240), Color.Black);
            }
            if (lives < 1)
            {
                spriteBatch.DrawString(font, "You lose", new Vector2(640, 680), Color.Black);
                spriteBatch.DrawString(font, "Retry? Press Y. ", new Vector2(640, 630), Color.Black);
            }
            ball.StartGame(Keys.Space);
            //  bigBrick.Draw(spriteBatch);
            spriteBatch.DrawString(font, $"{lives} lives left", new Vector2(320, 680), Color.Black);
            foreach (Brick brick in bricks)
            {
                brick.Draw(spriteBatch);
                
               // spriteBatch.Draw(pixel, brick.HitBoxBottom, Color.Orange);
               //spriteBatch.Draw(pixel, brick.HitBoxTop, Color.Yellow);
               // spriteBatch.Draw(pixel, brick.HitBoxLeft, Color.Green);
               // spriteBatch.Draw(pixel, brick.HitBoxRight, Color.Blue);
               //fffspriteBatch.Draw(pixel, brick.HitBox, Color.Black);
                //brick.tint = brick.color;
            }
            spriteBatch.DrawString(font, "Top Of Hitbox", trampoline.position, Color.Black);
            //spriteBatch.Draw(pixel, trampoline.HitBox, Color.DarkRed);
           // spriteBatch.Draw(pixel, ball.HitBox, Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
            
        }
    }
}
