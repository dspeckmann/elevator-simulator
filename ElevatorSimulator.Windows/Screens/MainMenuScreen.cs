using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens
{
    class MainMenuScreen : Screen
    {
        public MainMenuScreen() : base()
        {
            var mainList = new Ui.ComponentList(new Vector2(200, 100), 20, Ui.Orientation.Vertical);
            mainList.AddComponent(new Ui.Label("Main Menu", Vector2.Zero, Ui.FontManager.HeadlineFont, Color.Blue));
            var menuList = new Ui.MenuList(Vector2.Zero, 20, Ui.Orientation.Vertical);
            mainList.AddComponent(menuList);
            components.Add(mainList);

            menuList.AddComponent(new Ui.Button("Start", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White)));
            var settingsButton = new Ui.Button("Settings", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            settingsButton.Selected += SettingsButton_Selected;
            menuList.AddComponent(settingsButton);
            menuList.AddComponent(new Ui.Button("Credits", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White)));
            var quitButton = new Ui.Button("Quit", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            quitButton.Selected += QuitButton_Selected;
            menuList.AddComponent(quitButton);
        }

        private void SettingsButton_Selected(object sender, EventArgs e)
        {
            ScreenManager.PushScreen(new SettingsMenuScreen());
        }

        private void QuitButton_Selected(object sender, EventArgs e)
        {
            ScreenManager.PopScreen();
        }
    }
}
