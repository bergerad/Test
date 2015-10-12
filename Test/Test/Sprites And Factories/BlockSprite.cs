using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BlockQuestionSprite: Sprite
    {

        public BlockQuestionSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base (position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.alive)
            {
                Rectangle drawRect = new Rectangle(SourceRect.X + (16 * Frame), 0, 16, 16);
                spriteBatch.Draw(Texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
            }
            else
            {
                Rectangle drawRect = new Rectangle(48, 0, 16, 16);
                spriteBatch.Draw(Texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
            }
            DrawBox(new Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height), spriteBatch, 1, Color.Red);
        
        }
    }

    public class BlockUsedSprite: Sprite
    {
        public BlockUsedSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base (position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated) 
        {
        }     
    }

    public class BlockFloorSprite : Sprite
    {
        public BlockFloorSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {
        }

    }

    public class BlockBrickSprite : Sprite
    {
        public BlockBrickSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {
        }
    }

    public class BlockPyramidSprite : Sprite
    {
        public BlockPyramidSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }

    public class BlockHiddenSprite : Sprite
    {
        public BlockHiddenSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }

}
