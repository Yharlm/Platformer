using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Platformer
{
    public class Game1 : Game
    {
        player player = new player();
        Texture2D ballTexture;
        Texture2D wall_texture;
        Texture2D Grass;
        Vector2 pos;
        Vector2 ball_pos;
        Vector2 grid_pos;
        int x, y;
        float ball_speed = 30f;
        int[,] grid = new int[20, 20];
        bool executed = false;
        float acceleration = 20f;





        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private AnimatedTexture spriteTexture;
        // The rotation of the character on screen
        private const float rotation = 0;
        // The scale of the character, how big it is drawn
        private const float scale = 0.5f;
        // The draw order of the sprite
        private const float depth = 0.5f;
        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            spriteTexture = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
            IsMouseVisible = true;
        }
        private void Setup()
        {
            for (int i = 1; i < 20; i++)
            {
                grid[11, i] = 1;
                grid[10, i] = 1;
                grid[9, i] = 2;


            }
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ball_pos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
        }
        // The game visible area
        private Viewport viewport;
        // The position to draw the character
        private Vector2 characterPos;
        // How many frames/images are included in the animation
        private const int frames = 8;
        // How many frames should be drawn each second, how fast does the animation run?
        private const int framesPerSec = 10;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            wall_texture = Content.Load<Texture2D>("dirt");
            Grass = Content.Load<Texture2D>("grass_side_carried");
            spriteTexture.Load(Content, "pngegg", frames, framesPerSec);

        }

        protected override void Update(GameTime gameTime)
        {


            if (executed == false)
            {
                executed = true;
                Setup();
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteTexture.UpdateFrame(elapsed);

            base.Update(gameTime);
            // TODO: Add your update logic here
            float updatedBallSpeed = ball_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();
            float size_diference = player.size * 63;
            if (keyboardState.IsKeyDown(Keys.D))
            {

                ball_pos.X += ball_speed;
                if (ball_pos.X % 100 == 0)
                {
                    x += 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                ball_pos.X -= ball_speed;
                if (ball_pos.X % 100 == 0)
                {
                    x -= 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                ball_pos.Y += 20f;
                if (ball_pos.Y % 100 == 0)
                {
                    y += 1;
                }
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                ball_pos.Y -= 20;
                if (ball_pos.Y % 100 == 0)
                {
                    y -= 1;
                }
            }
            else try
                {
                    if (grid[y + 1, x] == 0)
                    {
                        ball_pos.Y += acceleration;
                        if (ball_pos.Y % 100 == 0)
                        {
                            y += 1;
                            acceleration*=2;
                        }
                        
                    }
                    else
                    {
                        if (acceleration >= 200f)
                        {
                            grid[y+1, x] = 0;
                        }
                        acceleration = 20f;

                    }

                }
                catch (IndexOutOfRangeException)
                {
                    x = 0;
                    y = 0;
                    acceleration = 20f;
                }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            float size = 2.5f;
            float offsize = 16f;

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (x == j && y == i)
                    {
                        _spriteBatch.Draw(wall_texture, new Vector2(j * size * offsize, i * size * offsize), null, Color.Red, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
                    }
                    if (grid[i, j] == 1)
                        _spriteBatch.Draw(wall_texture, new Vector2(j * size * offsize, i * size * offsize), null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
                    if (grid[i, j] == 2)
                        _spriteBatch.Draw(Grass, new Vector2(j * size * offsize, i * size * offsize), null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);

                }
            }
            _spriteBatch.End();
            //_spriteBatch.Begin();
            //_spriteBatch.Draw(ballTexture, new Vector2(grid_pos.X, grid_pos.Y), null, Color.Red, 0f, Vector2.Zero, player.size, SpriteEffects.None, 0f);
            //_spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
