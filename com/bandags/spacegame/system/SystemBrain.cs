using System;
using com.bandags.spacegame.process;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.system {
    [Serializable]
    public class SystemBrain {
        private const int _delayBetweenAssesments = 10;
        public IProcessManager ShipManagementProcessManager;

        private SystemLayer _systemLayer;
        public SystemBrain(SystemLayer systemLayer) {
            _systemLayer = systemLayer;
            ShipManagementProcessManager = new ProcessManager(_systemLayer);
        }
        
        public void ResetSystem() {
            ShipManagementProcessManager.Interrupt();
            ShipManagementProcessManager.RunProcess(new AssessShipsInSystemRecursiveProcess(_systemLayer, _delayBetweenAssesments));
        }

        public void AddShipToSystem(Ship targetShip) {
            _systemLayer.AddShip(targetShip);
        }

        public void RemoveShipFromSystem(Ship targetShip) {
            _systemLayer.Ships.Remove(targetShip);
            GameObject.Destroy(targetShip.gameObject);
        }
    }
}