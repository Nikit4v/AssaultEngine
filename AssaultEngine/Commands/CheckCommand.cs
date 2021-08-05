using System;

namespace AssaultEngine
{
    public class CheckCommand : Command
    {
        public CheckCommand(string target) : base(target)
        {
        }

        internal override void Run(TemporaryFilesManager manager)
        {
            Console.WriteLine("Checking {0}", this.Target);
        }
    }
}