using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.MarioStates
{
    internal class LuigiAttackState : ICharacterState
    {
        private Luigi luigi;

        public LuigiAttackState(Luigi luigi)
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
                        
                        break;
                    }


                case (Luigi.LuigiHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarCrouchLeftSprite(mario.mySprint);
                        break;
                    }

                case (Luigi.LuigiHealth.Fire):
                    {
                        if (luigi.currentSprite.spriteName.Equals("FireLuigiAttack"))
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "FireLuigiAttack", luigi.mySprint.myGameTime);
                        }
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        
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
