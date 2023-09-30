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
    internal class LuigiMoveLeft : ICharacterState
    {
        private Luigi luigi;

        public LuigiMoveLeft(Luigi luigi)
        {
            this.luigi = luigi;

        }
        public void ChangeDirection()
        {
            luigi.luigiState = new LuigiFaceRight(luigi);
        }

        public void Move()
        {
            luigi.luigiState = new LuigiMoveLeft(luigi);
        }

        public void Stop()
        {
            luigi.luigiState = new LuigiFaceLeft(luigi);
        }



        public void Update(GameTime gameTime)
        {
            switch (luigi.health)
            {
                case (Luigi.LuigiHealth.Normal):
                    {
                        if (luigi.currentSprite.spriteName.Equals("NormalLuigiRunAround") && luigi.myDirection == -1)
                        {
                            luigi.position.X += luigi.myDirection;
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "NormalLuigiRunAround", gameTime);
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
                        if (luigi.currentSprite.spriteName.Equals("FireLuigiRunAround") && luigi.myDirection == -1)
                        {
                            luigi.position.X += luigi.myDirection;
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "FireLuigiRunAround", luigi.mySprint.myGameTime);
                            luigi.currentSprite.direction = luigi.myDirection;
                        }
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        if (String.Equals("BigLuigiRunAround", luigi.currentSprite.spriteName) && luigi.myDirection == -1)
                        {
                            luigi.position.X += luigi.myDirection;
                            luigi.currentSprite.Update(luigi.mySprint.myGameTime);
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = luigi.mySpriteFactory.returnSprite(luigi.position, "BigLuigiRunAround", gameTime);
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


