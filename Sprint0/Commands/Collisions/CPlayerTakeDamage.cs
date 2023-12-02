﻿using Sprint0.Characters;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Commands.Collisions
{
    public class CPlayerTakeDamage : ICommand
    {
        private Sprint0 sprint;
        private IPlayer player;
        private PlayerNumbers p;

        public CPlayerTakeDamage(Sprint0 sprint, IPlayer player)
        {
            this.sprint = sprint;
            this.player = player;
            p = new PlayerNumbers();
        }

        public void Execute()
        {
            System.Diagnostics.Debug.WriteLine("entered command");
            switch (player.health)
            {
                case Characters.Player.PlayerHealth.Normal:
                    {
                        player.health = Characters.Player.PlayerHealth.Dead;
                        player.Die();
                        break;
                    }
                case Characters.Player.PlayerHealth.Big:
                    {
                        System.Diagnostics.Debug.WriteLine(player.number + " becomes damaged");
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                            sprint.levelLoader.mario = damagedPlayer;
                        else if (player.number == p.luigi)
                            sprint.levelLoader.luigi = damagedPlayer;
                        player.ChangeToNormal();
                        break;
                    }
                case Characters.Player.PlayerHealth.Fire:
                    {
                        System.Diagnostics.Debug.WriteLine(player.number + " becomes damaged");
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                            sprint.levelLoader.mario = damagedPlayer;
                        else if (player.number == p.luigi)
                            sprint.levelLoader.luigi = damagedPlayer;
                        player.ChangeToBig();
                        break;
                    }
                case Characters.Player.PlayerHealth.Raccoon:
                    {
                        System.Diagnostics.Debug.WriteLine(player.number + " becomes damaged");
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                            sprint.levelLoader.mario = damagedPlayer;
                        else if (player.number == p.luigi)
                            sprint.levelLoader.luigi = damagedPlayer;
                        player.ChangeToBig();
                        break;
                    }
            }
        }

    }
}
