using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class Collision
    {
        Mario mario;
        List<Sprite> sprites;
        public Collision(Mario mario, Scene scene)
        {
            this.mario = mario;
            this.sprites = scene.Sprites;
        }


        public void Update()
        {

            foreach (Sprite sprite in sprites)
            {
                foreach (Point p in sprite.CollisionBox.Cells)
                {
                    if (!(mario.CurrentState is MarioDead)){
                        if (mario.CollisionBox.Cells.Contains(p))
                        {
                            //Now we know that the sprite and mario occupy at least one of the same cells.
                            if (Intersect(mario.CollisionBox, sprite.CollisionBox))
                            {
                                //call.appropriate handler
                                if (sprite is BlockQuestionSprite || sprite is BlockBrickSprite || sprite is BlockUsedSprite ||
                                    sprite is BlockFloorSprite || sprite is BlockPyramidSprite || sprite is BlockHiddenSprite)
                                {
                                    
                                    if (sprite is BlockQuestionSprite && mario.CurrentState is MarioJumpingState)
                                    {
                                        sprite.alive = false;
                                        
                                    }
                                    mario.ToIdle();
                                    
                                }

                                else if (sprite is GoombaWalkingSprite)
                                {
                                    if (mario.CurrentState is MarioFallingState)
                                    {
                                        sprite.alive = false;
                                        mario.ToIdle();
                                    }

                                    else
                                    {
                                        mario.ToIdle();

                                        if (mario.PowerupState is MarioFire)
                                        {
                                            mario.SuperCommand();
                                        }

                                        else if (mario.PowerupState is MarioSuper)
                                        {
                                            mario.StandardCommand();
                                        }

                                        //Mario is standard
                                        else
                                        {
                                            mario.DeadCommand();
                                        }
                                    }
                                }

                                else if (sprite is FlowerSprite)
                                {
                                    if (mario.PowerupState is MarioSuper)
                                        mario.FireCommand();
                                }

                                else if (sprite is StarSprite)
                                {
                                    //Star Mario to be implemented later
                                }

                                else if (sprite is MushroomSprite)
                                {
                                    mario.SuperCommand();
                                }

                            }
                        }
                    }
                }
            }
        }

        public bool Intersect(CollisionBox a, CollisionBox b)
        {
            if (a.Max_X < b.Min_X || a.Min_X > b.Max_X)
                return false;
            if (a.Max_Y < b.Min_Y || a.Min_Y > b.Max_Y)
                return false;
            return true;
        }
    }
}

