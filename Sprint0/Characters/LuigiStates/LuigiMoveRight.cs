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
    internal class LuigiMoveRight : ICharacterState
    {
        private Luigi luigi;

        public LuigiMoveRight(Luigi luigi)
        {
            this.luigi = luigi;

        }
        public void ChangeDirection()
        {
            luigi.luigiState = new LuigiFaceLeft(luigi);
        }

        public void Move()
        {
            luigi.luigiState = new LuigiMoveRight(luigi);
        }

        public void Stop()
        {
            luigi.luigiState = new LuigiFaceRight(luigi);
        }

        public void Update(GameTime gameTime)
        {
            switch (luigi.health)
            {
                case (Luigi.LuigiHealth.Normal):
                    {
                        if (luigi.currentSprite is NormalRunAroundSprite && luigi.myDirection == 1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = 1;
                            luigi.currentSprite = new NormalRunAroundSprite(luigi);
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
                        if (luigi.currentSprite is FireRunAroundSprite && luigi.myDirection == 1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = 1;
                            luigi.currentSprite = new FireRunAroundSprite(luigi);
                        }

                        
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        if (luigi.currentSprite is BigRunAroundSprite && luigi.myDirection == 1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = 1;
                            luigi.currentSprite = new BigRunAroundSprite(luigi);
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

