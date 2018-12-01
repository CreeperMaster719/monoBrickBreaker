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
        public int xSpeed = 1;
        public int ySpeed = 1;
        
        public void Update(Viewport viewport)
        {
            if(position.X < 0)
            {
                xSpeed = 1;
            }
            if (position.Y < 0)
            {
                ySpeed = 1;
            }
            if(position.X + texture.Width > viewport.Width)
            {
                xSpeed = -1;
            }
            if(position.Y + texture.Height > viewport.Height)
            {
                ySpeed = -1;
            }
            position.X += (5 * xSpeed);
            position.Y += (5 * ySpeed);
        }
        



    }
}
