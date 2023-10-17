using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sprint0.Sprites.SpriteFactories
{
    public class SpriteFactoryMario
    {
        private ISprite currentSprite;
        private Rectangle[] currentFrames;

        private Texture2D texture;
        private string spriteType;
        private SpriteEffects left;
        private SpriteEffects right;
        private MarioStateInfo? marioStateInfo;
        private static SpriteFactoryMario instance = new SpriteFactoryMario();

        public static SpriteFactoryMario Instance
        {
            get
            {
                return instance;
            }
        }

        public SpriteFactoryMario()
        {
            left = SpriteEffects.None;
            right = SpriteEffects.FlipHorizontally;

        }
        public void LoadTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpriteImages/playerssclear");

            // Load Mario's state information from the JSON file
            string fileName = "SpriteJSONS/MarioJSON.json";
            string jsonText = File.ReadAllText(fileName);
            marioStateInfo = JsonSerializer.Deserialize<MarioStateInfo>(jsonText);
        }

        // Classes to represent the structure of the JSON data
        private class MarioStateInfo
        {
            public List<MarioDead> MarioDead { get; set; }
            public List<MarioRaccoon> MarioRaccoon { get; set; }
            public List<MarioFire> MarioFire { get; set; }
            public List<MarioBig> MarioBig { get; set; }
            public List<MarioNormal> MarioNormal { get; set; }
            public List<StatsInfo> MarioStats { get; set; }
        }
        public class MarioDead
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class MarioBig
        {
            public string ID { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public List<int> xArray { get; set; }
        }

        public class MarioFire
        {
            public string ID { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public List<int> xArray { get; set; }
        }

        public class MarioNormal
        {
            public string ID { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public List<int> xArray { get; set; }
        }

        public class MarioRaccoon
        {
            public string ID { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public List<int> xArray { get; set; }
        }
        private class StatsInfo
        {
            public int BigWidth { get; set; }
            public int BigWalkingWidth { get; set; }
            public int BigHeight { get; set; }
            public int BigCrouchHeight { get; set; }
            public int NormalWidth { get; set; }
            public int NormalWalkingWidth { get; set; }
            public int NormalHeight { get; set; }
            public int DeadWidth { get; set; }
            public int DeadHeight { get; set; }
        }

        // Idle States
        public ISprite CreateNormalMarioLeftIdle()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Idle"); // these lines need to be fixed - issues with null reference errors
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightIdle()
        {
            int x = marioStateInfo.MarioNormal[0].x; // these lines need to be fixed - issues with null reference errors
            int y = marioStateInfo.MarioNormal[0].y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftIdle()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightIdle()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftIdle()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightIdle()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        
        public ISprite CreateRaccoonMarioLeftIdle()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightIdle()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Idle");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }


        // Move States
        public ISprite CreateNormalMarioLeftMove()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int walkingWidth = marioStateInfo.MarioStats[5].NormalWalkingWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height), 
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightMove()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int walkingWidth = marioStateInfo.MarioStats[5].NormalWalkingWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftMove()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightMove()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftMove()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightMove()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftMove()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightMove()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Walk");
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int walkingWidth = marioStateInfo.MarioStats[1].BigWalkingWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle((int)idleEntry.xArray[0], y, width, height), new Rectangle((int)idleEntry.xArray[1], y, walkingWidth, height),
                new Rectangle((int)idleEntry.xArray[2], y, walkingWidth, height), new Rectangle((int)idleEntry.xArray[3], y, walkingWidth, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Jump States
        public ISprite CreateNormalMarioLeftJump()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightJump()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftJump()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightJump()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftJump()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left); ;
        }
        public ISprite CreateFireMarioRightJump()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftJump()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightJump()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Jump");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[2].BigHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Crouch States
        public ISprite CreateNormalMarioLeftCrouch()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateNormalMarioRightCrouch()
        {
            var idleEntry = marioStateInfo.MarioNormal.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[4].NormalWidth;
            int height = marioStateInfo.MarioStats[6].NormalHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateBigMarioLeftCrouch()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateBigMarioRightCrouch()
        {
            var idleEntry = marioStateInfo.MarioBig.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateFireMarioLeftCrouch()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateFireMarioRightCrouch()
        {
            var idleEntry = marioStateInfo.MarioFire.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }
        public ISprite CreateRaccoonMarioLeftCrouch() 
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
        public ISprite CreateRaccoonMarioRightCrouch()
        {
            var idleEntry = marioStateInfo.MarioRaccoon.Find(entry => entry.ID == "Crouch");
            int x = idleEntry.x;
            int y = idleEntry.y;
            int width = marioStateInfo.MarioStats[0].BigWidth;
            int height = marioStateInfo.MarioStats[3].BigCrouchHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, right);
        }

        // Action States
        public ISprite CreateFireMarioLeftThrow()
        {
            return currentSprite;
        }
        public ISprite CreateFireMarioRightThrow()
        {
            return currentSprite;
        }
        public ISprite CreateRaccoonAttack()
        {
            return currentSprite;
        }
        
        // Dead Mario
        public ISprite CreateDeadMario ()
        {
            int x = marioStateInfo.MarioDead[0].x;
            int y = marioStateInfo.MarioDead[0].y;
            int width = marioStateInfo.MarioStats[7].DeadWidth;
            int height = marioStateInfo.MarioStats[8].DeadHeight;
            currentFrames = new Rectangle[] { new Rectangle(x, y, width, height) };

            return currentSprite = new PlayerSprite(currentFrames, texture, left);
        }
    }

}
