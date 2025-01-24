using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.ConstrainedExecution;

namespace Platformer
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Texture2D wall_texture;
        Vector2 pos;
        Vector2 ball_pos;
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
            wall_texture = Content.Load<Texture2D>("Wall");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float updatedBallSpeed = ball_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.D))
            {
                ball_pos.X += updatedBallSpeed;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                ball_pos.X -= updatedBallSpeed;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture,ball_pos,Color.Red);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.Draw(wall_texture, new Vector2(0, 222), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
