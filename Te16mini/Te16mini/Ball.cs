using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Te16mini
{
    class Ball
    {
        public Texture2D texture;
        public Vector2 position, velocity;
        Color squareColor = Color.Green;
        public Rectangle Hitbox
        {
            get
            { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public void Update(GameTime gameTime)
        {
            velocity = velocity * (float).95;
            position += velocity;
        }

        public void GetPushed(Player player)
        {
            if (Hitbox.Intersects(player.Hitbox))
            {
                Vector2 distance = position - player.position;

                if (Math.Abs(distance.Y) > Math.Abs(distance.X))
                    velocity.Y = player.velocity.Y*1.1f;
                else
                    velocity.X = player.velocity.X*1.1f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, squareColor);
        }

    }
}
