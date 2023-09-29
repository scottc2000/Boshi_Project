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
    internal class LuigiFaceLeft : ICharacterState
    {
        private Luigi luigi;

        public LuigiFaceLeft(Luigi luigi)
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

        }

        

        public void Update(GameTime gameTime)
        {
            
            switch (luigi.health)
            {
                case (Luigi.LuigiHealth.Normal):
                    {

                        // changes sprite if needed, otherwise keeps to same one
                        if (luigi.currentSprite is NormalLuigiStill && luigi.myDirection == -1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = new NormalLuigiStill(luigi);
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
                        if (luigi.currentSprite is FireLuigiStill && luigi.myDirection == -1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = new FireLuigiStill(luigi);
                        }
                        break;
                    }

                case (Luigi.LuigiHealth.Big):
                    {
                        // changes sprite if needed, otherwise keeps to same one
                        if (luigi.currentSprite is BigLuigiStill && luigi.myDirection == -1)
                        {
                            luigi.currentSprite.Update();
                        }
                        else
                        {
                            luigi.myDirection = -1;
                            luigi.currentSprite = new BigLuigiStill(luigi);
                        }
                        break;
                    }

            }
        }

        // uneeded imo, drawing should be handled by Charecter object
        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {

        }
    }
}


