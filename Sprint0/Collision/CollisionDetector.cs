﻿using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System.Collections.Generic;
using static Sprint0.Collision.CollisionDetector;

namespace Sprint0.Collision
{
    public class CollisionDetector
    {
        private Sprint0 sprint;
        private List<ICollidable> DynamicEntities;
        private List<ICollidable> StaticEntities;
        private ObjectManager objects;

        private MarioCollisionHandler marioCollisionHandler;
        private LuigiCollisionHandler luigiCollisionHandler;
        private ItemCollisionHandler itemCollisionHandler;

        public enum Side { None, Vertical, Horizontal }

        public CollisionDetector(Sprint0 sprint, ObjectManager objects)
        {
            this.sprint = sprint;
            this.objects = objects;
            DynamicEntities = objects.DynamicEntities;
            StaticEntities = objects.StaticEntites;

            marioCollisionHandler = new MarioCollisionHandler(sprint);
            luigiCollisionHandler = new LuigiCollisionHandler(sprint);
            itemCollisionHandler = new ItemCollisionHandler(sprint);
        }

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
                        Side side = CollisionSide(dynamic1, dynamic2);
                        HandleCollision(dynamic1, dynamic2, side);
                    }
                }
                foreach(ICollidable static1 in StaticEntities)
                {
                    if (dynamic1.Destination.Intersects(static1.Destination))
                    {
                        Side side = StaticCollisionSide(dynamic1, static1);
                        HandleCollision(dynamic1, static1, side);
                    }
                }
            }
        }

        public Side CollisionSide(ICollidable entity1, ICollidable entity2)
        {
            Rectangle box = Rectangle.Intersect(entity2.Destination, entity1.Destination);
            // These checks may need to be updated
            if (!(box.Width >= box.Height))
            {
                return Side.Horizontal;
            }
            else if (box.Width >= box.Height)
            {
                return Side.Vertical;
            }
            return Side.None;
        }
        public Side StaticCollisionSide(ICollidable entity1, ICollidable entity2)
        {
            Side side = Side.None;
            if (objects.SideCollidableBlocks.Contains((IBlock)entity2))
            {
                side = Side.Horizontal;
            }
            if (objects.TopCollidableBlocks.Contains((IBlock)entity2) || objects.BottomCollidableBlocks.Contains((IBlock)entity2))
            {
                side =  Side.Vertical;
            }
            return side;
        }
        public void HandleCollision(ICollidable entity1, ICollidable entity2, Side side)
        {
            /*________ Mario Collisions _______ */
            if(entity1 is Mario && entity2 is Luigi)
            {
                marioCollisionHandler.PlayerCollision(entity1, entity2, side);
            }

            if (entity1 is Mario && (entity2 is Floor || entity2 is Clouds || entity2 is LargeBlock || entity2 is Pipe || entity2 is WoodBlocks || entity2 is YellowBrick))
            {
                marioCollisionHandler.MarioStaticBlockCollision(entity1, entity2, side);
            }

            if (entity1 is Mario && (entity2 is IItem))
            {
                marioCollisionHandler.MarioItemCollision(entity1, entity2, side);
            }

            /*________ Luigi Collisions ______*/
            if (entity1 is Luigi && entity2 is Mario)
            {
                marioCollisionHandler.PlayerCollision(entity1, entity2, side);
            }

            if (entity1 is Luigi && (entity2 is Floor || entity2 is Clouds || entity2 is LargeBlock || entity2 is Pipe || entity2 is WoodBlocks || entity2 is YellowBrick))
            {
                luigiCollisionHandler.LuigiStaticBlockCollision(entity1, entity2, side);
            }

            if (entity1 is Luigi && (entity2 is IItem))
            {
                marioCollisionHandler.MarioItemCollision(entity1, entity2, side);
            }

            /*_________ Item Collisions ______*/
            if (entity1 is IItem && (entity2 is Floor || entity2 is Clouds || entity2 is LargeBlock || entity2 is Pipe || entity2 is WoodBlocks || entity2 is YellowBrick))
            {
                itemCollisionHandler.ItemStaticBlockCollision(entity1, entity2, side);
            }

            /*________ Enemey Collisions _____*/
        }
    }
}
