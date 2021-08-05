using System;
using System.Linq;
using AssaultEngine.Commands;


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
                case "shell":
                    command = new ShellCommand(args[1]);
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    return;
            }

            TemporaryFilesManager temporaryFilesManager;

            try
            {
                temporaryFilesManager = new TemporaryFilesManager();

                command.Run(temporaryFilesManager);
                temporaryFilesManager.Free();
            }
            catch (TemporaryExistsException)
            {
                var run = true;
                Console.WriteLine("Continue?");
                while (run)
                {
                    var key = Console.ReadKey().KeyChar;
                    Console.Write("\n");
                    switch (key)
                    {
                        case 'y':
                            temporaryFilesManager = new TemporaryFilesManager(true);
                            command.Run(temporaryFilesManager);
                            temporaryFilesManager.Free();
                            run = false;
                            break;
                        case 'n':
                            run = false;
                            return;
                        default:
                            Console.WriteLine("Incorrect symbol. Try again");
                            break;
                    }
                }
            }
        }
    }
}