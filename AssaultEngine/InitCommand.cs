using System;
using System.IO;
using System.IO.Compression;

namespace AssaultEngine
{
    public class InitCommand : Command
    {
        public InitCommand(string target) : base(target)
        {
        }

        public override void Run()
        {
            Console.WriteLine("Initializing {0}", Target);
            var tmp = Path.GetTempPath();
            var assaultTemp = $"{tmp}assault/";
            var projectTemp = $"{assaultTemp}{Path.GetFileNameWithoutExtension(Target)}";
            Console.WriteLine(projectTemp);
            Directory.CreateDirectory(assaultTemp);
            Directory.CreateDirectory(projectTemp);
            ZipFile.CreateFromDirectory(projectTemp, Target ?? throw new ArgumentNullException(nameof(Target)));
            // TODO: initialize sqlite, resources and ass-compatible version
            // TODO: zip project
            Directory.Delete(assaultTemp, recursive: true);
        }
    }
}