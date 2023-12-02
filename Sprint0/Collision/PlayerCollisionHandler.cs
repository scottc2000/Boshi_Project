using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Commands.Player;
using Sprint0.Enemies;
using Sprint0.Interfaces;
using System;
using System.Diagnostics;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class PlayerCollisionHandler
    {
        private Sprint0 sprint;
        public enum staticBlocks { Floor, Clouds, LargeBlock, Pipe, WoodBlocks }
        public enum dynamicBlocks { YellowBrick, QuestionBlock, SpinningCoin }
        public PlayerCollisionHandler(Sprint0 sprint) 
        {
            this.sprint = sprint;
        }

        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side, Vert vert, Rectangle hitarea)
        {
            // Static and Player
            if (entity2.GetType() == typeof(IPlayer) || Enum.IsDefined(typeof(staticBlocks), entity1.GetType().Name))
                PlayerStaticBlockCollision(entity2, entity1, side, vert, hitarea);

            else if (entity1.GetType() == typeof(IPlayer) || Enum.IsDefined(typeof(staticBlocks), entity2.GetType().Name))
                PlayerStaticBlockCollision(entity1, entity2, side, vert, hitarea);

            // Dynamic and Player
            else if (entity2.GetType() == typeof(IPlayer) || Enum.IsDefined(typeof(dynamicBlocks), entity1.GetType().Name))
                PlayerDynamicBlockCollision(entity2, entity1, side, vert, hitarea);

            else if (entity1.GetType() == typeof(IPlayer) || Enum.IsDefined(typeof(dynamicBlocks), entity2.GetType().Name))
                PlayerDynamicBlockCollision(entity1, entity2, side, vert, hitarea);

            // Item and Player
            else if (entity1.GetType() == typeof(IPlayer) || entity2.GetType() == typeof(IItem))
                PlayerItemCollision(entity1, entity2, side);

            else if (entity2.GetType() == typeof(IPlayer) || entity1.GetType() == typeof(IItem))
                PlayerItemCollision(entity2, entity1, side);

            // Enemy and Player
            else if (entity1.GetType() == typeof(IPlayer) || entity2.GetType() == typeof(IEnemies))
                PlayerEnemyCollision(entity1, entity2, side);

            else if (entity2.GetType() == typeof(IPlayer) || entity1.GetType() == typeof(IEnemies))
                PlayerEnemyCollision(entity2, entity1, side);
        }
        public void PlayerStaticBlockCollision(ICollidable player, ICollidable block, Side side, Vert vert, Rectangle hitarea)
        {
            // need to redo deathzone collision - caused issues

            if (side == Side.Horizontal)
            {
                ICollidableCommand collidableCommand = new CPlayerStuckX(sprint, (IPlayer)player);
                collidableCommand.Execute(hitarea);
            }
            else if (side == Side.Vertical)
            {
                ICollidableCommand collidableCommand = new CPlayerStuckTopY(sprint, (IPlayer)player);
                if (vert == Vert.Bottom) collidableCommand = new CPlayerStuckBottomY(sprint, (IPlayer) player);
                if (vert == Vert.Both) collidableCommand = new CPlayerStuckBothY(sprint, (IPlayer) player);
                collidableCommand.Execute(hitarea);
            }
        }

        public void PlayerDynamicBlockCollision(ICollidable player, ICollidable block, Side side, Vert vert, Rectangle hitarea)
        {
            if (block is SpinningCoin)
            {
                CGetCoin command = new CGetCoin(sprint);
                command.Execute((IBlock)block);
            }
            
            if (side == Side.Horizontal)
            {
                ICollidableCommand command = new CPlayerStuckX(sprint, (IPlayer)player);
                command.Execute(hitarea);
            }
            else if (side == Side.Vertical)
            {
                ICollidableCommand command = new CPlayerStuckTopY(sprint, (IPlayer)player);
                if (vert == Vert.Bottom) command = new CPlayerStuckBottomY(sprint, (IPlayer)player);
                if (vert == Vert.Both) command = new CPlayerStuckBothY(sprint, (IPlayer)player);
                command.Execute(hitarea);

                if (block is QuestionBlock)
                {
                    CQuestionBump command2 = new CQuestionBump(sprint, (IPlayer)player);
                    command2.Execute(hitarea, (IBlock)block);
                    
                }
                else if (block is YellowBrick)
                {
                    // insert logic
                }
            }
        }

        public void PlayerCollision(ICollidable player1, ICollidable player2, Side side, Rectangle hitarea)
        {
            if (side == Side.Horizontal)
            {
                ICollidableCommand command1 = new CPlayerStuckX(sprint, (IPlayer)player1);
                command1.Execute(hitarea);
                ICollidableCommand command2 = new CPlayerStuckX(sprint, (IPlayer)player2);
                command2.Execute(hitarea);
            }
        }

        public void PlayerItemCollision(ICollidable player, ICollidable item, Side side)
        {
            ICommand command1;
            ICommand command2;
            
            command1 = new CPlayerPowerUp(sprint, (IItem)item, (IPlayer)player);
            command2 = new CItemDisappear(sprint, (IItem)item);

            command1.Execute();
            command2.Execute();
        }

        public void PlayerEnemyCollision(ICollidable player, ICollidable enemy, Side side)
        {
            if (side == Side.Horizontal)
            {
                ICommand command = new CPlayerTakeDamage(sprint, (IPlayer) player);
                command.Execute();
            }
            if (side == Side.Vertical && enemy is Goomba)
            {
                ICommand command = new CGoombaStomp(sprint);
                command.Execute();
            }
            if (side == Side.Vertical && enemy is Koopa)
            {
                ICommand command = new CKoopaStomp(sprint);
                command.Execute();
            }
        }
    }
}
