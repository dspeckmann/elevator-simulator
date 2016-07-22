using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ElevatorSimulator.Screens.Ui
{
    // TODO: Don't inherit ComponentList to improve component handling?
    // TODO: Instead of MenuList give all components an index (like TabIndex in WinForms)
    class MenuList : ComponentList
    {
        private int focusedButton = 0;

        public MenuList(Vector2 position, int padding, Orientation orientation)
            : base(position, padding, orientation)
        {
            InputManager.InputModeChanged += InputManager_InputModeChanged;
        }

        // TODO: Improve to select first entry when user starts using the keyboard
        private void InputManager_InputModeChanged(InputModeEventArgs e)
        {
            if(e.NewInputMode == InputMode.Keyboard) focusedButton = components.Count - 1;
        }

        public override void AddComponent(IComponent component)
        {
            if (!(component is Button)) return;
            base.AddComponent(component);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(InputManager.Mode == InputMode.Keyboard && components.Count > 0)
            {
                components.ForEach((c) => (c as Button).Unfocus());

                if(InputManager.CurrentKeyboardState.IsKeyDown(Keys.Enter) && InputManager.LastKeyboardState.IsKeyUp(Keys.Enter))
                {
                    (components[focusedButton] as Button).Select();
                }
                else if (InputManager.CurrentKeyboardState.IsKeyDown(Keys.Up) && InputManager.LastKeyboardState.IsKeyUp(Keys.Up))
                {
                    if (focusedButton > 0) focusedButton--;
                    else focusedButton = components.Count - 1;
                }
                else if(InputManager.CurrentKeyboardState.IsKeyDown(Keys.Down) && InputManager.LastKeyboardState.IsKeyUp(Keys.Down))
                {
                    if (focusedButton < components.Count - 1) focusedButton++;
                    else focusedButton = 0;
                }

                (components[focusedButton] as Button).Focus();
            }
        }
    }
}
