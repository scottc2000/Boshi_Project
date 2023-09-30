using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
	public class CharacterSpriteFactory
	{ 
		ContentManager content;
		GameTime gameTime;
		ICharacterState currentState;

		public Dictionary<String, AnimatedSprite> statesAndSprites;
		String spriteType;
        Texture2D texture;
		AnimatedSprite generatedCharacter;
		Vector2 position;
    
		public CharacterSpriteFactory(ContentManager content, GameTime gameTime)
		{
			this.content = content;
			this.gameTime = gameTime;
            
            // String used as ID for sprites needed, AnimatedSprite uses spritesheet locations currentSprite and destination rectangle int[]
			statesAndSprites = new Dictionary<String, AnimatedSprite>();

			


    }
        public void LoadTextures()
		{
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

			// NORMAL LUIGI SPRITES

			// LUIGI STILL

			Rectangle[] currentSprites = new Rectangle[]{ new Rectangle(1, 53, 16, 17) };
			statesAndSprites.Add("NormalLuigiStill", new AnimatedSprite(currentSprites, this.gameTime, texture, new int[] {27, 27}, -1));

			// LUIGI JUMPc
			currentSprites = new Rectangle[] { new Rectangle(37, 51, 17, 17) };
            statesAndSprites.Add("NormalLuigiJump", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 27, 27 }, -1));

            // LUIGI Crouchc
            currentSprites = new Rectangle[] { new Rectangle(1, 53, 16, 17) };
            statesAndSprites.Add("NormalLuigiCrouch", new AnimatedSprite(currentSprites, this.gameTime, texture, new int[] { 27, 27 }, -1));

            // LUIGI RUN AROUND  c
            currentSprites = new Rectangle[] { new Rectangle(1, 53, 16, 17), new Rectangle(19, 51, 16, 17) };
            statesAndSprites.Add("NormalLuigiRunAround", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 27, 27 }, -1));



            // BIG LUIGI SPRITES

            // LUIGI STILL c
            currentSprites = new Rectangle[] { new Rectangle(1, 179, 17, 28) };
            statesAndSprites.Add("BigLuigiStill", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI JUMP c
            currentSprites = new Rectangle[] { new Rectangle(73, 178, 17, 28) };
            statesAndSprites.Add("BigLuigiJump", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI RUN AROUND c
            currentSprites = new Rectangle[] { new Rectangle(19, 178, 17, 28), new Rectangle(37, 178, 17, 28) };
            statesAndSprites.Add("BigLuigiRunAround", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI Crouchc
            currentSprites = new Rectangle[] { new Rectangle(55, 180, 17, 28) };
            statesAndSprites.Add("BigLuigiCrouch", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // FIRE LUIGI SPRITES

            // LUIGI STILL c
            currentSprites = new Rectangle[] { new Rectangle(1, 265, 17, 28) };
            statesAndSprites.Add("FireLuigiStill", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI JUMP c
            currentSprites = new Rectangle[] { new Rectangle(73, 264, 17, 28) };
            statesAndSprites.Add("FireLuigiJump", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI RUN AROUND 
            currentSprites = new Rectangle[] { new Rectangle(19, 264, 17, 28), new Rectangle(37, 264, 17, 28) };
            statesAndSprites.Add("FireLuigiRunAround", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI ATTACK
            currentSprites = new Rectangle[] { new Rectangle(209, 298, 17, 28), new Rectangle(227, 298, 17, 28) };
            statesAndSprites.Add("FireLuigiAttack", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));

            // LUIGI Crouch
            currentSprites = new Rectangle[] { new Rectangle(55, 265, 17, 28) };
            statesAndSprites.Add("FireLuigiCrouch", new AnimatedSprite(currentSprites, gameTime, texture, new int[] { 34, 56 }, -1));



        }
        public AnimatedSprite returnSprite(String spriteType, GameTime gameTime)
        {
            // generates sprite and returns it
            this.gameTime = gameTime;
			generatedCharacter = statesAndSprites[spriteType];
            generatedCharacter.spriteName = spriteType;
            return generatedCharacter;
        }
    }
}

