using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MarioGame
{
    public class Scene
    {
        int screenWidth;
        int screenHeight;
        Texture2D backgroundTexture;

        Game1 game;
        SpriteBatch spriteBatch;
        IController keyboardCont;
        IController gamePadCont;
        XmlReader reader;
        BlockFactory blockFactory;
        ItemFactory itemFactory;
        EnemyFactory enemyFactory;
        Mario mario;
        List<Sprite> sprites;
        Collision collision;
        public List<Sprite> Sprites { get { return sprites; } set { sprites = value; } }
        public Scene(Game1 game)
        {
            this.game = game;
        }
        public void Pause()
        {

        }
        public void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures. 

            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            backgroundTexture = game.Content.Load<Texture2D>("SMSearlysky");

            reader = XmlReader.Create("map.xml");

            sprites = new List<Sprite>();

            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            blockFactory = new BlockFactory(game);
            itemFactory = new ItemFactory(game);
            enemyFactory = new EnemyFactory(game);
            Parse(reader);

            keyboardCont = new KeyboardController(game, mario);
            gamePadCont = new GamePadController(game, mario);
            collision = new Collision(mario, this);
            MakeFloor();
            // TODO: use this.Content to load your game content here
        }

        private void Parse(XmlReader reader)
        {
            int type;
            int posX;
            int posY;
            String str;
            Sprite sprite;
            Vector2 vec;
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case "block":
                        {
                            if (reader.IsStartElement())
                            {
                                str = reader.GetAttribute("type");
                                type = Convert.ToInt32(str);
                                str = reader.GetAttribute("posX");
                                posX = Convert.ToInt32(str);
                                posX *= 16;
                                str = reader.GetAttribute("posY");
                                posY = Convert.ToInt32(str);
                                posY *= 16;
                                vec = new Vector2(posX, posY);
                                sprite = blockFactory.MakeProduct(type);
                                sprite.CollisionBox.Physics(vec, Vector2.Zero, Vector2.Zero);
                                System.Console.WriteLine("newblock");
                                System.Console.WriteLine("min =" + sprite.CollisionBox.Min);
                                System.Console.WriteLine("max =" + sprite.CollisionBox.Max);
                                //System.Console.WriteLine(sprite.CollisionBox.Cells[0]);
                                //System.Console.WriteLine(sprite.CollisionBox.Cells[1]);
                                //System.Console.WriteLine(sprite.CollisionBox.Cells[2]);
                                //System.Console.WriteLine(sprite.CollisionBox.Cells[3]);
                                sprites.Add(sprite);

                                //check for coins and items
                            }
                            break;
                        }
                    case "mario":
                        {
                            if (reader.IsStartElement())
                            {
                                str = reader.GetAttribute("posX");
                                posX = Convert.ToInt32(str);
                                str = reader.GetAttribute("posY");
                                posY = Convert.ToInt32(str);
                                mario = new Mario(game, posX, posY);
                            }
                            break;
                        }
                    case "item":
                        {
                            if (reader.IsStartElement())
                            {
                                str = reader.GetAttribute("type");
                                type = Convert.ToInt32(str);
                                sprite = itemFactory.MakeProduct(type);
                                str = reader.GetAttribute("posX");
                                posX = Convert.ToInt32(str);
                                posX *= 16;
                                str = reader.GetAttribute("posY");                              
                                posY = Convert.ToInt32(str);
                                posY *= 16;
                                vec = new Vector2(posX, posY);
                                sprite.CollisionBox.Physics(vec,Vector2.Zero, Vector2.Zero);
                               
                                sprites.Add(sprite);
                            }
                            break;
                        }
                    case "enemy":
                        {
                            if (reader.IsStartElement())
                            {
                                str = reader.GetAttribute("type");
                                type = Convert.ToInt32(str);
                                sprite = enemyFactory.MakeProduct(type);
                                str = reader.GetAttribute("posX");
                                posX = Convert.ToInt32(str);
                                posX *= 16;
                                str = reader.GetAttribute("posY");
                                posY = Convert.ToInt32(str);
                                posY *= 16;
                                vec = new Vector2(posX, posY);
                                sprite.CollisionBox.Physics(vec, Vector2.Zero, Vector2.Zero);
                                sprites.Add(sprite);
                            }
                            break;
                        }

                }

            }
        }
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            keyboardCont.UpdateInput();
            gamePadCont.UpdateInput();
            foreach (Sprite sprite in sprites)
            {
                sprite.Update(elapsed, 0);
            }
            mario.Update(elapsed, game.graphicsdevice);
            collision.Update();
           // System.Console.WriteLine("MARIO");
            //System.Console.WriteLine(mario.CollisionBox.Cells[0]);
            //System.Console.WriteLine(mario.CollisionBox.Cells[1]);
            //System.Console.WriteLine(mario.CollisionBox.Cells[2]);
            //System.Console.WriteLine(mario.CollisionBox.Cells[3]);
            
        }

        public void Draw(GameTime gameTime)
        {
            
          //  game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null);
            DrawScenery();
            DrawVert(new Rectangle(0, 0, 16, 480), spriteBatch, 1, Color.Green);
            DrawHor(new Rectangle(0, 0, 800, 0), spriteBatch, 1, Color.Green);
            foreach (Sprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
            mario.Draw(spriteBatch);
            
            spriteBatch.End();
        }

        public void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

        }

        private void MakeFloor()
        {
            Sprite sprite;
            Vector2 vec;
            for (int i = 0; i <= 50; i++)
            {
                sprite = blockFactory.MakeProduct(3);
                vec = new Vector2((float)i*16, (float)464);
                sprite.CollisionBox.Physics(vec, Vector2.Zero, Vector2.Zero);
                sprites.Add(sprite);
            }
        }

        public void DrawVert(Rectangle rectangleToDraw, SpriteBatch spriteBatch, int thicknessOfBorder, Color borderColor)
        {
            Texture2D pixel;
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            //   spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            for (int i = 1; i <= 50; i++)
            {
               
              //  spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);
                
                // Draw right line
                spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X  + rectangleToDraw.Width-thicknessOfBorder),rectangleToDraw.Y,thicknessOfBorder, rectangleToDraw.Height), borderColor);
                rectangleToDraw.X += 16;
            }
        }


        public void DrawHor(Rectangle rectangleToDraw, SpriteBatch spriteBatch, int thicknessOfBorder, Color borderColor)
        {
            Texture2D pixel;
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            for (int i = 1; i <= 30; i++)
            {
                spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y+(16*i)-1, rectangleToDraw.Width, thicknessOfBorder), borderColor);


                //// Draw bottom line
                //spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                //                                rectangleToDraw.Y+(16*i) + rectangleToDraw.Height - thicknessOfBorder,
                //                                rectangleToDraw.Width,
                //                                thicknessOfBorder), borderColor);

            }
        }


    }
}