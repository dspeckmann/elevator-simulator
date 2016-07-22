using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElevatorSimulator.Screens.Ui
{
    class Label : IComponent
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; }

        public Label(string text, Vector2 position, SpriteFont font, Color color)
        {
            Text = text;
            Position = position;
            Font = font;
            Color = color;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(Position.ToPoint(), Font.MeasureString(Text).ToPoint());
        }

        public void Update(GameTime gameTime)
        {
            // Not doing anything so far
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, Position, Color);
        }
    }
}
