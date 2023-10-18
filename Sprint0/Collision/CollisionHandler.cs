﻿using Sprint0.Interfaces;
using Sprint0.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision
{
    internal class CollisionHandler
    {
        List<ICharacter> Players;
        List<IEnemies> Enemies;
        List<Item> Items;
        List<IBlock> Blocks;

        public CollisionHandler()
        {
            Players = new List<ICharacter>();
            Enemies = new List<IEnemies>();
            Items = new List<Item>();
            Blocks = new List<IBlock>();
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
