using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface ISprite 
    {
        void Update(float elapsed, int direction);
        void Draw(SpriteBatch spriteBatch);
       
 

    }
}
