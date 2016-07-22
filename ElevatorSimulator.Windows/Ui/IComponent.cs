using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens.Ui
{
    interface IComponent
    {
        Vector2 Position { get; set; }

        Rectangle GetBounds();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    } 
}
