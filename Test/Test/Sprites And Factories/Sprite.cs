using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
   public abstract class Sprite: ISprite
    {
       private Texture2D texture;
        protected Texture2D Texture
        {
            get { return texture; }
            //   set { texture = value; }
        }
        private int timePerFrame;
        protected int TimePerFrame
        {
            get { return timePerFrame; }
            //  set { timePerFrame = value; }
        }
        private Rectangle sourceRect;
        protected Rectangle SourceRect
        {
            get { return sourceRect; }
            // set { sourceRect = value; }
        }
        private int numberOfFrames;
        protected int NumberOfFrames
        {
            get { return numberOfFrames; }
        }
        private int direction;
        protected int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        protected Vector2 origin;
        public bool alive = true;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox
        {
            get { return collisionBox; }
            set {collisionBox = value;}
        }
        private Vector2 position;
        public Vector2 Position
        {
            get { return CollisionBox.Position; }
            set { CollisionBox.Position = value; }
        }

        public float spritepos_X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public float spritepos_Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
       private bool isAnimated;
       private float totalElapsed = 0;
       private int frame = 0;
      // protected BlockFactory blockFactory;
       //comment
       public int Frame { get { return frame; } }
       int frameWidth;
       private Texture2D pixel;
           public Sprite(Vector2 position, Texture2D texture, Rectangle sourceRect, int timePerFrame, int numberOfFrames, bool isAnimated)
           {
               this.isAnimated = isAnimated;
               this.numberOfFrames = numberOfFrames;
               this.position = position;
               this.texture = texture;
               this.timePerFrame = timePerFrame;
               this.sourceRect = sourceRect;
               this.origin.X = 0;
               this.origin.Y = 0;
              // frameWidth = sourceRect.Width / numberOfFrames;
               frameWidth = 16;
               collisionBox = new CollisionBox(position.X, position.Y, 16, sourceRect.Height);
           }
           public virtual void Update(float elapsed,int direction)
           {
               if (isAnimated)
               {
                   totalElapsed += elapsed;
                   if (totalElapsed > timePerFrame)
                   {
                       frame++;
                       if (frame == numberOfFrames)
                           frame = 0;
                       totalElapsed -= timePerFrame;
                   }
               }
           
           }
           public virtual void Draw(SpriteBatch spriteBatch)
           {
               
               if(!isAnimated)
               spriteBatch.Draw(texture, Position, sourceRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
           else
           {
               Rectangle drawRect = new Rectangle(sourceRect.X + (frameWidth * frame), sourceRect.Y, frameWidth, sourceRect.Height);
               spriteBatch.Draw(texture, Position, drawRect, Color.White, 0, origin, 1f, SpriteEffects.None, 0);
           }
               DrawBox(new Rectangle((int)CollisionBox.X, (int)CollisionBox.Y, (int)CollisionBox.Width, (int)CollisionBox.Height), spriteBatch, 1, Color.Red);
           }

           public void DrawBox(Rectangle rectangleToDraw, SpriteBatch spriteBatch, int thicknessOfBorder, Color borderColor)
           {
               pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
               pixel.SetData(new[] { Color.White });
               spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

               // Draw left line
               spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

               // Draw right line
               spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                               rectangleToDraw.Y,
                                               thicknessOfBorder,
                                               rectangleToDraw.Height), borderColor);
               // Draw bottom line
               spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                               rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                               rectangleToDraw.Width,
                                               thicknessOfBorder), borderColor);

           }
        }
    }

