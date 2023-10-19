using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Sprint0.Sprites.PlayerData;

namespace Sprint0.Sprites.SpriteFactories
{
    public class CharacterSpriteFactoryLuigi
    {
        private Characters.Luigi luigi;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private SpriteEffects effect;
        private JsonElement playerData;
        private Root deserializedPlayerData;

        AnimatedSpriteLuigi generatedCharacter;

        public CharacterSpriteFactoryLuigi(Characters.Luigi luigi)
        {
            this.luigi = luigi;

            // opens file that contains sprite information and deserializes it
            StreamReader r = new StreamReader("playerdata.json");
            string playerdatajson = r.ReadToEnd();

            deserializedPlayerData = JsonSerializer.Deserialize<Root>(playerdatajson);


        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

        }

        public Rectangle[] generateSprites(List<List<int>> sheetpos, List<int> hitbox)
        {
            // genereates list of sprite rectangles from the json locations
            Rectangle[] myRect = new Rectangle[sheetpos.Count];

            for (int i = 0; i < sheetpos.Count; i++)
            {
                myRect[i] = new Rectangle(sheetpos[i][0], sheetpos[i][1], hitbox[0], hitbox[1]);

            }
            return myRect;
        }

        public AnimatedSpriteLuigi returnSprite(string spriteType)
        {

            string spriteName = "X";

            // goes through json for sprites (depending on which form), returns animated luigi sprite
            switch (luigi.health)
            {
                case Characters.Luigi.LuigiHealth.Big:
                    foreach (Sprite n in deserializedPlayerData.luigi.Big.Sprites)
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

                case Characters.Luigi.LuigiHealth.Normal:
                    foreach (Sprite n in deserializedPlayerData.luigi.Normal.Sprites)
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

                case Characters.Luigi.LuigiHealth.Fire:
                    foreach (Sprite n in deserializedPlayerData.luigi.Fire.Sprites)
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

                case Characters.Luigi.LuigiHealth.Raccoon:
                    foreach (Sprite n in deserializedPlayerData.luigi.Raccoon.Sprites)
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

            return new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect, spriteName);
        }
    }

}
