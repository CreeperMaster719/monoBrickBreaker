using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoBrickBreaker
{
    class Paddle : Sprite
    {


        public int xSpeed = 1;


        public Paddle(Vector2 vector2, Texture2D texture, Color color)
            : base(vector2, texture, color)
        {

        }


        public void Update(Keys keyLeft, Keys keyRight, Viewport viewport, Keys cheatKey, Vector2 ballPos)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(keyLeft))
            {
                if (position.X > 0)
                {
                    position.X -= 8;
                }
                else
                {
                    position.X += 8;
                }
            }
             if (keyboard.IsKeyDown(keyRight))
            {
                if (position.X + texture.Width < viewport.Width)
                {
                    position.X += 8;
                }

                else
                {
                    position.X -= 8;
                }
            }
             if(keyboard.IsKeyDown(cheatKey))
            {
                position.X = ballPos.X;
            }


        }


    


        









    }
}
