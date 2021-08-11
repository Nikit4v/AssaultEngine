using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AssaultEngine.Models
{
    public enum TimingFunctions
    {
        Linear,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuint,
        EaseOutQuint,
        EaseInOutQuint,
        EaseInCirc,
        EaseOutCirc,
        EaseInOutCirc,
        EaseInElastic,
        EaseOutElastic,
        EaseInOutElastic,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInQuart,
        EaseOutQuart,
        EaseInOutQuart,
        EaseInExpo,
        EaseOutExpo,
        EaseInOutExpo,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
        EaseInBounce,
        EaseOutBounce,
        EaseInOutBounce
    }
    public class Animation
    {
        public int AnimationId { get; set; }
        public string AnimationName { get; set; }
        public int Start { get; set; } // From row start!
        public int End { get; set; }
        public TimingFunctions TimingFunction { get; set; }

        [NotMapped]
        public Vector2 PositionDelta
        {
            get => Serializers.StrToVec2(PositionDeltaStringProvider);
            set => PositionDeltaStringProvider = Serializers.Vec2ToStr(value);
        }

        public string PositionDeltaStringProvider { get; set; }
        public float RotateDelta { get; set; }
    }
}