using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioDead : MarioActionState
    {
        public MarioDead(Mario mario)
            : base(mario)
        {

        }
        public override int Factor()
        {
            return 50;
        }


        public override void Update(GraphicsDeviceManager graphics)
        {
            //if (collisionBox.position != ) {   
            mario.MarioVec_Y++;
            //}

        }
    }
}
