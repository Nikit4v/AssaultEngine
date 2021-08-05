using System;
using System.IO;

namespace AssaultEngine
{
    internal class TemporaryExistsException: Exception
    {
        public TemporaryExistsException(string entry, bool isDirectory)
        {
            
        }
    }
    internal class TemporaryFilesManager
    {
        private const string TemporaryDirectoryName = "assault";
        public readonly string TemporaryDirectory = Path.Join(Path.GetTempPath(), TemporaryDirectoryName);
        public TemporaryFilesManager()
        {
            if (Directory.Exists(TemporaryDirectory))
            {
                Console.Error.WriteLine(
                    "Temporary directory already exists. Maybe another Assault instance is running?");
                throw new TemporaryExistsException(TemporaryDirectoryName, true);
            }

            Directory.CreateDirectory(TemporaryDirectory);
        }

        public TemporaryFilesManager(bool ignore)
        {
            if (!ignore)
            {
                if (Directory.Exists(TemporaryDirectory))
                {
                    Console.Error.WriteLine(
                        "Temporary directory already exists. Maybe another Assault instance is running?");
                    throw new TemporaryExistsException(TemporaryDirectoryName, true);
                }

                Directory.CreateDirectory(TemporaryDirectory);
            }
        }

        public string CreateProjectDirectory(string project)
        {
            var projectDirectory = Path.Join(TemporaryDirectory, project);
            Directory.CreateDirectory(projectDirectory);
            return projectDirectory;
        }

        public void Free()
        {
            Directory.Delete(TemporaryDirectory, true);
        }
        
        ~TemporaryFilesManager()
        {
            Free();
        }
    }
}