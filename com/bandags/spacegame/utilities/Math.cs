using UnityEngine;
namespace com.bandags.spacegame.utilities {
    public static class Math {
        public const double PI = 3.14159265358979323846;
        public const double TO_RAD = PI / 180;
        public const double TO_DEG = 180 / PI;

        public static float DegreesToTurn(Vector2 one, Vector2 two) {
            return (float) TO_DEG *
                   Mathf.Acos(Mathf.Min(1.0f, Mathf.Max(-1.0f, Vector2.Dot(one.normalized, two.normalized))));
        }

        public static bool isFacing(Vector2 position, Vector2 forward, Vector2 target, float amount) {
            return Vector3.Dot(forward, (target - position).normalized) > amount;
        }

        public static bool areFacingSameDirection(Vector2 forward, Vector2 targetForward, float amount) {
            return Vector3.Dot(forward, targetForward.normalized) > amount;
        }

        public static bool IsObjectOnRight(Transform source, Vector3 targetVector) {
            return Vector3.Dot((targetVector - source.position), source.right) > 0;
        }

        public static Vector2 Get2DVectorFrom3(Vector3 vector3) {
            return new Vector2(vector3.x, vector3.y);
        }
    }
}