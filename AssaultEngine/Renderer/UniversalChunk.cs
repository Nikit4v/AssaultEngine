using System.Collections.Generic;
using System.Numerics;
using AssaultEngine.Models;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace AssaultEngine.Renderer
{
    public struct ShaderInfo
    {
        public Shader Shader { get; set; }
        public Dictionary<string, dynamic> Arguments { get; set; }
    }
    public class UniversalChunk
    {
        public Vector3 Position { get; set; }
        
        public Font Font { get; set; }
        
        public Vector3 Rotate { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        
        public Vector4 TextColor { get; set; }
        public Vector4 BorderColor { get; set; }
        public Vector4 ShadowColor { get; set; }
        
        public RenderTypes RenderType { get; set; }
        public List<ShaderInfo> Shaders { get; set; }
        public Material Material { get; set; }
        public Figure Figure { get; set; }
        public string Text { get; set; }
    }

    public class Figure
    {
        public static Figure Vertex()
        {
            var vertex = new Figure
            {
                Vertexes = System.Array.Empty<Vector3>()
            };
            return vertex;
        }

        public Vector3[] Vertexes { get; set; }
    }
}