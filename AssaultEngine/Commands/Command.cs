namespace AssaultEngine.Commands
{
    public abstract class Command
    {
        internal readonly string Target;

        protected Command(string target)
        {
            Target = target;
        }

        internal abstract void Run(TemporaryFilesManager manager);
    }
}