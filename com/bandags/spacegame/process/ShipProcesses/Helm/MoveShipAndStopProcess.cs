using System.Collections;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class MoveShipAndStopProcess : Process {
        private HelmProperties Properties => _sourceShip.Helm.Properties;
        private const float MaxFinalSpeed = 3.25f;  //Todo: Will need adjustment
        private readonly Ship _sourceShip;
        private bool _isClose;
        private const float Drag = .8f;
        private readonly Vector2 _targetAsVector2;
        
        public MoveShipAndStopProcess(Ship sourceShip, Vector3 targetPosition) : base(ProcessType.LAND_ON_PLANET_PROCESS) {
            _sourceShip = sourceShip;
            _targetAsVector2 = Math.Get2DVectorFrom3(targetPosition);
        }

        protected override IEnumerator Update() {
            while (!_isClose) {
                _isClose = MoveTowards(_targetAsVector2, Vector2.zero, 25.0f, MaxFinalSpeed);    //Todo: Replace planetRadius with actual planet radius value (1/2 Scale)
                yield return new WaitForFixedUpdate();
            }

            _sourceShip.Rigidbody2D.velocity = Vector2.zero;
        }
        
        public override void OnInterrupt() {
            Properties.Rigidbody2D.drag = 0;
        }

        private bool MoveTowards(Vector2 targetPosition, Vector2 targetVelocityOnArrival, float planetRadius, float maxSpeed) {
            Properties.Rigidbody2D.drag = 0;
            var shipPosition = Math.Get2DVectorFrom3(_sourceShip.transform.position);
            var deltaPosition = targetPosition - shipPosition;
            var deltaVelocity = targetVelocityOnArrival - Properties.Velocity;
            var isClose = deltaPosition.magnitude < planetRadius;

            if (isClose && deltaVelocity.magnitude < maxSpeed) {
                //Debug.Log($"[{isClose}] Speed: {deltaVelocity.magnitude} | Distance: {deltaPosition.magnitude}");
                return true;
            }
            //Debug.Log($"[{isClose}] Speed: {deltaVelocity.magnitude} | Distance: {deltaPosition.magnitude}");

            var stoppingPoint = StoppingPoint(targetVelocityOnArrival);
            deltaPosition = targetPosition - stoppingPoint;
            deltaPosition += shipPosition;

            var facing = Math.isFacing(_sourceShip.transform.position, Properties.ForwardVector, deltaPosition, 0.8f);
            if (!isClose || !facing) {
                TurnTowards(deltaPosition);
            }

            if (facing) {
                Properties.Rigidbody2D.drag = Drag;
                Properties.Rigidbody2D.AddForce(Properties.ForwardVector * Mathf.Clamp(Properties.DeltaThrust, -Properties.DeltaThrust, Properties.DeltaThrust));
            }

            return false;
        }
        
        private void TurnTowards(Vector2 target) {
            var degreesToTurn = Mathf.Max(Math.DegreesToTurn(_sourceShip.transform.up, target), 1);
            var turnRate = Mathf.Abs(degreesToTurn) < Properties.DeltaTurnRate ? degreesToTurn : Properties.DeltaTurnRate;

            _sourceShip.transform.Rotate(0, 0,
                Math.IsObjectOnRight(_sourceShip.transform, target)
                    ? Mathf.Clamp(-turnRate, -Properties.DeltaTurnRate, Properties.DeltaTurnRate)
                    : Mathf.Clamp(turnRate, -Properties.DeltaTurnRate, Properties.DeltaTurnRate));
        }

        private Vector2 StoppingPoint(Vector2 targetVelocity) {
            var position = Math.Get2DVectorFrom3(_sourceShip.transform.position);
            var velocity = Properties.Velocity - targetVelocity;
            var speed = velocity.magnitude;
            var degreesToTurn = Math.DegreesToTurn(-velocity, Properties.ForwardVector);
            var stopDistance = speed * (degreesToTurn / Properties.TurnRate);
            stopDistance += .5f * speed * speed / Properties.Acceleration;
            return position + velocity.normalized.Multiply(stopDistance);
        }
    }
}