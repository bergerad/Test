using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BlockFactory
    {
     
        Texture2D texture;
        Rectangle sourceRect;
        int numberOfFrames;
        int timePerFrame;
        enum spriteType { questionBlock = 1, brickBlock = 2, floorBlock = 3, pyramidBlock = 4, usedBlock = 5, hiddenBlock = 6 };
        spriteType sprite = spriteType.usedBlock;
        public BlockFactory(Game1 game)
        {
            this.texture = game.Content.Load<Texture2D>("tiles-2"); 
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
                    case spriteType.questionBlock:
                    {               
                        numberOfFrames = 3;
                        timePerFrame = 250;
                        sourceRect.X = 368;
                        sourceRect.Width = 48;
                        Sprite blockQuestion = new BlockQuestionSprite(Vector2.Zero, texture, sourceRect, timePerFrame, numberOfFrames,true);
                        return blockQuestion;
                    }
                    case spriteType.brickBlock:
                    {
                        sourceRect.X = 30;
                        Sprite blockBrick = new BlockBrickSprite(Vector2.Zero, texture, sourceRect, 0, numberOfFrames, false);
                        return blockBrick;
                    }
                    case spriteType.floorBlock:
                    {
                        Sprite blockFloor = new BlockFloorSprite(Vector2.Zero, texture, sourceRect, 0, numberOfFrames, false);
                        return blockFloor;
                    }
                    case spriteType.pyramidBlock:
                    {
                        sourceRect.Y = 16;
                        Sprite blockPyramid = new BlockPyramidSprite(Vector2.Zero, texture, sourceRect, 0, numberOfFrames, false);
                        return blockPyramid;
                    }
                    case spriteType.usedBlock:
                    {
                        sourceRect.X = 48;
                        Sprite blockUsed = new BlockUsedSprite(Vector2.Zero, texture, sourceRect, 0, numberOfFrames, false);
                        return blockUsed;
                    }
                    case spriteType.hiddenBlock:
                    {
                        sourceRect.X = 432;
                        Sprite blockHidden = new BlockHiddenSprite(Vector2.Zero, texture, sourceRect, 0, numberOfFrames, false);
                        return blockHidden;
                    }
                    default:
                    {
                        return null;
                    }
                }
        }
    }
}
