using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace ElevatorSimulator.Screens.Ui
{
    class Button : IComponent
    {
        // TODO: Customized EventHandler?
        public event EventHandler Selected;

        public enum ButtonState
        {
            Disabled,
            Enabled,
            Focused
        }

        public struct ButtonColors
        {
            public Color Enabled { get; set; }
            public Color Disabled { get; set; }
            public Color Focused { get; set; }

            public ButtonColors(Color enabled, Color disabled, Color focused)
            {
                Enabled = enabled;
                Disabled = disabled;
                Focused = focused;
            }
        }

        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public ButtonColors Colors { get; set; }
        public ButtonState State { get; set; }
        public SpriteFont Font { get; set; }

        public Button(string text, Vector2 position, SpriteFont font, ButtonColors colors)
        {
            Text = text;
            Position = position;
            Colors = colors;
            State = ButtonState.Enabled;
            Font = font;
        }

        public void Focus()
        {
            if(State != ButtonState.Disabled)
            { 
                State = ButtonState.Focused;
            }
        }

        public void Unfocus()
        {
            if(State != ButtonState.Disabled)
            {
                State = ButtonState.Enabled;
            }
        }

        public void Select()
        {
            if(Selected != null)
            {
                Selected(this, EventArgs.Empty);
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(Position.ToPoint(), Font.MeasureString(Text).ToPoint());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            switch(State)
            {
                case ButtonState.Enabled:
                    color = Colors.Enabled;
                    break;
                case ButtonState.Focused:
                    color = Colors.Focused;
                    break;
                case ButtonState.Disabled:
                    color = Colors.Disabled;
                    break;
            }
            spriteBatch.DrawString(Font, Text, Position, color); // TODO: Switch between colors
        }

        public void Update(GameTime gameTime)
        {
            if(InputManager.Mode == InputMode.Mouse && State != ButtonState.Disabled)
            {
                if(GetBounds().Contains(InputManager.CurrentMouseState.Position)) // TODO: Calculate correct Width
                {
                    State = ButtonState.Focused;
                    if(InputManager.CurrentMouseState.LeftButton == XnaButtonState.Pressed
                        && InputManager.LastMouseState.LeftButton == XnaButtonState.Released)
                    {
                        Select();
                    }
                }
                else
                {
                    State = ButtonState.Enabled;
                }
            }
        }
    }
}
