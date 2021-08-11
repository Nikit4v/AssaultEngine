// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AssaultEngine.Models
{
    public class Shader
    {
        public int ShaderId { get; set; }
        public string ShaderName { get; set; }
        public ShaderType ShaderType { get; set; }
        public bool IsProperty { get; set; }
        public string ShaderPath { get; set; }
    }

    public enum ShaderType
    {
        Internal,
        External
    }
}