using System;
using System.Numerics;
using AssaultEngine.Models;
using AssaultEngine.Renderer;

namespace AssaultEngine.Commands
{
    public class CheckCommand : Command
    {
        public CheckCommand(string target) : base(target) {}

        internal override void Run(TemporaryFilesManager manager)
        {
            Console.WriteLine("Checking {0}", this.Target);
            var chunk = new UniversalChunk { Figure = Figure.Vertex() };
            var figureVertexes = chunk.Figure.Vertexes;
            chunk.Figure.Vertexes = new Vector3[] { };
            Console.Write("Actions finished");
        }
    }
}