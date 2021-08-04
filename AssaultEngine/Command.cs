using System;

namespace AssaultEngine
{
    public abstract class Command
    {
        internal readonly string Target;

        protected Command(string target)
        {
            Target = target;
        }

        public abstract void Run();
    }
}