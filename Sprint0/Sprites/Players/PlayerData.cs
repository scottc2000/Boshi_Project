﻿using System.Collections.Generic;

namespace Sprint0.Sprites.Players
{
    public class PlayerData
    {
        public class Big
        {
            public List<Sprite> Sprites { get; set; }
        }

        public class Fire
        {
            public List<Sprite> Sprites { get; set; }
        }

        public class Luigi
        {
            public Normal Normal { get; set; }
            public Big Big { get; set; }
            public Fire Fire { get; set; }
            public Raccoon Raccoon { get; set; }
        }

        public class Mario
        {
            public Dead Dead { get; set; }
            public Normal Normal { get; set; }
            public Big Big { get; set; }
            public Fire Fire { get; set; }
            public Raccoon Raccoon { get; set; }
        }
        public class Dead
        {
            public List<Sprite> Sprites { get; set; }
        }
        public class Normal
        {
            public List<Sprite> Sprites { get; set; }
        }

        public class Raccoon
        {
            public List<Sprite> Sprites { get; set; }
        }

        public class Root
        {
            public Luigi luigi { get; set; }
            public Mario mario { get; set; }
        }

        public class Sprite
        {
            public string name { get; set; }
            public List<List<int>> spritesheet_pos { get; set; }
            public List<int> hitbox { get; set; }
            public bool facingLeft { get; set; }
            public bool looping { get; set; }
        }
    }

}