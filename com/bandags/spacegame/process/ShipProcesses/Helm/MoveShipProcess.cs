using System.Collections;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class MoveShipProcess : Process {
        private HelmProperties Properties => _sourceShip.Helm.Properties;
        private readonly Ship _sourceShip;
        private bool _isClose;
        private const float Drag = .8f;
        private readonly Vector2 _targetAsVector2;
        
        public MoveShipProcess(Ship sourceShip, Vector3 targetPosition) : base(ProcessType.LAND_ON_PLANET_PROCESS) {
            _sourceShip = sourceShip;
            _targetAsVector2 = Math.Get2DVectorFrom3(targetPosition);
        }

        protected override IEnumerator Update() {
            while (!_isClose) {
                _isClose = MoveTowards(_targetAsVector2, 10.0f);    //Todo: Replace planetRadius with actual planet radius value (1/2 Scale)
                yield return new WaitForFixedUpdate();
            }
            Properties.Rigidbody2D.drag = 0;
        }

        public override void OnInterrupt() {
            Properties.Rigidbody2D.drag = 0;
        }

        private bool MoveTowards(Vector2 targetPosition, float planetRadius) {
            Properties.Rigidbody2D.drag = 0;
            var shipPosition = Math.Get2DVectorFrom3(_sourceShip.transform.position);
            var deltaPosition = targetPosition - shipPosition;
            var isClose = deltaPosition.magnitude < planetRadius;

            if (isClose) {
                //Debug.Log($"[{isClose}] Speed: {deltaVelocity.magnitude} | Distance: {deltaPosition.magnitude}");
                return true;
            }
            //Debug.Log($"[{isClose}] Speed: {deltaVelocity.magnitude} | Distance: {deltaPosition.magnitude}");

            var facing = Math.isFacing(_sourceShip.transform.position, Properties.ForwardVector, targetPosition, 0.8f);
            if (!isClose || !facing) {
                TurnTowards(targetPosition);
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
    }
}