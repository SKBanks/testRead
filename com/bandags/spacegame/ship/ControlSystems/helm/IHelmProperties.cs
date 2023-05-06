using UnityEngine;

namespace com.bandags.spacegame.ship {
    public interface IHelmProperties {
        Rigidbody2D Rigidbody2D { get; }
        Vector2 ForwardVector { get; }
        Vector2 Velocity { get; }
        float Speed { get; }
        float Mass { get; set; }
        float TurnRate { get; }
        float Acceleration { get; }
        float DeltaThrust { get; }
        float DeltaTurnRate { get; }
        void SetBaseValues(int thrustForce, int steeringForce, int baseMass, int cargoSize);
    }
}