using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MarioGame;

namespace MarioGame
{
    class MarioWalkingState : MarioActionState
    {

        public MarioWalkingState(Mario mario)
            : base(mario)
        {

        }

        public override int Factor()
        {
            return 3;
        }
        public override void UpCommand()
        {
            mario.ToJump();
        }
        public override void DownCommand()
        {
      
        }

        public override void LeftCommand()
        {
            if (mario.Direction == 1)
            {
                mario.ToIdle();            
            }
        }
        public override void RightCommand()
        {
            if (mario.Direction == 0)
            {
                mario.ToIdle();
            }
        }

        public override void Update(GraphicsDeviceManager graphics)
        {
    
            if (mario.Direction == 1) {
                mario.MarioVec_X++;
            }
            else
            {
                mario.MarioVec_X--;
            }

            if ((mario.MarioVec_X < 0.0f) || // LEFT
               (mario.MarioVec_X > (graphics.GraphicsDevice.Viewport.Width - 16)))  // RIGHT
            {
                if (mario.MarioVec_X < 0.0f)  // LEFT
                    mario.MarioVec_X = 0.0f;
                else
                    if (mario.MarioVec_X > (graphics.GraphicsDevice.Viewport.Width - 16)) // RIGHT
                        mario.MarioVec_X = graphics.GraphicsDevice.Viewport.Width - 16;
                mario.ToIdle();
            }
        }
    }
}
