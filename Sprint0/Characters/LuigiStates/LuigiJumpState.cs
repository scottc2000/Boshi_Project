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
    internal class LuigiJumpState : ICharacterState
    {
        private Luigi luigi;

        public LuigiJumpState(Luigi luigi)
        {
            this.luigi = luigi;
        }
        public void ChangeDirection()
        {
            luigi.myDirection *= -1;
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
                        if (luigi.currentSprite is NormalJumpingLuigi)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.currentSprite = new NormalJumpingLuigi(luigi);
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
                        //luigi.mySprint.marioSprite = new MarioFireCrouchLeftSprite(luigi.mySprint);
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        //luigi.mySprint.marioSprite = new MarioBigCrouchLeftSprite(luigi.mySprint);
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
