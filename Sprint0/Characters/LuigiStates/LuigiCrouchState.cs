using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiCrouchState : ICharacterState
    {
        private Luigi luigi;

        public LuigiCrouchState(Luigi luigi)
        {
            this.luigi = luigi;
        }
        public void ChangeDirection()
        {
            luigi.position *= -1;
        }
        public void Move()
        {

        }

        public void Stop()
        {

        }

        public void Draw()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            switch (luigi.health)
            {
                case (Luigi.LuigiHealth.Normal):
                    {

                        if (luigi.currentSprite is NormalLuigiStill)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.currentSprite = new NormalLuigiStill(luigi);
                        }
                        break;
                    }


                case (Luigi.LuigiHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarCrouchLeftSprite(mario.mySprint);
                        break;
                    }

                case (Luigi.LuigiHealth.Fire):
                    {
                        if (luigi.currentSprite is FireCrouchingLuigi)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.currentSprite = new FireCrouchingLuigi(luigi);
                        }

                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        if (luigi.currentSprite is BigCrouchingLuigi)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.currentSprite = new BigCrouchingLuigi(luigi);
                        }

                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            throw new NotImplementedException();
        }
    }
}
