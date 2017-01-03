using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public enum selectType
    {
        Movable,
        NonMovable
    }

    public class Perception
    {
        List<GameObject> subscribers;

        public Perception()
        {
            subscribers = new List<GameObject>();
        }

        public void Add(GameObject subject, selectType type)
        {
            subscribers.Add(subject);
            subject.SelectType = type;
        }

        public void RunSystem(SelectionRectange selection)
        {
            foreach (GameObject update in subscribers)
            {
                if (selection.selectRectangle.Contains(update.Position))
                {
                    update.Selected = true;
                }

                else if (!selection.lockedSelection)
                {
                    update.Selected = false;
                }
            }
        }
    }
}
