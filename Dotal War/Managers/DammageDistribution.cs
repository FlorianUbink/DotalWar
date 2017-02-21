using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Managers
{
    public class DammageDistribution
    {
        Dictionary<int, float> dammageDictionary;

        public DammageDistribution()
        {
            dammageDictionary = new Dictionary<int, float>();
        }

        public float Receive(int objectID)
        {
            if (dammageDictionary.ContainsKey(objectID))
            {
                float dammage = dammageDictionary[objectID];
                dammageDictionary.Remove(objectID);
                return dammage;
            }

            else
            {
                return 0f;
            }
        }

        public void Send(int receiverID, float dammage)
        {
            if (dammageDictionary.ContainsKey(receiverID))
            {
                dammageDictionary[receiverID] += dammage;
            }

            else
            {
                dammageDictionary.Add(receiverID, dammage);
            }
        }

    }
}
