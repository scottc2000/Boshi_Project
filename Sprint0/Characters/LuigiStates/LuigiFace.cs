using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Characters.LuigiStates
{
    internal class LuigiFace: ICharacterState
    {
        private Luigi luigi;

        public LuigiFace(Luigi luigi)
        {
            this.luigi = luigi;

        }
        public void ChangeDirection()
        {
            luigi.luigiState = new LuigiFace(luigi);
        }

        public void Move()
        {
            
        }

        public void Stop()
        {

        }

        public void Update(GameTime gameTime)
        {
            switch (luigi.health)
            {
                case (Luigi.LuigiHealth.Normal):
                    {
                        if (luigi.currentSprite.spriteName.Equals("NormalLuigiStill"))
                        {
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("NormalLuigiStill", luigi.mySprint.myGameTime);
                            
                            luigi.currentSprite.direction = luigi.myDirection;
                        }
                        break;
                    }


                case (Luigi.LuigiHealth.Star):
                    {
                        //mario.mySprint.marioSprite = new MarioStarLeftIdleSprite(mario.mySprint);
                        break;
                    }

                case (Luigi.LuigiHealth.Fire):
                    {
                        if (luigi.currentSprite.spriteName.Equals("FireLuigiStill"))
                        {
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("FireLuigiStill", luigi.mySprint.myGameTime);
                            
                            luigi.currentSprite.direction = luigi.myDirection;
                        }
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        if (luigi.currentSprite.spriteName.Equals("BigLuigiStill"))
                        {
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {

                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite("BigLuigiStill", luigi.mySprint.myGameTime);
                            
                            luigi.currentSprite.direction = luigi.myDirection;
                        }
                        break;
                    }

            }
        }


        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {

        }
    }
}

