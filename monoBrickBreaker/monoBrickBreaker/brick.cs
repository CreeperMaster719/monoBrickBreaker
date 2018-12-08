using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoBrickBreaker
{
    class Brick : Sprite
    {
        
        public int health = 0;

        public Rectangle HitBoxBottom
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y + (texture.Height / 2), texture.Width, texture.Height / 2);
            }
        }
        public Rectangle HitBoxTop
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height / 2);
            }
        }
        public Rectangle HitBoxLeft
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (texture.Width / 8), texture.Height);
            }
        }
        public Rectangle HitBoxRight
        {
            get
            {
                return new Rectangle((int)position.X + (texture.Width* 7/8), (int)position.Y, texture.Width / 8,texture.Height);
            }
        }



        public Brick(Vector2 vector2, Texture2D texture, Color tint, int health)
        :base(vector2, texture, tint)
        {
            this.health = health;
            
        }
        public Color color = Color.White;
        Color[] colors = {Color.Red, Color.Orange, Color.Yellow, Color.Lime, Color.Green, Color.SkyBlue, Color.Blue, Color.Lavender, Color.Purple, Color.Pink, Color.Gray, Color.White, Color.Wheat, Color.RosyBrown, Color.DarkOrange, Color.Goldenrod, Color.Honeydew, Color.LightSkyBlue, Color.Magenta, Color.MediumOrchid };
        
        public void Update()
        {
            color = colors[health];



        }

 
        












    }
}
