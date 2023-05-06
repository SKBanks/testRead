using UnityEngine;
namespace com.bandags.spacegame.utilities {
    public static class Vector2Extensions {
        public static Vector2 Add(this Vector2 vec, float value) {
            return new Vector2(vec.x + value, vec.y + value);
        }

        public static Vector2 SubtractFrom(this Vector2 vec, float value) {
            return new Vector2(value - vec.x, value - vec.y);
        }

        public static Vector2 Multiply(this Vector2 vec, float value) {
            return new Vector2(vec.x * value, vec.y * value);
        }
    }
}