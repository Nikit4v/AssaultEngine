using System;
using System.Linq;

namespace AssaultEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No command specified");
                return;
            }

            if (args.Length == 1)
            {
                Console.WriteLine("No subtitle specified");
                return;
            }

            Command command;
            switch (args[0])
            {
                case "init":
                    command = new InitCommand(args[1]);
                    break;
                case "check":
                    command = new CheckCommand(args[1]);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    return;
            }

            command.Run();
        }
    }
}