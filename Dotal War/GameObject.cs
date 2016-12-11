
using Dotal_War.Components;
using Microsoft.Xna.Framework;

namespace Dotal_War
{
    public class GameObject:Bag
    {

        public GameObject(int objectid, Vector2 position)
        {
            
            this.objectid = objectid;
            Position = position;
        }
    }
}
