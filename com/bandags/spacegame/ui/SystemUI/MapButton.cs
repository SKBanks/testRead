using UnityEngine;

namespace com.bandags.spacegame.ui {
    public class MapButton : MonoBehaviour {
        public void MapButtonClicked() {
            GameEngine.Instance.GameSceneManager.LoadMap();
        }
    }
}