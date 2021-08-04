using System;

namespace AssaultEngine
{
    public class CheckCommand : Command
    {
        public CheckCommand(string target) : base(target)
        {
        }

        public override void Run()
        {
            Console.WriteLine("Checking {0}", this.Target);
        }
    }
}