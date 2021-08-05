using System;
using System.IO;
using System.IO.Compression;
using AssaultEngine.Models;
using System.Linq;

namespace AssaultEngine.Commands
{
    class CreateOptions
    {
        
    }
    public class ShellCommand : Command
    {
        public ShellCommand(string target) : base(target)
        {
        }

        private void Display(string[] args, SubtitleContext db)
        {
            switch (args[1])
            {
                case "styles":
                    var styles = from style in db.Styles
                                                select new[] { style.StyleName, style.DefaultFont.FontFamily };
                    foreach (var s in styles)
                    {
                        Console.WriteLine(s[0] + "    " + s[1]);
                    }
                    break;
            }
        }

        private void Create(string[] args, SubtitleContext db)
        {
            switch (args[1])
            {
                case "style":
                    var style = new Style();
                    break;
            }
        }
        internal override void Run(TemporaryFilesManager manager)
        {
            var projectTemp = manager.CreateProjectDirectory(Path.GetFileNameWithoutExtension(Target));
            var oldForegroundColor = Console.ForegroundColor;
            var oldBackgroundColor = Console.BackgroundColor;
            ZipFile.ExtractToDirectory(Target ?? throw new InvalidOperationException(), projectTemp);
            
            Console.CancelKeyPress += delegate
            {
                Console.ForegroundColor = oldForegroundColor;
                Console.BackgroundColor = oldBackgroundColor;
            };
            Console.BackgroundColor = ConsoleColor.Black;
            var run = true;
            using (var db = new SubtitleContext(projectTemp + "/data.db")) while (run)
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
                var command = Console.ReadLine() ?? "".Trim();
                switch (command.Split(' ')[0])
                {
                    case "exit":
                        run = false;
                        break;
                    case "display":
                        Display(command.Split(' '), db);
                        break;
                }
            }
        }
    }
}