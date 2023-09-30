using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class FireProjectile : ISprite
    {
        private Sprint0 mySprint;
        private Rectangle spriteFrames;
        private Rectangle position;
        private Texture2D projectileTexture;
        private bool movingLeft;

        public FireProjectile(Sprint0 Sprint0, ICharacter character)
        {
            mySprint = Sprint0;

            //Replace with projectile texture file
            projectileTexture = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");
            spriteFrames = new Rectangle(/*projectile sprite coords in file*/);
            movingLeft = character.facingLeft;

            //replace 0's with sprite width and height
            position = new Rectangle((int)character.position.X, (int)character.position.Y, 0, 0);
        }
        public void Update(GameTime gametime)
        {
            if (movingLeft)
            {
                this.position.X -= 1;
            }
            else
            {
                this.position.X += 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(projectileTexture, position, spriteFrames, Color.White);
        }
    }
}
