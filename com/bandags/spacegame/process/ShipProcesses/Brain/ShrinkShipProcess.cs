using System.Collections;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class ShrinkShipProcess : Process {
        private readonly Ship _sourceShip;

        public ShrinkShipProcess(Ship sourceShip) : base(ProcessType.SHRINK_SHIP_PROCESS) {
            _sourceShip = sourceShip;
        }

        protected override IEnumerator Update() {
            const float shrinkTime = 0.5f;
            var targetScale = new Vector3(5, 5, 1);
            var shipToShrink = _sourceShip.gameObject;
            iTween.ScaleTo(shipToShrink, targetScale, shrinkTime);
            yield return new WaitForSeconds(shrinkTime + 0.1f);
        }
    }
}