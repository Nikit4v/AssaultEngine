using System;
using System.IO;
using System.IO.Compression;
using AssaultEngine.Models;
using System.Linq;

namespace AssaultEngine.Commands
{
    public class ShellCommand : Command
    {
        public ShellCommand(string target) : base(target)
        {
        }

        private void Display(string[] args, SubtitleContext db)
        {
            IQueryable<string[]> objects = args[1] switch
            {
                "styles" => from style in db.Styles select new[] {style.StyleName, style.Font.FontFamily},
                "rows" => from row in db.Rows select new[] {row.Actor},
                _ => throw new ArgumentException("Unknown type")
            };

            foreach (var s in objects)
            {
                Console.WriteLine(s[0] + "    " + s[1]);
            }
        }

        private void Create(string[] args, SubtitleContext db)
        {
            switch (args[1])
            {
                case "style":
                    var style = new Style();
                    Console.Write("Name: ");
                    style.StyleName = Console.ReadLine()?.Trim(); 
                    Console.Write("Font: ");
                    var searchingFont = Console.ReadLine()?.Trim();
                    try
                    {

                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Undefined font. Create new one?");
                        switch ((char)Console.ReadKey().Key)
                        {
                            case 'y':
                                break;
                            case 'n':
                                break;
                        }
                        throw;
                    }
                    style.Font = db.Fonts.First(font => font.FontName == searchingFont);
                    break;
            }
        }
        internal override void Run(TemporaryFilesManager manager)
        {
            var projectTemp = manager.CreateProjectDirectory(Path.GetFileNameWithoutExtension(Target));
            ZipFile.ExtractToDirectory(Target ?? throw new InvalidOperationException(), projectTemp);
            
            Console.CancelKeyPress += delegate
            {
                Console.ResetColor();
            };
            Console.BackgroundColor = ConsoleColor.Black;
            var run = true;
            using var db = new SubtitleContext(projectTemp + "/data.db");
            while (run)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("| Assault subtitle ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(Path.GetFileNameWithoutExtension(Target));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" at ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(manager.TemporaryDirectory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" |=> ");
                Console.ForegroundColor = ConsoleColor.Gray;
                var command = (Console.ReadLine() ?? "").Trim();
                switch (command.Split(' ')[0])
                {
                    case "exit":
                        run = false;
                        break;
                    case "display":
                        Display(command.Split(' '), db);
                        break;
                    case "create":
                        Create(command.Split(' '), db);
                        break;
                }
            }
        }
    }
}