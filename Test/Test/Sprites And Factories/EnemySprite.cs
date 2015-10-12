using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class GoombaWalkingSprite : Sprite
    {

        public GoombaWalkingSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {         
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {
                Rectangle drawRect = new Rectangle(SourceRect.X + (30 * Frame), SourceRect.Y, 16, SourceRect.Height);
                spriteBatch.Draw(Texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);

                DrawBox(new Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height), spriteBatch, 1, Color.Red);
            }
            else
            {
                Rectangle drawRect = new Rectangle(SourceRect.X + (60), SourceRect.Y, 16, SourceRect.Height);
                spriteBatch.Draw(Texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);

                DrawBox(new Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height), spriteBatch, 1, Color.Red);
             }
        }
                 

    }
    

    public class GoombaSquishedSprite : Sprite
    {
        public GoombaSquishedSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle drawRect = new Rectangle(SourceRect.X + (60), SourceRect.Y, 16, SourceRect.Height);
            spriteBatch.Draw(Texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);

            DrawBox(new Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height), spriteBatch, 1, Color.Red);
        }
    }
}
