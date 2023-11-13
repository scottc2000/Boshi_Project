using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Collision
{
    public class CollisionDetector
    {
        private Sprint0 sprint;
        private List<ICollidable> DynamicEntities;
        private List<ICollidable> StaticEntities;
        private ObjectManager objects;

        private PlayerCollisionHandler playerCollisionHandler;
        private ItemCollisionHandler itemCollisionHandler;
        private EnemyCollisionHandler enemyCollisionHandler;

        public enum Side { None, Vertical, Horizontal}
        public enum Vert { Top, Bottom, Both }
        public CollisionDetector(Sprint0 sprint, ObjectManager objects)
        {
            this.sprint = sprint;
            this.objects = objects;
            DynamicEntities = objects.DynamicEntities;
            StaticEntities = objects.StaticEntities;

            playerCollisionHandler = new PlayerCollisionHandler(sprint);
            itemCollisionHandler = new ItemCollisionHandler(sprint);
            enemyCollisionHandler = new EnemyCollisionHandler(sprint);
        }

        /*--------------------------- Detect Collision -------------------------------*/
        public void DetectCollision() 
        {
            for (int i = 0; i < DynamicEntities.Count; i++)
            {
                ICollidable dynamic1 = DynamicEntities[i];

                for(int j = i + 1; j < DynamicEntities.Count; j++)
                {
                    ICollidable dynamic2 = DynamicEntities[j];
                    if (dynamic1.Destination.Intersects(dynamic2.Destination)) 
                    {
                        Rectangle hitarea = Rectangle.Intersect(dynamic2.Destination, dynamic1.Destination); // optional parameter
                        Side side = CollisionSide(dynamic1, dynamic2);
                        Vert vert = Vert.Top;
                        if (dynamic1 is IBlock) vert = TopOrBottom(dynamic1);
                        if (dynamic2 is IBlock) vert = TopOrBottom(dynamic2);
                        HandleCollision(dynamic1, dynamic2, side, vert,  hitarea);
                    }
                }
                foreach(ICollidable static1 in StaticEntities)
                {
                    if (dynamic1.Destination.Intersects(static1.Destination))
                    {
                        Rectangle hitarea = Rectangle.Intersect(static1.Destination, dynamic1.Destination);
                        Side side = StaticCollisionSide(dynamic1, static1);
                        Vert vert = TopOrBottom(static1);
                        HandleCollision(dynamic1, static1, side, vert, hitarea);
                    }
                }
            }
        }

        /*----------------------- Determine Side ----------------------------------*/
        public Side CollisionSide(ICollidable entity1, ICollidable entity2)
        {
            Rectangle box = Rectangle.Intersect(entity2.Destination, entity1.Destination);
            Side side = Side.None;

            if (!(box.Width >= box.Height))
                side = Side.Horizontal;
            else if (box.Width >= box.Height)
                side = Side.Vertical;

            return side;
        }

        public Side StaticCollisionSide(ICollidable entity1, ICollidable entity2)
        {
            Side side = Side.None;
            Rectangle box = Rectangle.Intersect(entity2.Destination, entity1.Destination);
            if (objects.SideCollidableBlocks.Contains((IBlock)entity2))
            {
                side = Side.Horizontal;
            }

            if (objects.TopCollidableBlocks.Contains((IBlock)entity2) || objects.BottomCollidableBlocks.Contains((IBlock)entity2))
            {
                if (side == Side.Horizontal)
                {
                    if (!(box.Width >= box.Height))
                        side = Side.Horizontal;
                    else if (box.Width >= box.Height)
                        side = Side.Vertical;
                }
                else
                {
                    side = Side.Vertical;
                }
            }
            return side;

        }

        public Vert TopOrBottom(ICollidable entity2)
        {
            Vert vert = Vert.Top;
            if (objects.TopCollidableBlocks.Contains((IBlock)entity2))
            {
                if (objects.BottomCollidableBlocks.Contains((IBlock)entity2))
                {
                    vert = Vert.Both;
                }
                else
                {
                    vert = Vert.Top;
                }
                
            }
            else if (objects.BottomCollidableBlocks.Contains((IBlock)entity2))
            {
                vert = Vert.Bottom;
            }
            return vert;
        }


        /*------------------------ Handle Collision ------------------------------*/
        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side, Vert vert, Rectangle hitarea)
        {

            /*________ Player Collisions ______*/
            if (entity1 is Player || entity2 is Player)
            {
                System.Diagnostics.Debug.WriteLine("enter player collision");
                playerCollisionHandler.HandleCollision(entity1, entity2, side, vert, hitarea);
            }

            /*_________ Item Collisions ______*/
            if (entity1 is IItem || entity2 is IItem)
                itemCollisionHandler.HandleCollision(entity1, entity2, side, hitarea);


            /*________ Enemey Collisions _____*/    
            if (entity1 is IEnemies || entity2 is IEnemies)
                enemyCollisionHandler.HandleCollision(entity1, entity2, side, hitarea);

        }
    }
}
