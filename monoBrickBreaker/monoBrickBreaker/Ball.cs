using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace monoBrickBreaker
{
    class Ball : Sprite
    {

        public Vector2 speed;
        public float baseXSpeed;
        bool gameOver;
        bool isReset;
        public Ball(Vector2 vector2, Texture2D texture, Color color)
        : base(vector2, texture, color)
        {
            speed = new Vector2(5, 5);
            baseXSpeed = speed.X;
        }
        

        public void Update(Viewport viewport, Rectangle HitBoxPaddle, List<Brick> bricks, int numberOfBricks, Keys ResetKey, SoundEffect player, SoundEffect effect)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(ResetKey))
            {
                isReset = true;
            }

            if (position.X < 0)
            {
                speed.X = Math.Abs(speed.X);
            }
            if (position.Y < 0)
            {
                speed.Y = Math.Abs(speed.Y);
            }
            if (position.X + texture.Width > viewport.Width)
            {
                speed.X = -Math.Abs(speed.X);
            }
            if (position.Y + texture.Height > viewport.Height)
            {
                gameOver = true;
            }
            if (HitBox.Intersects(HitBoxPaddle))
            {
                effect.Play();
                
                speed.Y = -Math.Abs(speed.Y);

                float ratio = ((position.X + texture.Width / 2) - (HitBoxPaddle.X + HitBoxPaddle.Width / 2)) / (HitBoxPaddle.Width / 2);    
                if(ratio < 0)
                {
                    
                }

                speed.X = ratio * baseXSpeed;//Math.Abs(speed.X);

                if (Math.Abs(speed.X) > 7)
                {
                    speed.X = 7;
                }
            }

            foreach (Brick brick in bricks)
            {
                bool wasHit = false;

                if (HitBox.Intersects(brick.HitBoxBottom))
                {
                    speed.Y = Math.Abs(speed.Y);
                    wasHit = true;
                    //hasCollided = true;
                }
                else if (HitBox.Intersects(brick.HitBoxTop))
                {
                    speed.Y = -Math.Abs(speed.Y);
                    wasHit = true;
                    //hasCollided = true;
                }

                if (HitBox.Intersects(brick.HitBoxLeft))
                {
                    speed.X = -Math.Abs(speed.X);
                    wasHit = true;
                    //hasCollided = true;
                }
                else if (HitBox.Intersects(brick.HitBoxRight))
                {
                    speed.X = Math.Abs(speed.X);
                    wasHit = true;
                    //hasCollided = true;
                }

                if(wasHit)
                {
                    player.Play();
                    brick.health--;
                }

            }

            position.X += speed.X;
            position.Y += speed.Y;
        }
        public bool gameCheck()
        {
            if (gameOver)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Restart(Keys RestartKey)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(RestartKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ResetGaneCheck()
        {
            gameOver = false;
        }

        public void StartGame(Keys startGame)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(startGame))
            {
                speed.X = 5;
                speed.Y = 5;
            }
        }
        public void debugTest(Brick bigBrick, int health)
        {
            if (HitBox.Intersects(bigBrick.HitBoxBottom))
            {
                speed.Y *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxTop))
            {
                speed.Y *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxLeft))
            {
                speed.X *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxRight))
            {
                speed.X *= -1;
                bigBrick.health--;
            }
        }
        public bool Reset()
        {
            if (isReset)
            {
                isReset = false;
                return true;
                

            }
            else
            {
                return false;
            }
            
        }


    }
}
