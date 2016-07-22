using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ElevatorSimulator.Screens
{
    class CreditsScreen : Screen
    {
        public CreditsScreen() : base()
        {
            components.Add(new Ui.Label("Credits", new Vector2(100, 100), Ui.FontManager.HeadlineFont, Color.White));
            components.Add(new Ui.Label("Elevator Simulator. A game by Danny Speckmann.", new Vector2(120, 300), Ui.FontManager.MenuFont, Color.White));

            // TODO: Add back button that gets activated on every key or mouse button press
        }
    }
}
