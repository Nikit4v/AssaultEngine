using System.Collections.Generic;
using System.Numerics;

namespace AssaultEngine.Renderer
{
    public class InternalShader
    {
        public string Name;

        public delegate dynamic Render(Vector2 position, Dictionary<string, dynamic> args);
        
    }
}