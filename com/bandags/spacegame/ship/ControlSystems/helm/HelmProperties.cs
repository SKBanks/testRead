using UnityEngine;

namespace com.bandags.spacegame.ship {
    public class HelmProperties : IHelmProperties {
        public Rigidbody2D Rigidbody2D => _ship.Rigidbody2D;
        public Vector2 ForwardVector => _ship.transform.up;
        public Vector2 Velocity => Rigidbody2D.velocity;
        public float Speed => Rigidbody2D.velocity.magnitude;
        public float Mass {
            get => Rigidbody2D.mass;
            set => Rigidbody2D.mass = value;
        }
        public float TurnRate => _baseSteeringForce / Mass;
        public float Acceleration => _baseThrustForce / Mass;
        public float DeltaThrust => _baseThrustForce * Time.deltaTime;
        public float DeltaTurnRate => TurnRate * Time.deltaTime;

        private readonly Ship _ship;
        private int _baseThrustForce;
        private int _baseSteeringForce;
        public HelmProperties(Ship ship) {
            _ship = ship;
        }
        public void SetBaseValues(int thrustForce, int steeringForce, int baseMass, int cargoSize) {
            _baseThrustForce = thrustForce;
            _baseSteeringForce = steeringForce;
            Mass = baseMass + cargoSize;
        }
    }
}