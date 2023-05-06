using UnityEngine;

namespace com.bandags.spacegame.ui {
    public class CloseMapButton : MonoBehaviour {
        public void CloseMapButtonClicked() {
            GameEngine.Instance.GameSceneManager.HideMap();
        }
    }
}