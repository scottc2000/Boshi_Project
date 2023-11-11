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
    public class DamagedMario : IMario
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
        public bool boosted { get; set; }
        public Vector2 position { get { return decoratedMario.position; } set { decoratedMario.position = value; } }

        public Mario.MarioHealth health { get; set; }
        public Mario.MarioPose pose { get; set; }
        public AnimatedSpriteMario currentSprite { get; set; }

        private LevelLoader1 level;
        public IMario decoratedMario;
        public int timer;
        int ySnapshot;

        private List<Color> colors = new List<Color> {
            Color.Transparent,
            Color.White
        };
        public DamagedMario(IMario mario, LevelLoader1 level) 
        {
            this.level = level;
            decoratedMario = mario;
            health = mario.health;
            currentSprite = mario.currentSprite;
            timer = 75;
            State = mario.State;
            ySnapshot = (int)mario.position.Y;
        }

        public void ChangeToBig()   { decoratedMario.ChangeToBig(); }

        public void ChangeToFire() { decoratedMario.ChangeToFire(); }

        public void ChangeToNormal()    { decoratedMario.ChangeToNormal();  }

        public void ChangeToRaccoon()   { decoratedMario.ChangeToRaccoon();  }

        public void Crouch() { decoratedMario.Crouch();  }

        public void Die()  { decoratedMario.Die();  }

        public void Jump() { decoratedMario.Jump();  }

        public void Fall() { decoratedMario.Fall(); }

        public void Fly() { decoratedMario.Fly(); }

        public void Move() { decoratedMario.Move();  }

        public void Reverse() { decoratedMario.Reverse();  }

        public void Stop() { decoratedMario.Stop();  }

        public void Throw() {  }

        public void Update(GameTime gametime)  
        {
            timer--;
            if (timer == 0)
            {
                isInvinsible = false;
                RemoveDecorator();
            }
            position = new Vector2(position.X, ySnapshot);
            Destination = currentSprite.destination;
            decoratedMario.Update(gametime);
            level.camera.Update(decoratedMario);
        }

        void RemoveDecorator()
        {
            System.Diagnostics.Debug.WriteLine("Decorator Removed");
            System.Diagnostics.Debug.WriteLine("Destination : " + Destination);
            level.mario = decoratedMario;
        }

        public void Draw(SpriteBatch spritebatch) 
        { 
            currentSprite.Draw(spritebatch, new Vector2(position.X, position.Y), colors[(timer / 3) % 2]); 
        }
    }
}
