using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoBrickBreaker
{
    class Sprite
    {
       public Vector2 position;
       public Texture2D texture;
       public Color tint;

        public Sprite(Vector2 vector2, Texture2D texture2D, Color color)
        {
            this.position = vector2;
            this.texture = texture2D;
            this.tint = color;


        }
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, tint);
        }





    }
}
