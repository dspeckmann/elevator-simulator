using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator
{
    // TODO: Put InputModeEventHandler, InputMode and InputManager in seperate files in "Input" folder/namespace
    public class InputModeEventArgs : EventArgs
    {
        public InputMode NewInputMode { get; }

        public InputModeEventArgs(InputMode newInputMode)
        {
            NewInputMode = newInputMode;
        }
    }

    public enum InputMode
    {
        Mouse,
        Keyboard
    }

    static class InputManager
    {
        public delegate void InputModeEventHandler(InputModeEventArgs e);
        public static event InputModeEventHandler InputModeChanged;

        public static InputMode Mode { get; private set; }
        public static KeyboardState LastKeyboardState { get; private set; }
        public static MouseState LastMouseState { get; private set; }
        public static KeyboardState CurrentKeyboardState { get; private set; }
        public static MouseState CurrentMouseState { get; private set; }

        static InputManager()
        {
            Mode = InputMode.Keyboard;
        }

        public static void UpdateBefore(GameTime gameTime)
        {
            CurrentKeyboardState = Keyboard.GetState();
            CurrentMouseState = Mouse.GetState();

            InputMode oldInputMode = Mode;

            if (CurrentKeyboardState.GetPressedKeys().Count() > 0) Mode = InputMode.Keyboard;
            if (CurrentMouseState.Position != LastMouseState.Position) Mode = InputMode.Mouse;

            if(Mode != oldInputMode && InputModeChanged != null)
            {
                InputModeChanged(new InputModeEventArgs(Mode));
            }
        }

        public static void UpdateAfter(GameTime gameTime)
        {
            LastKeyboardState = CurrentKeyboardState;
            LastMouseState = CurrentMouseState;
        }
    }
}
