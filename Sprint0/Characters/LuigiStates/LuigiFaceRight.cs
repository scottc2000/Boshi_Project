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
    internal class LuigiFaceRight : ICharacterState
    {
        private Luigi luigi;

        public LuigiFaceRight(Luigi luigi)
        {
            this.luigi = luigi;

        }
        public void ChangeDirection()
        {
            luigi.luigiState = new LuigiFaceLeft(luigi);
        }

        public void Move()
        {
            luigi.luigiState = new LuigiMoveLeft(luigi);
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
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "NormalLuigiStill", luigi.mySprint.myGameTime);
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
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "FireLuigiStill", luigi.mySprint.myGameTime);
                        }
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        if (luigi.currentSprite.spriteName.Equals("BigLuigiStill"))
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "BigLuigiStill", luigi.mySprint.myGameTime);
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

