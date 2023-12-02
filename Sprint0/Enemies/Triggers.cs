using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemies
{
    public class Triggers
    {
        public Sprint0 mySprint;
        private int swarmTrigger = 600;
        private int bowserTrigger;

        public List<IEnemies> enemies;

        public Triggers(Sprint0 sprint) 
        { 
            this.mySprint = sprint;
            enemies = mySprint.objects.Enemies;
        }

        public bool swarmCheck()
        {
            if (mySprint.levelLoader.mario.position.X > 600)
                return true;

            return false;
        }

        public void Detect()
        {
            if (swarmCheck())
            {
                foreach (IEnemies enemy in enemies)
                {
                    if(enemy is Goomba)
                    {
                        enemy.StartSwarm();
                    }
                }
            }

        }
    }
}
