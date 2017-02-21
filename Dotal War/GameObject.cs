
using Dotal_War.Components;
using Microsoft.Xna.Framework;

namespace Dotal_War
{
    public class GameObject:Bag
    {
        public GameObject(int objectid,int AccessID, bool alive ,Vector2 position)
        {
            Objectid = objectid;
            Alive = alive;
            this.AccessID = AccessID;
            Position = position;
        }
    }
}
