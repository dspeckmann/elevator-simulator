using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ElevatorSimulator.Screens.Ui
{
    enum Orientation
    {
        Horizontal,
        Vertical
    }

    class ComponentList : Container
    {
        public int Padding { get; set; }
        public Orientation Orientation { get; set; }

        public ComponentList(Vector2 position, int padding, Orientation orientation, List<IComponent> components) : base(position, components)
        {
            Padding = padding;
            Orientation = orientation;
        }

        public ComponentList(Vector2 position, int padding, Orientation orientation) : this(position, padding, orientation, new List<IComponent>()) { }

        public override Rectangle GetBounds()
        {
            Rectangle bounds = new Rectangle();
            components.ForEach((c) =>
            {
                Rectangle cb = c.GetBounds();
                if (cb.Width > bounds.Width) bounds.Width = cb.Width;
                bounds.Height += cb.Height;
                if (c != components.Last()) bounds.Height += Padding;
            });
            return bounds;
        }

        public override void AddComponent(IComponent component)
        {
            int padding = (components.Count() == 0) ? 0 : Padding;
            if (Orientation == Orientation.Horizontal)
            {
                component.Position = new Vector2(Position.X + GetBounds().Width + padding, Position.Y);
            }
            else
            {
                component.Position = new Vector2(Position.X, Position.Y + GetBounds().Height + padding);
            }
            base.AddComponent(component);
        }

        // TODO: Create MenuList : List that only accepts buttons and handles keyboard strokes
        // TODO: Add nested VerticalList to MainMenu containing a headline label and a MenuList
    }
}
