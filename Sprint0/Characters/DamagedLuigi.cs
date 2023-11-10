using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Camera;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using Sprint0.Sprites.Players;
using System.Collections.Generic;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Characters
{
    public class DamagedLuigi : ILuigi
    {
        public MarioCamera camera;
        public ICharacterState State { get; set; }
        public bool facingLeft { get; set; }
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }
        public bool isInvinsible { get; set; }
        public int runningTimer { get; set; }
        public int flyingTimer { get; set; }
        public Vector2 position { get { return decoratedLuigi.position; } set { decoratedLuigi.position = value; } }

        public Luigi.LuigiHealth health { get; set; }
        public Luigi.LuigiPose pose { get; set; }
        public AnimatedSpriteLuigi currentSprite { get; set; }

        private LevelLoader1 level;
        public ILuigi decoratedLuigi;
        public int timer;

        private List<Color> colors = new List<Color> {
            Color.Transparent,
            Color.White
        };
        public DamagedLuigi(ILuigi luigi, LevelLoader1 level) 
        {
            this.level = level;
            decoratedLuigi = luigi;
            health = luigi.health;
            currentSprite = luigi.currentSprite;
            timer = 75;
            State = luigi.State;
            
        }

        public void ChangeToBig()   { decoratedLuigi.ChangeToBig(); }

        public void ChangeToFire() { decoratedLuigi.ChangeToFire(); }

        public void ChangeToNormal()    { decoratedLuigi.ChangeToNormal();  }

        public void ChangeToRaccoon()   { decoratedLuigi.ChangeToRaccoon();  }

        public void Crouch() { decoratedLuigi.Crouch();  }

        public void Die()  { decoratedLuigi.Die();  }

        public void Jump() { decoratedLuigi.Jump();  }
        //public void Fly() { decoratedLuigi.Fly(); }

        public void Move() { decoratedLuigi.Move();  }

        public void Reverse() { decoratedLuigi.Reverse();  }

        public void Stop() { decoratedLuigi.Stop();  }

        public void Throw() {  }

        public void Update(GameTime gametime)  
        {
            timer--;
            if (timer == 0)
            {
                isInvinsible = false;
                RemoveDecorator();
            }
            int offset = 1;

            position = new Vector2(position.X, position.Y - offset);
            
            Destination = currentSprite.destination;
            decoratedLuigi.Update(gametime);
            //level.camera.Update(decoratedLuigi);
        }

        void RemoveDecorator()
        {
            System.Diagnostics.Debug.WriteLine("Decorator Removed");
            System.Diagnostics.Debug.WriteLine("Destination : " + Destination);
            level.luigi = decoratedLuigi;
        }

        public void Draw(SpriteBatch spritebatch) 
        {
            currentSprite.Draw(spritebatch, new Vector2(position.X, position.Y), colors[(timer / 3) % 2]);
        }
    }
}
