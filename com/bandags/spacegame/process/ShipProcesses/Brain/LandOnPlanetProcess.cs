using System;
using System.Collections;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using UnityEngine;


namespace com.bandags.spacegame.process {
    public class LandOnPlanetProcess : Process {
        private readonly Ship _sourceShip;
        private readonly Planet _targetPlanet;
        private readonly Action _onShipLandedAction;

        public LandOnPlanetProcess(Ship sourceShip, Planet planet, Action onShipLanded) : base(ProcessType.LAND_ON_PLANET_PROCESS) {
            _sourceShip = sourceShip;
            _targetPlanet = planet;
            _onShipLandedAction = onShipLanded;
        }

        protected override IEnumerator Update() {
            yield return new MoveShipAndStopProcess(_sourceShip, _targetPlanet.transform.position).Run();
            Debug.Log($"Landing {_sourceShip.name} on {_targetPlanet.name}");
            yield return new ShrinkShipProcess(_sourceShip).Run();
            _onShipLandedAction?.Invoke();
        }
    }
}