using System;
using com.bandags.spacegame.process;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    [Serializable]
    public class TacticalAI : ITacticalAI {
        [field: SerializeReference] private ProcessManager FireAtTargetProcessManager { get; }
        [field: SerializeReference] private FireAtTargetProcess FireAtTargetProcess { get; set; }
        private readonly Ship _ship;        
        public TacticalAI(Ship ship) {
            _ship = ship;
            FireAtTargetProcessManager = new ProcessManager(ship);
        }

        public void AttackTarget(Ship targetShip, IHelmAI helmAI) {
            FireAtTargetProcessManager.RunProcess(FireAtTargetProcess = new FireAtTargetProcess(_ship.Tactical.HardpointManager, _ship.Sensors, this));
        }

        public void Interrupt() {
            FireAtTargetProcessManager.Interrupt();
        }
    }
}