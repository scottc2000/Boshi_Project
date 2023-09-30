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


namespace Sprint0.Sprites
{
    public class CharacterSpriteFactory
    {
        private Mario mario;
        private Dictionary<String, AnimatedSprite> statesAndSprites;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private String spriteType;
        private SpriteEffects effect;

        AnimatedSprite generatedCharacter;

        public CharacterSpriteFactory(Mario mario)
        {
            statesAndSprites = new Dictionary<String, AnimatedSprite>();
            this.mario = mario;

        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

            // Normal Mario States

            // Mario Still Left
            currentFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalMarioStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Still Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalMarioStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Left
            currentFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17), new Rectangle(19, 15, 17, 17), new Rectangle(36, 15, 17, 17), new Rectangle(19, 15, 17, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalMarioMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalMarioMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Left
            currentFrames = new Rectangle[] { new Rectangle(72, 15, 17, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalMarioJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalMarioJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalMarioCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalMarioCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));


            // Big Mario States

            // Mario Still Left
            currentFrames = new Rectangle[] { new Rectangle(1, 92, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigMarioStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Still Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigMarioStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Left
            currentFrames = new Rectangle[] { new Rectangle(1, 92, 17, 28), new Rectangle(19, 92, 17, 28), new Rectangle(36, 92, 17, 28), new Rectangle(19, 92, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigMarioMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigMarioMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Left
            currentFrames = new Rectangle[] { new Rectangle(72, 92, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigMarioJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigMarioJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(54, 92, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigMarioCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigMarioCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));



            // Fire Mario States

            // Mario Still Left
            currentFrames = new Rectangle[] { new Rectangle(1, 263, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireMarioStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Still Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireMarioStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Left
            currentFrames = new Rectangle[] { new Rectangle(1, 263, 17, 28), new Rectangle(19, 263, 17, 28), new Rectangle(36, 263, 17, 28), new Rectangle(19, 263, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireMarioMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireMarioMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Left
            currentFrames = new Rectangle[] { new Rectangle(72, 263, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireMarioJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireMarioJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(54, 263, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireMarioCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireMarioCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Throw Left
            currentFrames = new Rectangle[] { new Rectangle(206, 297, 17, 28), new Rectangle(224, 297, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireMarioThrowLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Throw Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireMarioThrowRight", new AnimatedSprite(currentFrames, texture, mario, effect));



            // Raccoon Mario States

            // Mario Still Left
            currentFrames = new Rectangle[] { new Rectangle(1, 350, 22, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonMarioStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Still Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonMarioStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Left
            currentFrames = new Rectangle[] { new Rectangle(1, 350, 22, 28), new Rectangle(25, 350, 22, 28), new Rectangle(52, 350, 22, 28), new Rectangle(25, 350, 22, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonMarioMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Move Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonMarioMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Left
            currentFrames = new Rectangle[] { new Rectangle(103, 350, 28, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonMarioJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Jump Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonMarioJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Left
            currentFrames = new Rectangle[] { new Rectangle(77, 350, 24, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("RaccoonMarioCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Mario Crouch Right
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("RaccoonMarioCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Normal Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17), new Rectangle(19, 51, 16, 17) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(73, 178, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(55, 180, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("NormalLuigiCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("NormalLuigiCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));


            // Big Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 179, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(19, 178, 17, 28), new Rectangle(37, 178, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(73, 178, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(55, 180, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("BigLuigiCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("BigLuigiCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));



            // Fire Luigi States

            // Luigi Still Left.
            currentFrames = new Rectangle[] { new Rectangle(1, 265, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiStillLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Still Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiStillRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Left.
            currentFrames = new Rectangle[] { new Rectangle(19, 264, 17, 28), new Rectangle(37, 264, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiMoveLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Move Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiMoveRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Left.
            currentFrames = new Rectangle[] { new Rectangle(73, 264, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiJumpLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Jump Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiJumpRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Left.
            currentFrames = new Rectangle[] { new Rectangle(55, 265, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiCrouchLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Crouch Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiCrouchRight", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Throw Left.
            currentFrames = new Rectangle[] { new Rectangle(209, 298, 17, 28), new Rectangle(227, 298, 17, 28) };
            effect = SpriteEffects.None;
            statesAndSprites.Add("FireLuigiThrowLeft", new AnimatedSprite(currentFrames, texture, mario, effect));

            // Luigi Throw Right.
            effect = SpriteEffects.FlipHorizontally;
            statesAndSprites.Add("FireLuigiThrowRight", new AnimatedSprite(currentFrames, texture, mario, effect));





        }
        public AnimatedSprite returnSprite(String spriteType)
        {

            generatedCharacter = statesAndSprites[spriteType];
            generatedCharacter.spriteName = spriteType;
            return generatedCharacter;
        }
    }

}
