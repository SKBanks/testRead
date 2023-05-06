using System.Collections;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class AttackShipProcess : Process {
        private readonly Ship _sourceShip;
        private readonly Ship _targetShip;
        private Vector3 _targetVector;
        
        public AttackShipProcess(Ship sourceShip, Ship targetShip) : base(ProcessType.LAND_ON_PLANET_PROCESS) {
            _sourceShip = sourceShip;
            _targetShip = targetShip;
        }

        protected override IEnumerator Update() {
            Debug.Log($"Attacking {_targetShip.name}");
            yield return new MoveShipWithinWeaponRangeProcess(_sourceShip, _targetShip).Run();
        }
    }
}