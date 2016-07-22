using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSimulator.Screens.Ui
{
    static class FontManager
    {
        public static SpriteFont HeadlineFont { get; private set; }
        public static SpriteFont MenuFont { get; private set; }

        public static void LoadContent(ContentManager contentManager)
        {
            HeadlineFont = contentManager.Load<SpriteFont>("HeadlineFont");
            MenuFont = contentManager.Load<SpriteFont>("MenuFont");
        }
    }
}
