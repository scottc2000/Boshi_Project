using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sprint0.Collision
{

    public class CollisionDictionraryRegister
    {
        public Sprint0 sprint;
        public enum Side { None, Left, Right, Top, Bottom, Horizontal, Vertical, Dont_Care };

        //New collision handler dictionary
        public Dictionary<(ICollidable.collideAs, ICollidable.collideAs, Side), (ConstructorInfo, ConstructorInfo)> collision;


        public CollisionDictionraryRegister()
        {
            collision = new Dictionary<(ICollidable.collideAs, ICollidable.collideAs, Side), (ConstructorInfo, ConstructorInfo)>();
        }

        public void generate()
        {
            Type[] typeArray = { typeof(ICollidable), typeof(ICollidable), typeof(CollisionData) };
            //(icollidable, icollidable, side), (constructorinfo, constructorinfo))
            //GetConstructor elements of an array
            //initialize an array of 3 things
            collision.Add((ICollidable.collideAs.player, ICollidable.collideAs.player, Side.Horizontal), 
                (Type.GetType("CMarioStuckX").GetConstructor(typeArray),
                Type.GetType("CMarioStuckX").GetConstructor(typeArray)));

            collision.Add((ICollidable.collideAs.player, ICollidable.collideAs.player, Side.Vertical),
                (Type.GetType("CMarioStuckY").GetConstructor(typeArray),
                Type.GetType("CMarioStuckY").GetConstructor(typeArray)));

            collision.Add((ICollidable.collideAs.player, ICollidable.collideAs.block, Side.Bottom),
                (Type.GetType("").GetConstructor(typeArray),
                Type.GetType("").GetConstructor(typeArray)));

            collision.Add((ICollidable.collideAs.player, ICollidable.collideAs.item, Side.Dont_Care),
                (Type.GetType("CPowerUp").GetConstructor(typeArray),
                Type.GetType("CPowerUp").GetConstructor(typeArray)));

            collision.Add((ICollidable.collideAs.item, ICollidable.collideAs.block, Side.Horizontal),
                (Type.GetType("").GetConstructor(typeArray),
                Type.GetType("").GetConstructor(typeArray)));


        }
    }
}