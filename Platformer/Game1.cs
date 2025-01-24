using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.ConstrainedExecution;

namespace Platformer
{
    public class Game1 : Game
    {
        player player = new player();
        Texture2D ballTexture;
        Texture2D wall_texture;
        Vector2 pos;
        Vector2 ball_pos;
        Vector2 grid_pos;
        float ball_speed = 300f;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ball_pos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            wall_texture = Content.Load<Texture2D>("dirt");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float updatedBallSpeed = ball_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();
            float size_diference = player.size*63;
            if (keyboardState.IsKeyDown(Keys.D))
            {
                ball_pos.X += 10f;
                if (ball_pos.X % 100 == 0)
                {
                    grid_pos.X += size_diference;
                }
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                ball_pos.X -= 10f;
                if (ball_pos.X % 100 == 0)
                {
                    grid_pos.X -= size_diference;
                }
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                ball_pos.Y += 10f;
                if (ball_pos.Y % 100 == 0)
                {
                    grid_pos.Y += size_diference;
                }
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                ball_pos.Y -= 10f;
                if (ball_pos.Y % 100 == 0)
                {
                    grid_pos.Y -= size_diference;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            

            _spriteBatch.Begin(SamplerState.PointClamp = );
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _spriteBatch.Draw(wall_texture, new Vector2(i * 100, j * 100), null, Color.White, 0f, Vector2.Zero, 7f, SpriteEffects.None, 0f);
                }
            }
            _spriteBatch.End();
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, new Vector2(grid_pos.X, grid_pos.Y), null, Color.Red, 0f, Vector2.Zero, player.size, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
