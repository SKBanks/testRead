using System.Collections;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class AssessShipsInSystemRecursiveProcess : Process {
        private readonly SystemLayer _systemLayer;
        private readonly int _delayInSeconds;
        public AssessShipsInSystemRecursiveProcess(SystemLayer systemLayer, int delayInSeconds) : base(ProcessType.LOAD_SHIPS_INTO_SYSTEM_PROCESS) {
            _systemLayer = systemLayer;
            _delayInSeconds = delayInSeconds;
        }
        protected override IEnumerator Update() {
            yield return new LoadShipsIntoSystemProcess(_systemLayer).Run();
            yield return null;
            yield return new WaitForSeconds(_delayInSeconds);
            yield return SetNext(new AssessShipsInSystemRecursiveProcess(_systemLayer, _delayInSeconds));
        }
    }
}