using System.Numerics;

namespace AssaultEngine
{
    public class Serializers
    {
        public static string Vec2ToStr(Vector2 vec)
        {
            return $"{vec.X};{vec.Y}";
        }

        public static Vector2 StrToVec2(string str)
        {
            var rawNumbers = str.Split(';');
            return new Vector2()
            {
                X = float.Parse(rawNumbers[0]),
                Y = float.Parse(rawNumbers[1])
            };
        }

        public static string Vec3ToStr(Vector3 vec)
        {
            return $"{vec.X};{vec.Y}{vec.Z}";
        }

        public static Vector3 StrToVec3(string str)
        {
            var rawNumbers = str.Split(';');
            var vec = new Vector3
            {
                X = float.Parse(rawNumbers[0]),
                Y = float.Parse(rawNumbers[1]),
                Z = float.Parse(rawNumbers[2])
            };
            return vec;
        }
    }
}