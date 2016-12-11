using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Managers
{
    public class ObjectManager
    {
        public List<GameObject> objectList;
        GameObject search;
        int nextID;

        public ObjectManager()
        {
            objectList = new List<GameObject>();
            nextID = 0;
        }

        public void NewObject(Vector2 position)
        {
            int id = getID();
            objectList.Add(new GameObject(id, position));
        }

        public void RemoveObject(int objectid)
        {
            foreach (GameObject gameObject in objectList)
            {
                if (gameObject.objectid == objectid)
                {
                    objectList.Remove(gameObject);
                }
            }
        }

        public GameObject getObject(int objectid)
        {
            search = null;

            foreach (GameObject subject in objectList)
            {
                if (subject.objectid == objectid)
                {
                    search = subject;
                }

            }

            return search;

        }

        private int getID()
        {
            nextID += 1;
            return nextID;
        }


    }
}
