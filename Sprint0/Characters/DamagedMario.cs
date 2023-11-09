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
        public Vector2 position { get { return decoratedMario.position; } set { decoratedMario.position = value; } }

        public Mario.MarioHealth health { get; set; }
        public Mario.MarioPose pose { get; set; }
        public AnimatedSpriteMario currentSprite { get; set; }

        private ObjectManager manager;
        public IMario decoratedMario;
        public int timer;

        private List<Color> colors = new List<Color> {
            Color.Transparent,
            Color.White
        };
        public DamagedMario(IMario mario, ObjectManager manager) 
        {
            this.manager = manager;
            decoratedMario = mario;
            health = mario.health;
            currentSprite = mario.currentSprite;
            timer = 50;
            State = mario.State;
            System.Diagnostics.Debug.WriteLine("position at creation: " + position);
        }

        public void ChangeToBig()   { decoratedMario.ChangeToBig(); }

        public void ChangeToFire() { decoratedMario.ChangeToFire(); }

        public void ChangeToNormal()    { decoratedMario.ChangeToNormal();  }

        public void ChangeToRaccoon()   { decoratedMario.ChangeToRaccoon();  }

        public void Crouch() { decoratedMario.Crouch();  }

        public void Die()  { decoratedMario.Die();  }

        public void Jump() { decoratedMario.Jump();  }
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

            Destination = currentSprite.destination;
            decoratedMario.Update(gametime);
            camera.Update(decoratedMario);
        }

        void RemoveDecorator()
        {
            manager.DynamicEntities.Insert(0, decoratedMario);
        }

        public void Draw(SpriteBatch spritebatch) 
        { 
            currentSprite.Draw(spritebatch, new Vector2(position.X, position.Y), colors[(timer / 3) % 2]); 
        }
    }
}
