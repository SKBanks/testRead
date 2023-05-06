using System.Collections;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class MoveShipWithinWeaponRangeProcess : Process {
        private HelmProperties Properties => _sourceShip.Helm.Properties;
        private bool _isClose;
        private const float Drag = .8f;

        private readonly Ship _sourceShip;
        private readonly Ship _targetShip;

        public MoveShipWithinWeaponRangeProcess(Ship sourceShip, Ship targetShip) : base(ProcessType.LAND_ON_PLANET_PROCESS) {
            _sourceShip = sourceShip;
            _targetShip = targetShip;
        }

        protected override IEnumerator Update() {
            while (_sourceShip.CanAttackShip(_targetShip)) {
                MoveTowards(_targetShip.transform.position, _sourceShip.Tactical.HardpointManager.GetMaxWeaponRange() * .5f);
                yield return new WaitForFixedUpdate();
            }
            Properties.Rigidbody2D.drag = 0;
        }
        
        public override void OnInterrupt() {
            Properties.Rigidbody2D.drag = 0;
        }

        private bool MoveTowards(Vector2 targetPosition, float weaponRadius) {
            Properties.Rigidbody2D.drag = 0;
            var shipPosition = Math.Get2DVectorFrom3(_sourceShip.transform.position);
            var deltaPosition = targetPosition - shipPosition;
            
            //Always face target
            TurnTowards(targetPosition);

            //If close, dont accelerate
            if (deltaPosition.magnitude < weaponRadius) {
                return true;
            }
            
            if (Math.isFacing(_sourceShip.transform.position, Properties.ForwardVector, deltaPosition, 0.8f)) {
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