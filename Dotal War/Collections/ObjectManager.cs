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

        public int AddObject(Vector2 position)
        {
            nextid += 1;
            objectDictionary.Add(nextid, new GameObject(nextid, position));
            return nextid;
        }

        public void RemoveObject(int objectid)
        {
            objectDictionary.Remove(objectid);
        }
    }
}
