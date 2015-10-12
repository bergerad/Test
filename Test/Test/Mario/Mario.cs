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
    /*This class is a Context in the State Pattern. 
     */
    public class Mario
    {
        MarioActionState idle;
        MarioActionState jump;
        MarioActionState walk;
        MarioActionState crouch;
        MarioActionState fall;
        MarioFactory MarioFactory;
        MarioPowerupState standard;
        MarioPowerupState super;
        MarioPowerupState fire;
        MarioActionState dead;

        private Vector2 marioVec;
        public Vector2 MarioVec
        {
            get { return marioVec; }
            set { marioVec = value; }
        }

        public float MarioVec_X
        {
            get { return marioVec.X; }
            set { marioVec.X = value; }
        }
        public float MarioVec_Y
        {
            get { return marioVec.Y; }
            set { marioVec.Y = value; }
        }

        private int powerupStateFactor;
        public int PowerupStateFactor
        {
            get { return powerupStateFactor; }
            set { powerupStateFactor = value; }
        }
        int actionStateFactor;
        //Mario keeps track of his current state at all times.
        private MarioActionState currentState;
        public MarioActionState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        private MarioSprite currentSprite;

        public MarioSprite CurrentSprite
        {
            get { return currentSprite; }
            set { currentSprite = value; }
        }

        private MarioPowerupState powerupState;

        public MarioPowerupState PowerupState
        {
            get { return powerupState; }
            set { powerupState = value; }

        }
        private int direction;
        public int Direction{
            get { return direction; }
            set { direction = value; }
        }
        private MarioActionState previousState;
        public MarioActionState PreviousState
        {
            get { return previousState; }
            set { previousState = value; }
        }

        private ISprite previousSprite;
        public ISprite PreviousSprite
        {
            get { return previousSprite; }
            set { previousSprite = value; }
        }

        //private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get { return currentSprite.CollisionBox; } set { currentSprite.CollisionBox = value; } }


        public Mario(Game1 game, int posX, int posY)
        {
            MarioFactory = new MarioFactory(game);
            currentSprite = (MarioSprite)MarioFactory.MakeProduct(1);
            powerupStateFactor = 0;
            actionStateFactor = 1;
            direction = 1;
            idle = new MarioIdleState(this);
            jump = new MarioJumpingState(this);
            walk = new MarioWalkingState(this);
            crouch = new MarioCrouchingState(this);
            fall = new MarioFallingState(this);
            standard = new MarioStandard(this);
            super = new MarioSuper(this);
            fire = new MarioFire(this);
            dead = new MarioDead(this);
            
            powerupState = standard;
            currentState = idle;
            previousState = currentState;
            previousSprite = currentSprite;

            marioVec.X = posX;
            marioVec.Y = posY;
           
        }

        public void toFall()
        {
            previousState = currentState;
            currentState = fall;
            previousSprite = currentSprite;  
        }

        public void ToIdle()
        {

            previousState = currentState;
            currentState = idle;
            previousSprite = currentSprite;


        }
        public void ToJump()
        {
            previousState = currentState;
            currentState = jump;
            previousSprite = currentSprite;

        }

        public void ToWalk()
        {
            previousState = currentState;
            currentState = walk;
            previousSprite = currentSprite;
      
        }
        public void ToCrouch()
        {
            previousState = currentState;
            currentState = crouch;
            previousSprite = currentSprite;
        }
        public void toDead()
        {
            currentState = dead;
        }

        public void Update(float elapsed, GraphicsDeviceManager graphics)
        {
           actionStateFactor = currentState.Factor();
           powerupStateFactor = powerupState.Factor();       
           currentSprite = (MarioSprite)MarioFactory.MakeProduct(powerupStateFactor + actionStateFactor);      
           currentSprite.CollisionBox.Physics(new Vector2(MarioVec.X, MarioVec.Y-CollisionBox.Height), Vector2.Zero, Vector2.Zero);  
           currentSprite.Update(elapsed, direction);
           currentState.Update(graphics);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch);
        }
        public void FireballCommand()
        {
            currentState.FireballCommand();
        }
        public void UpCommand()
        {
            currentState.UpCommand();
        }

        public void DownCommand()
        {
            currentState.DownCommand();
        }

        public void LeftCommand()
        {
            currentState.LeftCommand();
        }

        public void RightCommand()
        {
            currentState.RightCommand();
        }
        public void StandardCommand()
        {
            powerupState = standard;
        }
        public void SuperCommand()
        {
            powerupState = super;
        }

        public void FireCommand()
        {
            powerupState = fire;
        }
        public void DeadCommand()
        {
            powerupState = standard;
            this.toDead();
        }
    }
}
