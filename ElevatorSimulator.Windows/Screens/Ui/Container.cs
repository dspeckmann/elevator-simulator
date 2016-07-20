using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElevatorSimulator.Screens.Ui
{
    abstract class Container : IComponent
    {
        public Vector2 Position { get; set; }
        protected List<IComponent> components { get; set; }

        public Container(Vector2 position, List<IComponent> components)
        {
            Position = position;
            this.components = components;
        }

        public Container(Vector2 position) : this(position, new List<IComponent>()) { }

        public abstract Rectangle GetBounds();

        public virtual void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public virtual void Update(GameTime gameTime)
        {
            components.ForEach((c) => c.Update(gameTime));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            components.ForEach((c) => c.Draw(spriteBatch));
        }
    }
}
