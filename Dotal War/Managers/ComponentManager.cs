using Dotal_War.Collections;
using Dotal_War.Components;
using Microsoft.Xna.Framework;

namespace Dotal_War.Managers
{
    public class ComponentManager
    {
        public Graphics graphics { get; set; }
        public Perception perception { get; set; }
        public Kinematic kinematic { get; set; }
        public Behaviour behaviour { get; set; }
        public Combat combat { get; set; }

        public ComponentManager(Game1 game)
        {
            graphics = new Graphics(game.Content);
            perception = new Perception();
            kinematic = new Kinematic();
            behaviour = new Behaviour();
            combat = new Combat();
        }

        public void RemoveComponents(GameObject removeObject)
        {
            perception.Remove(removeObject);
            behaviour.Remove(removeObject);
            kinematic.Remove(removeObject);
            combat.Remove(removeObject);
            graphics.Remove(removeObject);
        }

        public void RunSystems(GameTime gameTime, SelectionRectange selection, ObjectManager objectManager, DammageDistribution dmgDist)
        {
            perception.RunSystem(selection, objectManager);
            behaviour.RunSystem();
            kinematic.RunSystem(gameTime);
            combat.RunSystem(dmgDist, gameTime);
        }

    }
}
