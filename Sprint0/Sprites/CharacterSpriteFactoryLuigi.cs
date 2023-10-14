using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System.Text.Json;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using static Sprint0.Sprites.PlayerData;

namespace Sprint0.Sprites
{
    public class CharacterSpriteFactoryLuigi
    {
        private Characters.Luigi luigi;
        private Dictionary<String, AnimatedSpriteLuigi> statesAndSprites;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private String spriteType;
        private SpriteEffects effect;
        private JsonElement playerData;
        private dynamic array;
        private Root deserializedPlayerData;

        AnimatedSpriteLuigi generatedCharacter;

        public CharacterSpriteFactoryLuigi(Characters.Luigi luigi)
        {
            statesAndSprites = new Dictionary<String, AnimatedSpriteLuigi>();
            this.luigi = luigi;

            StreamReader r = new StreamReader("playerdata.json");
            string playerdatajson = r.ReadToEnd();

            deserializedPlayerData = JsonSerializer.Deserialize<Root>(playerdatajson);


        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

            /*
            // Normal Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiStillLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiStillRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17), new Rectangle(19, 51, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiMoveLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiMoveRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(37, 52, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiJumpLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiJumpRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiCrouchLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiCrouchRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));


            // Big Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 179, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiStillLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiStillRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(19, 178, 17, 28), new Rectangle(37, 178, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiMoveLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiMoveRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(73, 178, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiJumpLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiJumpRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(55, 180, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiCrouchLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiCrouchRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));



            // Fire Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 265, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiStillLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiStillRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(19, 264, 17, 28), new Rectangle(37, 264, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiMoveLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiMoveRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(73, 264, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiJumpLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiJumpRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(55, 265, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiCrouchLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiCrouchRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Throw Left.
            currentFrames = new Rectangle[] { new Rectangle(209, 298, 17, 28), new Rectangle(227, 298, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiThrowLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Throw Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiThrowRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));


            // Raccoon Luigi States

            // Luigi Still Left
            currentFrames = new Rectangle[] { new Rectangle(1, 436, 22, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonLuigiStillLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Still Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonLuigiStillRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Left
            currentFrames = new Rectangle[] { new Rectangle(1, 436, 22, 28), new Rectangle(25, 436, 22, 28), new Rectangle(52, 436, 22, 28), new Rectangle(25, 436, 22, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonLuigiMoveLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Move Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonLuigiMoveRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Left
            currentFrames = new Rectangle[] { new Rectangle(103, 436, 28, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonLuigiJumpLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Jump Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonLuigiJumpRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect)) ;

            // Luigi Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(77, 436, 24, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonLuigiCrouchLeft", new AnimatedSpriteLuigi(currentFrames, texture,luigi, effect));

            // Luigi Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonLuigiCrouchRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            */

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

        public AnimatedSpriteLuigi returnSprite(String spriteType)
        {

            //generatedCharacter = statesAndSprites[spriteType];
            //generatedCharacter.spriteName = spriteType;
            string spriteName = "X";

            switch (luigi.health)
            {
                case (Characters.Luigi.LuigiHealth.Big):
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

                case (Characters.Luigi.LuigiHealth.Normal):
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

                case (Characters.Luigi.LuigiHealth.Fire):
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

                case (Characters.Luigi.LuigiHealth.Raccoon):
                    foreach (Sprite n in deserializedPlayerData.luigi.Racoon.Sprites)
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
