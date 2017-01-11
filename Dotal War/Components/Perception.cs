using Dotal_War.Collections;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
            subject.ThresholdObjects = new List<Vector2>();
        }

        public void RunSystem(SelectionRectange selection, ObjectManager objectManager)
        {
            foreach (GameObject update in subscribers)
            {
                update.Selected = Selection(update, selection);
                update.ThresholdObjects = ThresholdObjects(update, objectManager);
            }
        }

        #region Functionality

        private bool Selection(GameObject update, SelectionRectange selection)
        {
            if (selection.selectRectangle.Contains(update.Position))
            {
                return true;
            }

            else if (!selection.lockedSelection)
            {
                return false;
            }

            else
            {
                return update.Selected;
            }
        }

        private List<Vector2> ThresholdObjects(GameObject update, ObjectManager objectManager)
        {
            List<Vector2> objectsinThreshold = new List<Vector2>();

            if(update.SelectType == selectType.Movable)
            {
                foreach(GameObject subjectThreshold in objectManager.objectDictionary.Values)
                {
                    float distance = Vector2.Distance(update.Position, subjectThreshold.Position);

                    if(distance != 0 && distance<update.threshold && subjectThreshold.Velocity.Length() > 0)
                    {
                        objectsinThreshold.Add(subjectThreshold.Position);
                    }
                }

                return objectsinThreshold;
            }

            else
            {
                return null;
            }
        }

        #endregion
    }
}
