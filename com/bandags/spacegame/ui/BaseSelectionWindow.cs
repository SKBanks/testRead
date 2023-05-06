using UnityEngine;
using UnityEngine.UI;

namespace com.bandags.spacegame.ui {
    public abstract class BaseSelectionWindow : MonoBehaviour {
        protected static void FlipButton(Button visibleButton, Button hiddenButton) {
            visibleButton.gameObject.SetActive(false);
            hiddenButton.gameObject.SetActive(true);
        }

        public bool IsWindowActive() {
            return gameObject.activeSelf;
        }
    }
}