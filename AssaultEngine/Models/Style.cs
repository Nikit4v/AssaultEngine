using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace AssaultEngine.Models
{
    public enum RenderTypes
    {
        Perspective,
        Isometric,
        Ignore3D
    }

    public enum BorderTypes
    {
        TextAround,
        TextInner,
        RectangleMinimalDistance,
        RectangleMaximumDistance
    }

    public enum VerticalAlignment
    {
        Top,
        Center,
        Bottom
    }

    public enum HorizontalAlignment
    {
        Left,
        Center,
        Right
    }
    
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class Style
    {
        // Style service information. But it used only in editors and error messages ;)
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        
        // Text modification
        public Font DefaultFont { get; set; }
        public bool IsItalic { get; set; }
        public bool IsBold { get; set; }
        public bool IsUnderlined { get; set; }
        public bool IsStrikeout { get; set; }
        public BorderTypes BorderType { get; set; }
        public float BorderSize { get; set; }
        public float ShadowSize { get; set; }
        [NotMapped]
        public Vector2 ShadowOffset
        {
            get => Serializers.StrToVec2(ShadowOffsetStringProvider);
            set => ShadowOffsetStringProvider = Serializers.Vec2ToStr(value);
        }

        public string ShadowOffsetStringProvider { get; set; }

        // Linear transformations, this works only for "image plane"
        public float Rotate { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        // TODO: Add another linear transformations
        
        // Colors
        [NotMapped]
        public Vector3 TextColor {
            get => Serializers.StrToVec3(TextColorStringProvider);
            set => TextColorStringProvider = Serializers.Vec3ToStr(value);
        }
        [NotMapped]
        public Vector3 BorderColor {
            get => Serializers.StrToVec3(BorderColorStringProvider);
            set => BorderColorStringProvider = Serializers.Vec3ToStr(value);
        }
        [NotMapped]
        public Vector3 ShadowColor {
            get => Serializers.StrToVec3(ShadowColorStringProvider);
            set => ShadowColorStringProvider = Serializers.Vec3ToStr(value);
        }

        public string TextColorStringProvider { get; set; }
        public string BorderColorStringProvider { get; set; }
        public string ShadowColorStringProvider { get; set; }
        

        // 3D Options
        public RenderTypes RenderType { get; set; }
        public List<Shader> Shaders { get; set; }
        public Shader DefaultShader { get; set; }
        public List<Material> Materials { get; set; }
        public Material DefaultMaterial { get; set; }
        
        // Animations
        public List<Animation> Animations { get; set; }
    }
}