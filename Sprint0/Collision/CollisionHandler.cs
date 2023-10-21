﻿using Sprint0.Interfaces;
using Sprint0.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{
    public class CollisionHandler
    {
        List<ICharacter> Players;
        List<IEnemies> Enemies;
        List<Item> Items;
        List<IBlock> Blocks;
        CollisionDictionraryRegister register;
        Sprint0 sprint;

        public CollisionHandler(Sprint0 sprint)
        {
            Players = new List<ICharacter>();
            Enemies = new List<IEnemies>();
            Items = new List<Item>();
            Blocks = new List<IBlock>();
            this.sprint = sprint;
            register = new CollisionDictionraryRegister(sprint);
            
            Players.Add(sprint.mario);
            Players.Add(sprint.luigi);
            register.generate();
        }

        public void Update()
        {
            foreach (ICharacter character in Players)
            {
                foreach (IEnemies enemeny in Enemies)
                {
                    //if (character.hitbox)
                }

                foreach (Item item in Items)
                {
                    //if (character.hitbox)
                }

                foreach (IBlock block in Blocks)
                {
                    //if (character.hitbox)
                }

           
                foreach (ICharacter character1 in Players)
                {
                    if (character.destination.Intersects(character1.destination) && !(character.Equals(character1))) {

                        register.collisions.commandDictionary[new Tuple<ICollidable, ICollidable, CollisionDictionary.Side>(character, character1, CollisionDictionary.Side.Left)].Item1.Execute();
                        register.collisions.commandDictionary[new Tuple<ICollidable, ICollidable, CollisionDictionary.Side>(character, character1, CollisionDictionary.Side.Left)].Item2.Execute();
                        Console.WriteLine("HIT");
                    }
                }

            }

            foreach (IBlock block in Blocks)
            {
                foreach (IEnemies enemeny in Enemies)
                {
                    //if (character.hitbox)
                }

                foreach (Item item in Items)
                {
                    //if (character.hitbox)
                }

            }
        }
    }
}