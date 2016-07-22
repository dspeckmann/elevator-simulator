using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ElevatorSimulator.Screens
{
    class ProgressScreen : Screen
    {
        private GameProgress progress;

        public ProgressScreen(GameProgress gameProgress)
            : base()
        {
            progress = gameProgress;

            components.Add(new Ui.Label(string.Format("Welcome back, {0}!", progress.Name), new Vector2(100, 100), Ui.FontManager.MenuFont, Color.White));
            components.Add(new Ui.Label(string.Format("You are at day {0}.", progress.Day), new Vector2(120, 200), Ui.FontManager.MenuFont, Color.White));
        }
    }
}
