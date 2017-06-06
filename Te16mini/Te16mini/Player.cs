using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Te16mini
{
    class Player
    {
        public bool IsAttacking;
        public Texture2D texture;
        float acceleration = (float).2;
        public Vector2 position, velocity;
        Color squareColor = Color.Yellow;
        public Keys up, left, right, down, attack;
        public Rectangle Hitbox
        {
            get
            { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public void Update(GameTime gameTime)
        {
            velocity = velocity * (float).95;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(up))
            {
                velocity.Y -=acceleration;
            }
            if (state.IsKeyDown(left))
            {
                velocity.X -= acceleration;
            }
            if (state.IsKeyDown(down))
            {
                velocity.Y += acceleration;
            }
            if (state.IsKeyDown(right))
            {
                velocity.X += acceleration;
            }

            if (state.IsKeyDown(attack))
            {
                IsAttacking = true;
                velocity = velocity / 2;
            }
            else
                IsAttacking = false;

            position += velocity;
        }

        public void GetPushed(Vector2 pushVelocity)
        {
            velocity = velocity + pushVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, squareColor);
        }

    }
}
