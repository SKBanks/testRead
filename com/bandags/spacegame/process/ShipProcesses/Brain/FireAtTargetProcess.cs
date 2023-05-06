using System.Collections;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class FireAtTargetProcess : Process {
        private readonly IHardpointManager _hardpointManager;
        private readonly ISensors _sensors;
        private readonly ITacticalAI _tactical;
        public FireAtTargetProcess(IHardpointManager hardpointManager, ISensors sensors, ITacticalAI tactical) : base(ProcessType.FIRE_AT_TARGET_PROCESS) {
            _hardpointManager = hardpointManager;
            _sensors = sensors;
            _tactical = tactical;
            Debug.Log($"Attacking: {_sensors.HostileTarget}");
        }
        protected override IEnumerator Update() {
            if (_sensors.HostileTarget == null) {
                _tactical.Interrupt();
                Debug.Log($"Lost Target");
                yield break;
            }
            _hardpointManager.FireWeapons(_sensors.HostileTarget);
            //Debug.Log($"Attacking: {_sensors.HostileTarget}");
            yield return null;
            yield return SetNext(this);
        }
    }
}