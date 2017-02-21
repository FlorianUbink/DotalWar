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

        public void Remove(GameObject removeObject)
        {
            if (subscribers.Contains(removeObject))
            {
                subscribers.Remove(removeObject);
            }
        }

        public void RunSystem(SelectionRectange selection, ObjectManager objectManager)
        {
            foreach (GameObject update in subscribers)
            {
                update.Selected = Selection(update, selection);
                update.ThresholdObjects = ThresholdObjects(update, objectManager);
                update.EnemyID = ClosestTarget(update, objectManager);
            }
        }

        #region Functionality

        private bool Selection(GameObject update, SelectionRectange selection)
        {
            if (selection.selectRectangle.Contains(update.Position) && update.AccessID == selection.AccessID)
            {
                return true;
            }

            else if (!selection.lockedSelection && update.AccessID == selection.AccessID)
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

        private int ClosestTarget(GameObject update, ObjectManager objectManager)
        {
            int closestID = -1;
            // check if update is able to attack
            if (update.canAttack && update.Alive )
            {
                float shortestDistance = -1;
                bool first = true;
                // iterate over every other object
                foreach (GameObject subject in objectManager.objectDictionary.Values)
                {
                    // check if subjects are alive, attackable and from the other team
                    if (subject.Alive && subject.AttackAble && subject.AccessID != update.AccessID)
                    {
                        float distance = Vector2.Distance(update.Position, subject.Position);
                        // check if the distance is good for attack option
                        if (distance <= update.attack_range)
                        {
                            // find out which target is closest, thats your new target
                            if (first)
                            {
                                shortestDistance = distance;
                                closestID = subject.Objectid;
                                first = false;
                            }

                            else if (distance < shortestDistance)
                            {
                                shortestDistance = distance;
                                closestID = subject.Objectid;
                            }
                        }
                    }
                }
            }

            return closestID;
        }

        #endregion
    }
}
