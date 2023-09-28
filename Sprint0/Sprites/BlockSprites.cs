using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sprint0.Sprites
{
    internal class BlockSprites : ISprite
    {
        private Sprint0 game;
        private Rectangle[] blockSprite;

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }

        public BlockSprites(Texture2D texture)
        {
            Texture = texture;
<<<<<<< HEAD
            Position = new Vector2(0, 0);
=======
            Position = new Vector2(700, 100);
>>>>>>> 5a6f5ec1e6f1f792bfac033964323ec88da9546c
            Origin = new Vector2(0, 0);
            Rotation = 0;
            Scale = new Vector2(1, 1);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0);
        }

    }
}
