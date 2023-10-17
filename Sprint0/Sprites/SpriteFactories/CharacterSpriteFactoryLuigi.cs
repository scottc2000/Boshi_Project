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


namespace Sprint0.Sprites.SpriteFactories
{
    public class CharacterSpriteFactoryLuigi
    {
        private Luigi luigi;
        private Dictionary<string, AnimatedSpriteLuigi> statesAndSprites;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private string spriteType;
        private SpriteEffects effect;

        AnimatedSpriteLuigi generatedCharacter;

        public CharacterSpriteFactoryLuigi(Luigi luigi)
        {
            statesAndSprites = new Dictionary<string, AnimatedSpriteLuigi>();
            this.luigi = luigi;

        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

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
            statesAndSprites.Add("RaccoonLuigiJumpRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(77, 436, 24, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonLuigiCrouchLeft", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));

            // Luigi Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonLuigiCrouchRight", new AnimatedSpriteLuigi(currentFrames, texture, luigi, effect));



        }
        public AnimatedSpriteLuigi returnSprite(string spriteType)
        {

            generatedCharacter = statesAndSprites[spriteType];
            generatedCharacter.spriteName = spriteType;
            return generatedCharacter;
        }
    }

}
