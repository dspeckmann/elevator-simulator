using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens
{
    static class ScreenManager
    {
        private static Stack<Screen> screens;

        static ScreenManager()
        {
            screens = new Stack<Screen>();
        }

        public static void PushScreen(Screen screen)
        {
            screens.Push(screen);
        }

        public static Screen PopScreen()
        {
            // TODO: Make proper exit
            if (screens.Count == 1) Environment.Exit(0);

            return screens.Pop();
        }

        public static void Update(GameTime gameTime)
        {
            screens.Peek().Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            screens.Peek().Draw(spriteBatch);
        }
    }
}
