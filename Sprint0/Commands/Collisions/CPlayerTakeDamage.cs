using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Interfaces;
using Sprint0.Utility;
using System;

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
                        player.position = new Vector2(player.position.X, player.position.Y - 100);
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader, sprint);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                        {
                            sprint.levelLoader.mario = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        else if (player.number == p.luigi)
                        {
                            sprint.levelLoader.luigi = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        sprint.hud.DecrementLives();
                        break;
                    }
                case Characters.Player.PlayerHealth.Big:
                    {
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader, sprint);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                        { 
                            sprint.levelLoader.mario = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        else if (player.number == p.luigi)
                        { 
                            sprint.levelLoader.luigi = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        player.ChangeToNormal();
                        break;
                    }
                case Characters.Player.PlayerHealth.Fire:
                    {
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader, sprint);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                        {
                            sprint.levelLoader.mario = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        else if (player.number == p.luigi)
                        {
                            sprint.levelLoader.luigi = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        player.ChangeToBig();
                        break;
                    }
                case Characters.Player.PlayerHealth.Raccoon:
                    {
                        IPlayer damagedPlayer = new DamagedPlayer(player, sprint.levelLoader, sprint);
                        damagedPlayer.isInvinsible = true; // Set Mario as invincible
                        if (player.number == p.mario)
                        {
                            sprint.levelLoader.mario = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        else if (player.number == p.luigi)
                        {
                            sprint.levelLoader.luigi = damagedPlayer;
                            ICommand remove = new CRemoveDynamic(player, sprint.objects);
                            remove.Execute();
                        }
                        player.ChangeToBig();
                        break;
                    }
            }
        }

    }
}
