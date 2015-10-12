using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MarioGame;

namespace MarioGame
{
    class KeyboardController : IController
    {
        private Dictionary<int, ICommand> keyBoardCommands = new Dictionary<int, ICommand>();
        //Game1 game;
        KeyboardState oldState;

        public KeyboardController(Game1 game, Mario mario)
        {
            oldState = Keyboard.GetState(PlayerIndex.One);
            //action state keys
            keyBoardCommands.Add((int)Keys.Up, new UpCommand(mario));
            keyBoardCommands.Add((int)Keys.W, new UpCommand(mario));
            keyBoardCommands.Add((int)Keys.Down, new DownCommand(mario));
            keyBoardCommands.Add((int)Keys.S, new DownCommand(mario));
            keyBoardCommands.Add((int)Keys.Left, new LeftCommand(mario));
            keyBoardCommands.Add((int)Keys.A, new LeftCommand(mario));
            keyBoardCommands.Add((int)Keys.Right, new RightCommand(mario));
            keyBoardCommands.Add((int)Keys.D, new RightCommand(mario));
            keyBoardCommands.Add((int)Keys.Space, new FireballCommand(mario));
           

            //power up state keys
            keyBoardCommands.Add((int)Keys.Y, new StandardCommand(mario));
            keyBoardCommands.Add((int)Keys.U, new SuperCommand(mario));
            keyBoardCommands.Add((int)Keys.I, new FireCommand(mario));
            keyBoardCommands.Add((int)Keys.O, new DeadCommand(mario));
            //block keys
            //reset command
            keyBoardCommands.Add((int)Keys.R, new ResetCommand(game));
            keyBoardCommands.Add((int)Keys.P, new PauseCommand(game));
            

        }

        public void UpdateInput()
        {
            GamePadState gps = GamePad.GetState(PlayerIndex.One);
            if (gps.IsConnected)
            {
                if(gps.IsButtonDown(Buttons.DPadLeft))
                {
                    keyBoardCommands[(int)Buttons.DPadLeft].Execute();
                }
                if (gps.IsButtonDown(Buttons.DPadRight))
                {
                    keyBoardCommands[(int)Buttons.DPadRight].Execute();
                }
                if (gps.IsButtonDown(Buttons.DPadUp))
                {
                    keyBoardCommands[(int)Buttons.DPadUp].Execute();
                }
                if (gps.IsButtonDown(Buttons.DPadDown))
                {
                    keyBoardCommands[(int)Buttons.DPadDown].Execute();
                }
                if (gps.IsButtonDown(Buttons.A))
                {
                    keyBoardCommands[(int)Buttons.A].Execute();
                }
            }
            KeyboardState state = Keyboard.GetState(PlayerIndex.One);
            Keys[] keys = state.GetPressedKeys();
            foreach (Keys key in keys)
            {
                if (!oldState.IsKeyDown(key))
                {
                    if (keyBoardCommands.ContainsKey((int)key))
                        keyBoardCommands[(int)key].Execute();
                }

            }
            oldState = state;
        }
    }
}
