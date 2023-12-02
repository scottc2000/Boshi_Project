﻿using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;
using Sprint0.Utility;
using Sprint0.HUD;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    public class CEnemyStomp : ICommand
    {
        private Sprint0 sprint;
        private Goomba goomba;
        private HudNumbers numbers;
        private GameStats stats;
        private IEnemies enemy;
        ObjectManager objectManager;

        public CEnemyStomp(Sprint0 sprint, IEnemies Enemy)
        {
            this.sprint = sprint;
            this.enemy = Enemy;
            stats = sprint.hud;
            numbers = new HudNumbers();
            objectManager = sprint.objects;
        }

        public void Execute()
        {
            stats.IncreaseScore(numbers.enemyPoints);
            enemy.BeStomped();
            if (!(enemy is Bowser))
            {
                objectManager.RemoveFromList(enemy);
            } else
            {
                
            }
        }

    }
}
