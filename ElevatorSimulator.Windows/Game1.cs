using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElevatorSimulator
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Screens.Ui.FontManager.LoadContent(Content);
            Screens.ScreenManager.PushScreen(new Screens.MainMenuScreen());
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.UpdateBefore(gameTime);
            Screens.ScreenManager.Update(gameTime);
            InputManager.UpdateAfter(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Screens.ScreenManager.Draw(spriteBatch);
            if(InputManager.Mode == InputMode.Mouse)
            {
                spriteBatch.DrawString(Screens.Ui.FontManager.MenuFont, "x", new Vector2(InputManager.CurrentMouseState.X - 10, InputManager.CurrentMouseState.Y - 10), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
