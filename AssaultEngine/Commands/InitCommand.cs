using System;
using System.IO;
using System.IO.Compression;

namespace AssaultEngine.Commands
{
    public class InitCommand : Command
    {
        public InitCommand(string target) : base(target) {}

        internal override void Run(TemporaryFilesManager manager)
        {
            Console.WriteLine("Initializing {0}", Target);
            var projectTemp = manager.CreateProjectDirectory(Path.GetFileNameWithoutExtension(Target));
            using (var db = new Models.SubtitleContext(Path.Join(projectTemp, "data.db")))
            {
                db.Database.EnsureCreated();
            }
            ZipFile.CreateFromDirectory(projectTemp, Target ?? throw new ArgumentNullException(nameof(Target)));
            Directory.Delete(projectTemp, true);
        }
    }
}