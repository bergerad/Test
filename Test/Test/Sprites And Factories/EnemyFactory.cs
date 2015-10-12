using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class EnemyFactory
    {
        Texture2D texture;
        Rectangle sourceRect;
        int numberOfFrames;
        int timePerFrame;  
        enum spriteType { goombaWalking = 1, goombaSquished = 2 };
        spriteType sprite = spriteType.goombaWalking;
        public EnemyFactory(Game1 game)
        {
            this.texture = game.Content.Load<Texture2D>("Enemies");
        }
        public Sprite MakeProduct(int x)
        {
            sprite = (spriteType)x;

            sourceRect.Width = 16;
            sourceRect.X = 0;
            sourceRect.Y = 0;
            sourceRect.Height = 16;
            timePerFrame = 0;
            switch (sprite)
            {
                case spriteType.goombaWalking:
                    {
                        sourceRect.Width = 48;
                        sourceRect.Height = 16;
                        sourceRect.X = 0;
                        sourceRect.Y = 4;
                        timePerFrame = 250;
                        numberOfFrames = 2;
                        Sprite gooms = new GoombaWalkingSprite(Vector2.Zero, texture, sourceRect, timePerFrame, numberOfFrames, true);
                        return gooms;
                    }
                case spriteType.goombaSquished:
                    {
                        sourceRect.X = 60;
                        sourceRect.Y = 16;
                        sourceRect.Width = 16;
                        sourceRect.Height = 8;
                        Sprite goomMeister = new GoombaSquishedSprite(Vector2.Zero, texture, sourceRect, timePerFrame, numberOfFrames, false);
                        return goomMeister;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
