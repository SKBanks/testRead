using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    public class LauncherGameScene : IGameScene {
        public Scene Scene { get; private set; }
        public SceneType SceneType => SceneType.Launcher;

        public void Create() {
            Scene = SceneManager.GetActiveScene();
            GameEngine.Instance.QuestLibrary.LoadLibrary(GameEngine.Instance.QuestScriptableObjects);
        }

        public void OnSceneStart() { }
        public void OnSceneExit() { }
    }
}