using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens
{
    // TODO: Add "Change Savegame" button in main menu
    // TODO: When "Continue Game" is clicked pass savegame ID or whatever to LoadScreen, which then loads it along with sprites & stuff
    // TODO: LoadScreen then passes the date to CareerScreen which then passes it to all subsequent screens ("Day" screen, "Buy" screen, etc)
    class MainMenuScreen : Screen
    {
        private IEnumerable<GameProgress> availableSavegames;

        public MainMenuScreen() : base()
        {
            var mainList = new Ui.ComponentList(new Vector2(200, 100), 20, Ui.Orientation.Vertical);
            mainList.AddComponent(new Ui.Label("Main Menu", Vector2.Zero, Ui.FontManager.HeadlineFont, Color.Blue));
            var menuList = new Ui.MenuList(Vector2.Zero, 20, Ui.Orientation.Vertical);
            mainList.AddComponent(menuList);
            components.Add(mainList);

            var newButton = new Ui.Button("New game", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            newButton.Selected += NewButton_Selected;
            menuList.AddComponent(newButton);
            var continueButton = new Ui.Button("Continue", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            continueButton.Selected += ContinueButton_Selected;
            menuList.AddComponent(continueButton);
            var settingsButton = new Ui.Button("Settings", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            settingsButton.Selected += SettingsButton_Selected;
            menuList.AddComponent(settingsButton);
            var creditsButton = new Ui.Button("Credits", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            creditsButton.Selected += CreditsButton_Selected;
            menuList.AddComponent(creditsButton);
            var quitButton = new Ui.Button("Quit", Vector2.Zero, Ui.FontManager.MenuFont, new Ui.Button.ButtonColors(Color.Blue, Color.Gray, Color.White));
            quitButton.Selected += QuitButton_Selected;
            menuList.AddComponent(quitButton);

            availableSavegames = GameProgress.GetAvailableSavegames();
        }

        private void NewButton_Selected(object sender, EventArgs e)
        {
            // TODO: New screen for user to input name (and maybe other settings?)
        }

        private void ContinueButton_Selected(object sender, EventArgs e)
        {
            // TODO: Let user select savegame, either after click on this button or before in submenu
            ScreenManager.PushScreen(new ProgressScreen(availableSavegames.First()));
        }

        private void CreditsButton_Selected(object sender, EventArgs e)
        {
            ScreenManager.PushScreen(new CreditsScreen());
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
