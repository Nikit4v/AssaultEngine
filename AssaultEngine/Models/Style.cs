using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AssaultEngine.Models
{
    public enum RenderTypes
    {
        Perspective,
        Isometric,
        Plane
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
    
    public class Style
    {
        // Style service information. But it used only in editors and error messages ;)
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        
        // Text modification
        public Font Font { get; set; }

        [NotMapped]
        public Vector3 Rotate {
            get => Serializers.StrToVec3(RotateStringProvider);
            set => RotateStringProvider = Serializers.Vec3ToStr(value);
        }

        public string RotateStringProvider { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        
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
        public Material Material { get; set; }
        
        // Animations
        public List<Animation> Animations { get; set; }
    }
}