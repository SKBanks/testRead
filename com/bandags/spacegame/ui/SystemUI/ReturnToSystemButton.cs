using UnityEngine;

namespace com.bandags.spacegame.ui {
    public class ReturnToSystemButton : MonoBehaviour {
        public void ReturnToSystemButtonClicked() {
            GameEngine.Instance.GameSceneManager.LoadSystem();
        }
    }
}