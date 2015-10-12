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
    class MarioJumpingState : MarioActionState
    {
        
        public MarioJumpingState(Mario mario)
            : base(mario)
        {

        }

        public override int Factor()
        {
            return 2;
        }

      public override void UpCommand(){
        
      }
      public override void DownCommand()
      {
          mario.CurrentState = mario.PreviousState;
          mario.CurrentSprite = (MarioSprite)mario.PreviousSprite;
      }

      public override void LeftCommand()
      {
          if (mario.Direction == 1)
          {
              mario.Direction = 0;
          }
      }
      public override void RightCommand()
      {
          if (mario.Direction == 0)
          {
              mario.Direction = 1;
          }
      }
      public override void Update(GraphicsDeviceManager graphics)
      {
           //if (collisionBox.position != ) {   
            mario.MarioVec_Y--;
           //}

            // Limit to Top
            if ((mario.MarioVec_Y - mario.CollisionBox.Height < 0.0f))
            {
                mario.ToIdle();
            }
      }
    
    }
}
