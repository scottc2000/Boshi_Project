using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Sprites.SpriteFactories
{
    public class CharacterSpriteFactoryMario
    {
        private Characters.Mario mario;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private SpriteEffects effect;
        private JsonElement playerData;
        private Root deserializedPlayerData;

        AnimatedSpriteMario generatedCharacter;
        public CharacterSpriteFactoryMario(Characters.Mario mario)
        {
            this.mario = mario;

            StreamReader r = new StreamReader("JSON/playerdata.json");
            string playerdatajson = r.ReadToEnd();

            deserializedPlayerData = JsonSerializer.Deserialize<Root>(playerdatajson);


        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

        }

        public Rectangle[] generateSprites(List<List<int>> sheetpos, List<int> hitbox)
        {
            Rectangle[] myRect = new Rectangle[sheetpos.Count];

            for (int i = 0; i < sheetpos.Count; i++)
            {
                myRect[i] = new Rectangle(sheetpos[i][0], sheetpos[i][1], hitbox[0], hitbox[1]);

            }
            return myRect;
        }

        public AnimatedSpriteMario returnSprite(string spriteType)
        {

            string spriteName = "X";

            switch (mario.health)
            {
                case Characters.Mario.MarioHealth.Big:
                    foreach (Sprite n in deserializedPlayerData.mario.Big.Sprites)
                    {
                        if (string.Equals(n.name, spriteType))
                        {
                            if (n.facingLeft)
                            {
                                effect = SpriteEffects.None;
                            }

                            else
                            {
                                effect = SpriteEffects.FlipHorizontally;
                            }

                            currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                            spriteName = n.name;
                        }
                    }
                    break;

                case Characters.Mario.MarioHealth.Normal:
                    foreach (Sprite n in deserializedPlayerData.mario.Normal.Sprites)
                    {
                        if (string.Equals(n.name, spriteType))
                        {
                            if (n.facingLeft)
                            {
                                effect = SpriteEffects.None;
                            }

                            else
                            {
                                effect = SpriteEffects.FlipHorizontally;
                            }
                            currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                            spriteName = n.name;
                        }
                    }
                    break;

                case Characters.Mario.MarioHealth.Fire:
                    foreach (Sprite n in deserializedPlayerData.mario.Fire.Sprites)
                    {
                        if (string.Equals(n.name, spriteType))
                        {
                            if (n.facingLeft)
                            {
                                effect = SpriteEffects.None;
                            }

                            else
                            {
                                effect = SpriteEffects.FlipHorizontally;
                            }
                            currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                            spriteName = n.name;
                        }
                    }
                    break;

                case Characters.Mario.MarioHealth.Raccoon:
                    foreach (Sprite n in deserializedPlayerData.mario.Raccoon.Sprites)
                    {
                        if (string.Equals(n.name, spriteType))
                        {
                            if (n.facingLeft)
                            {
                                effect = SpriteEffects.None;
                            }

                            else
                            {
                                effect = SpriteEffects.FlipHorizontally;
                            }
                            currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                            spriteName = n.name;
                        }
                    }
                break;
                case Characters.Mario.MarioHealth.Dead:
                    foreach (Sprite n in deserializedPlayerData.mario.Dead.Sprites)
                    {
                        if (string.Equals(n.name, spriteType))
                        {
                            if (n.facingLeft)
                            {
                                effect = SpriteEffects.None;
                            } 
                            else
                            {
                                effect = SpriteEffects.FlipHorizontally;
                            }
                            currentFrames = generateSprites(n.spritesheet_pos, n.hitbox);
                            spriteName = n.name;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("NOT FOUND!!!");
                    Environment.Exit(1);
                    break;
            }

            return new AnimatedSpriteMario(currentFrames, texture, mario, effect, spriteName);
        }
    }

}
