using Dotal_War.Managers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Components
{
    public class Combat
    {
        List<GameObject> subscribers;

        public Combat()
        {
            subscribers = new List<GameObject>();
        }

        public void Add(GameObject subject, float MaxHealth, float Dammage, float AttackSpeed, float AttackRange, bool Attackable, bool canAttack)
        {
            subject.defense_health = MaxHealth;
            subject.attack_dammage = Dammage;
            subject.attack_speed = AttackSpeed;
            subject.attack_range = AttackRange;
            subject.AttackAble = Attackable;
            subject.canAttack = canAttack;
            subject.remainingDelay = 0f;
            subscribers.Add(subject);
        }

        public void Remove(GameObject removeObject)
        {
            if (subscribers.Contains(removeObject))
            {
                subscribers.Remove(removeObject);
            }
        }

        public void RunSystem(DammageDistribution dmgDist, GameTime gameTime)
        {
            foreach(GameObject update in subscribers)
            {
                float receivedTotal = dmgDist.Receive(update.Objectid);
                
                update.defense_health -= receivedTotal;

                if (update.defense_health <= 0)
                {
                    update.Alive = false;
                }

                else if(update.Alive)
                {
                    float timer = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    update.remainingDelay -= timer;

                    if (update.remainingDelay <= 0)
                    {
                        dmgDist.Send(update.EnemyID, update.attack_dammage);
                        update.remainingDelay = 1000/update.attack_speed;
                        update.EnemyID = -1;
                    }
                }


            }
        }
    }
}
