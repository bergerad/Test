using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class FlowerSprite : Sprite
    {
        public FlowerSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }

    public class StarSprite : Sprite
    {
        public StarSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }

    public class MushroomSprite : Sprite
    {
        public MushroomSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }
    public class CoinSprite : Sprite
    {
        public CoinSprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
            : base(position, texture, sourceRect, timePerFrame, numberOfFrames, isAnimated)
        {

        }
    }
}
