using Dotal_War.Collections;
using Dotal_War.Components;
using Dotal_War.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War
{
    public class Player
    {
        ObjectManager objectManager;
        ComponentManager componentManager;
        int objectID;
        public int PlayerID { get;}

        public Player(Game1 game, int playerID)
        {
            PlayerID = playerID;
            objectManager = game.objectManager;
            componentManager = game.componentManager;
        }

        public void Add(Vector2 position)
        {
            objectID = objectManager.AddObject(PlayerID, true,position);
            componentManager.perception.Add(objectManager.objectDictionary[objectID], selectType.Movable);
            componentManager.behaviour.Add(objectManager.objectDictionary[objectID], 0f, 30f);
            componentManager.kinematic.Add(objectManager.objectDictionary[objectID], 50f, 25f);
            componentManager.combat.Add(objectManager.objectDictionary[objectID], 100f, 15f, 0.72f, 30f, true, true);
            componentManager.graphics.Add(objectManager.objectDictionary[objectID], componentManager.graphics.Unit0, Color.White);
        }
    }
}
