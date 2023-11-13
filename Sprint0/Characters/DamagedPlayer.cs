using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Items.Projectiles;
using Sprint0.Sprites.Players;
using Sprint0.Utility;
using System.Collections.Generic;

namespace Sprint0.Characters
{
    public class DamagedPlayer : IPlayer
    {
        private PlayerNumbers p;
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
        public Vector2 position { get { return decoratedPlayer.position; } set { decoratedPlayer.position = value; } }

        public Player.PlayerHealth health { get; set; }
        public Player.PlayerPose pose { get; set; }
        public AnimatedSpritePlayer currentSprite { get; set; }
        public int number { get; set; }
        public bool fired { get; set; }
        public FireProjectile fireProjectile { get; set; }

        private LevelLoader1 level;
        public IPlayer decoratedPlayer;
        public int timer;
        int ySnapshot;

        private List<Color> colors = new List<Color> {
            Color.Transparent,
            Color.White
        };
        public DamagedPlayer(IPlayer player, LevelLoader1 level) 
        {
            this.level = level;
            p = new PlayerNumbers();
            decoratedPlayer = player;
            health = player.health;
            currentSprite = player.currentSprite;
            timer = 75;
            State = player.State;
            ySnapshot = (int)player.position.Y; // store inital position
        }

        public void ChangeToBig()   { decoratedPlayer.ChangeToBig(); }

        public void ChangeToFire() { decoratedPlayer.ChangeToFire(); }

        public void ChangeToNormal()    { decoratedPlayer.ChangeToNormal();  }

        public void ChangeToRaccoon()   { decoratedPlayer.ChangeToRaccoon();  }

        public void Crouch() { decoratedPlayer.Crouch();  }

        public void Die()  { decoratedPlayer.Die();  }

        public void Jump() { decoratedPlayer.Jump();  }

        public void Fall() { decoratedPlayer.Fall(); }

        public void Fly() { decoratedPlayer.Fly(); }

        public void Move() { decoratedPlayer.Move();  }

        public void Reverse() { decoratedPlayer.Reverse();  }

        public void Stop() { decoratedPlayer.Stop();  }

        public void Throw() {  }

        public void Update(GameTime gametime)  
        {
            timer--;
            if (timer == 0)
            {
                isInvinsible = false;
                RemoveDecorator();
            }
            position = new Vector2(position.X, ySnapshot); // position adjusts as gametime continues, adjust appropiately
            Destination = currentSprite.destination;
            decoratedPlayer.Update(gametime);
            level.camera.Update(decoratedPlayer);
        }

        void RemoveDecorator()
        {
            if (decoratedPlayer.number == p.mario)
                level.mario = decoratedPlayer;
            else if (decoratedPlayer.number == p.luigi)
                level.luigi = decoratedPlayer;
        }

        public void Draw(SpriteBatch spritebatch) 
        { 
            currentSprite.Draw(spritebatch, new Vector2(position.X, position.Y), colors[(timer / 3) % 2]); 
        }
    }
}
