using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.ui {
    public class HyperspaceButton : MonoBehaviour {
        public void HyperspaceButtonClicked() {
            var targetSystemType = SystemType.Sol;
            if (GameEngine.Instance.Galaxy.ActiveSystem.SystemLayerData.SystemType == SystemType.Sol) {
                targetSystemType = SystemType.Deneb;
            }
            GameEngine.Instance.CurrentPlayer.CurrentShip.Helm.HelmAI.JumpToSystem(targetSystemType);
        }
    }
}