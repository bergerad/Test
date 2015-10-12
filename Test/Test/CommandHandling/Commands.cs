using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioCommand : ICommand
    {
        protected Mario receiver;
        protected MarioCommand(Mario receiver)
        {
            this.receiver = receiver;
        }
        public virtual void Execute() { }
    }

    public class UpCommand : MarioCommand
    {
        public UpCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.UpCommand();
        }
    }


    public class DownCommand : MarioCommand
    {
        public DownCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
           receiver.DownCommand();
        }
    }
    public class LeftCommand : MarioCommand
    {
        public LeftCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.LeftCommand();
        }
    }
    public class RightCommand : MarioCommand
    {
        public RightCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.RightCommand();
        }
    }
    public class FireballCommand : MarioCommand
    {
        public FireballCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            //receiver.UpCommand();
            System.Console.WriteLine("Fireball command");
        }
    }
    public class StandardCommand : MarioCommand
    {
        public StandardCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.StandardCommand();
        }
    }

    public class SuperCommand : MarioCommand
    {
        public SuperCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.SuperCommand();
        }
    }

    public class FireCommand : MarioCommand
    {
        public FireCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.FireCommand();
        }
    }
    public class DeadCommand : MarioCommand
    {
        public DeadCommand(Mario receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.DeadCommand();
        }
    }
    public class ResetCommand: ICommand
    {
        Game1 receiver;
        public ResetCommand(Game1 receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.ResetCommand();
        }
    }
    public class PauseCommand: ICommand
    {
        Game1 receiver;
        public PauseCommand(Game1 receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()
        {
            receiver.PauseCommand();
        }
    }



}
  