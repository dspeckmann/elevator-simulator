using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens
{
    class SettingsMenuScreen : Screen
    {
        public SettingsMenuScreen() : base()
        {
            var mainList = new Ui.ComponentList(new Vector2(200, 100), 20, Ui.Orientation.Vertical);
            mainList.AddComponent(new Ui.Label("Settings", Vector2.Zero, Ui.FontManager.HeadlineFont, Color.Blue));
            var menuList = new Ui.MenuList(Vector2.Zero, 20, Ui.Orientation.Vertical);
            mainList.AddComponent(menuList);
            components.Add(mainList);

            // TODO: Add separators for lists?
            menuList.AddComponent(new Ui.Button("Setting 1", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White)));
            menuList.AddComponent(new Ui.Button("Setting 2", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White)));
            menuList.AddComponent(new Ui.Button("Setting 3", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White)));
            var returnButton = new Ui.Button("Return to main menu", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            returnButton.Selected += ReturnButton_Selected;
            menuList.AddComponent(returnButton);
        }

        private void ReturnButton_Selected(object sender, EventArgs e)
        {
            ScreenManager.PopScreen();
        }
    }
}
