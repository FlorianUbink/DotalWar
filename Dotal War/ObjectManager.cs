using Dotal_War.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Collections
{
    public class ObjectManager
    {
        public Dictionary<int, GameObject> objectDictionary;
        int nextid = 0;

        public ObjectManager()
        {
            objectDictionary = new Dictionary<int, GameObject>();
        }

        public void CleanUp(ComponentManager components)
        {
            if (objectDictionary.Count != 0)
            {
                bool updateLoop = true;

                while (updateLoop)
                {
                    updateLoop = false;
                    foreach (GameObject update in objectDictionary.Values)
                    {
                        if (update.Alive == false)
                        {
                            updateLoop = true;
                            components.RemoveComponents(update);
                            objectDictionary.Remove(update.Objectid);
                            break;
                        }
                    }
                }
            }


        }

        public int AddObject(int AccessID, bool alive, Vector2 position)
        {
            nextid += 1;
            objectDictionary.Add(nextid, new GameObject(nextid,AccessID, alive, position));
            return nextid;
        }

        public void RemoveObject(int objectid)
        {
            objectDictionary.Remove(objectid);
        }
    }
}
