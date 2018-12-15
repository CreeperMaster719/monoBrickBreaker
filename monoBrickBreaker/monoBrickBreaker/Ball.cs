using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoBrickBreaker
{
    class Ball : Sprite
    {
        public Ball(Vector2 vector2, Texture2D texture, Color color)
        :base(vector2, texture, color)
        {

        }
        public int xSpeed = 5;
        public int ySpeed = 5;
        
        
        public void Update(Viewport viewport, Rectangle HitBoxPaddle, List<Brick> bricks, int numberOfBricks)
        {
            if(position.X < 0)
            {
                xSpeed *= -1;
            }
            if (position.Y < 0)
            {
                ySpeed *= -1;
            }
            if(position.X + texture.Width > viewport.Width)
            {
                xSpeed *= -1;
            }
            if(position.Y + texture.Height > viewport.Height)
            {
                ySpeed *= -1;
            }
            if(HitBox.Intersects(HitBoxPaddle))
            {
                ySpeed *= -1;
            }

            foreach (Brick brick in bricks)
            {
                if (HitBox.Intersects(brick.HitBoxBottom))
                {
                    ySpeed *= -1;
                    brick.health--;
                    return;
                    //hasCollided = true;
                }
                if (HitBox.Intersects(brick.HitBoxTop))
                {
                    ySpeed *= -1;
                    brick.health--;
                    return;
                    //hasCollided = true;
                }
                if (HitBox.Intersects(brick.HitBoxLeft))
                {
                    xSpeed *= -1;
                    brick.health--;
                    return;
                    //hasCollided = true;
                }
                if (HitBox.Intersects(brick.HitBoxRight))
                {
                    xSpeed *= -1;
                    brick.health--;
                    return;
                    //hasCollided = true;
                }


            }

            position.X += xSpeed;
            position.Y += ySpeed;
        }



        public void debugTest(Brick bigBrick, int health)
        {
            if (HitBox.Intersects(bigBrick.HitBoxBottom))
            {
                ySpeed *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxTop))
            {
                ySpeed *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxLeft))
            {
                xSpeed *= -1;
                bigBrick.health--;
            }
            if (HitBox.Intersects(bigBrick.HitBoxRight))
            {
                xSpeed *= -1;
                bigBrick.health--;
            }
        }
    }
}
