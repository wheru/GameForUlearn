using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SnottyFarmer1.Code;

namespace SnottyFarmer1
{
    enum Stat
    {
        Screen,
        Game
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Stat Stat = Stat.Screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Screen.Back = Content.Load<Texture2D>("Back");
            Screen.SpriteFont = Content.Load<SpriteFont>("Front");
            PlayingField.Init(_spriteBatch, _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth);
            Location.Texture2D = Content.Load<Texture2D>("Location");
            Farmer.Farmer1 = Content.Load<Texture2D>("Farmer");
            Snot.Snot1 = Content.Load<Texture2D>("Snot");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            switch (Stat)
            {
                case Stat.Screen:
                    if (keyboardState.IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;
                case Stat.Game:
                    PlayingField.UpDate();
                    if (keyboardState.IsKeyDown(Keys.Escape)) Stat = Stat.Screen;
                    if (keyboardState.IsKeyDown(Keys.E)) PlayingField.FarmerSnot();

                        break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               // Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.YellowGreen);
            _spriteBatch.Begin();
            switch (Stat)
            {
                case Stat.Screen:
                    Screen.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    PlayingField.Draw();
                    break;

            }
           
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}