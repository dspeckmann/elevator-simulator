using ElevatorSimulator.Screens.Ui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens
{
    class Screen
    {
        protected List<IComponent> components;

        public Screen()
        {
            components = new List<IComponent>();
        }

        public void Update(GameTime gameTime)
        {
            components.ForEach((c) => c.Update(gameTime));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            components.ForEach((c) => c.Draw(spriteBatch));
        }
    }
}
