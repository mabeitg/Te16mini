using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Te16mini
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player, player2;
        Ball ball;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player();
            player.up = Keys.W;
            player.left = Keys.A;
            player.down = Keys.S;
            player.right = Keys.D;
            player.attack = Keys.LeftControl;

            player2 = new Player();
            player2.up = Keys.Up;
            player2.left = Keys.Left;
            player2.down = Keys.Down;
            player2.right = Keys.Right;
            player2.attack = Keys.RightControl;
            // TODO: Add your initialization logic here

            ball = new Ball();
            ball.position = new Vector2(100, 100);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Texture2D square = Content.Load<Texture2D>("square");
            player.texture = square;
            player2.texture = square;
            ball.texture = square;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (player.Hitbox.Intersects(player2.Hitbox))
            {
                if (player.IsAttacking)
                {
                    Vector2 att = player2.position - player.position;
                    att = att * 0.1f;

                    player2.GetPushed(att);
                }
                if (player2.IsAttacking)
                {
                    Vector2 att = player.position - player2.position;
                    att = att * 0.1f;

                    player.GetPushed(att);
                }
            }

            ball.GetPushed(player2);
            //            ball.GetPushed(player);

            if (ball.Hitbox.Intersects(player.Hitbox))
            {
                Vector2 distance = ball.position - player.position;

                if (Math.Abs(distance.Y) > Math.Abs(distance.X))
                {
                    ball.velocity.Y = player.velocity.Y * 1.1f;
                    player.velocity.Y = -player.velocity.Y;
                }
                else
                {
                    ball.velocity.X = player.velocity.X * 1.1f;
                    player.velocity.X = -player.velocity.X;
                }
            }
                ball.Update(gameTime);
                player.Update(gameTime);
                player2.Update(gameTime);

                // TODO: Add your update logic here

                base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
