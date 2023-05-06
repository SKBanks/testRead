using com.bandags.spacegame.process;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    public class MainMenuGameScene : IGameScene {
        private const string MainMenuSceneName = "MainMenuScene";
        private const string MainMenuCanvasName = "MainMenuCanvas";
        public Scene Scene { get; private set; }
        public SceneType SceneType => SceneType.MainMenu;
        private GameObject MainMenuCanvas;
        
        public void Create() {
            GameEngine.Instance.ProcessManager.RunProcess(new LoadSceneProcess(MainMenuSceneName, scene => {
                Scene = scene;
                MainMenuCanvas = GameObject.Find(MainMenuCanvasName);
                OnSceneStart();
            }));
        }
        public void OnSceneStart() {
            SceneManager.SetActiveScene(Scene);
            MainMenuCanvas?.SetActive(true);
        }
        public void OnSceneExit() {
            MainMenuCanvas?.SetActive(false);
        }
    }
}