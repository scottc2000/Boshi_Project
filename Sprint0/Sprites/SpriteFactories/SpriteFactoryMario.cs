using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.SpriteFactories
{
    public class SpriteFactoryMario
    {
        private ISprite currentSprite;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private string spriteType;
        private SpriteEffects left;
        private SpriteEffects right;
        private static SpriteFactoryMario instance = new SpriteFactoryMario();

        public static SpriteFactoryMario Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteFactoryMario()
        {
            left = SpriteEffects.None;
            right = SpriteEffects.FlipHorizontally;

        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");
        }

        // Idle States
        public ISprite CreateNormalMarioLeftIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightIdle()
        {

            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 92, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 92, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 263, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 263, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        public ISprite CreateRaccoonMarioLeftIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 350, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightIdle()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 350, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }


        // Move States
        public ISprite CreateNormalMarioLeftMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16), new Rectangle(19, 16, 15, 16),
            new Rectangle(37, 16, 15, 16), new Rectangle(19, 16, 15, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16), new Rectangle(19, 16, 15, 16),
            new Rectangle(37, 16, 15, 16), new Rectangle(19, 16, 15, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 92, 14, 27), new Rectangle(19, 92, 16, 27),
            new Rectangle(37, 92, 16, 27), new Rectangle(19, 92, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 92, 14, 27), new Rectangle(19, 92, 16, 27),
            new Rectangle(37, 92, 16, 27), new Rectangle(19, 92, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftMove()
        {
            currentFrames = new Rectangle[] {new Rectangle(2, 263, 14, 27), new Rectangle(19, 263, 16, 27),
            new Rectangle(37, 263, 16, 27), new Rectangle(19, 263, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightMove()
        {
            currentFrames = new Rectangle[] {new Rectangle(2, 263, 14, 27), new Rectangle(19, 263, 16, 27),
            new Rectangle(37, 263, 16, 27), new Rectangle(19, 263, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 350, 14, 27), new Rectangle(27, 350, 16, 27),
            new Rectangle(53, 350, 16, 27), new Rectangle(27, 350, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightMove()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 350, 14, 27), new Rectangle(27, 350, 16, 27),
            new Rectangle(53, 350, 16, 27), new Rectangle(27, 350, 16, 27)};
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Jump States
        public ISprite CreateNormalMarioLeftJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(36, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(36, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(72, 92, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(72, 92, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(72, 263, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left); ;
        }
        public ISprite CreateFireMarioRightJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(72, 263, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(105, 350, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightJump()
        {
            currentFrames = new Rectangle[] { new Rectangle(105, 350, 16, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Crouch States
        public ISprite CreateNormalMarioLeftCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(2, 16, 12, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(54, 92, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(54, 92, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(54, 263, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(54, 263, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(79, 350, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightCrouch()
        {
            currentFrames = new Rectangle[] { new Rectangle(79, 350, 14, 27) };
            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Action States
        public ISprite CreateFireMarioLeftThrow()
        {
            return currentSprite;
        }
        public ISprite CreateFireMarioRightThrow()
        {
            return currentSprite;
        }
        public ISprite CreateRaccoonAttack()
        {
            return currentSprite;
        }

        // Dead Mario
        public ISprite CreateDeadMario()
        {
            currentFrames = new Rectangle[] { new Rectangle(307, 16, 16, 16) };
            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
    }

}