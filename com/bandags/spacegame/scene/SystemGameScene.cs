//#define CREATE_SYSTEM_LAYER
using com.bandags.spacegame.data;
using com.bandags.spacegame.process;
using com.bandags.spacegame.ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    public class SystemGameScene : IGameScene {
        private const string SystemSceneName = "SystemScene";
        private const string SystemSceneCanvasName = "SystemSceneCanvas";
        public Scene Scene { get; private set; }
        public SceneType SceneType => SceneType.System;
        public GameObject SystemSceneCanvas;

        public void Create() {
            GameEngine.Instance.ProcessManager.RunProcess(new LoadSceneProcess(SystemSceneName, scene => {
                Scene = scene;
                SystemSceneCanvas = GameObject.Find(SystemSceneCanvasName);
                GameEngine.Instance.UIManager = GameObject.FindObjectOfType<UIManager>();
                SystemSceneCanvas.SetActive(false);
            }));
        }


        public void OnSceneStart() {
            SceneManager.SetActiveScene(Scene);

#if CREATE_SYSTEM_LAYER
            GameEngine.Instance.ProcessManager.RunProcess(new CreateGalaxyProcess( loadedSystem => {
                SystemSceneCanvas?.SetActive(true);
            }));
#else
            GameEngine.Instance.ProcessManager.RunProcess(new LoadSystemSceneProcess(SerializableDataReader.ReadGalaxyFromPath(), SerializableDataReader.ReadPlayerFromPath(),
                loadedSystem => {
                    SystemSceneCanvas?.SetActive(true);
                    GameEngine.Instance.MouseInput.Enabled = true;
                    GameEngine.Instance.UIManager = GameObject.FindObjectOfType<UIManager>();
                }));
#endif
        }

        public void OnSceneExit() {
            GameEngine.Instance.MouseInput.Enabled = false;
            SystemSceneCanvas?.SetActive(false);
            GameDataWriter.SaveGame();
            GameEngine.Instance.Galaxy.ActiveSystem.OnDeactivate();
            GameEngine.Instance.CurrentPlayer.CurrentShip = null;
        }

        public void OnScenePause() {
            GameEngine.Instance.MouseInput.Enabled = false;
            Time.timeScale = 0.0f;
            SystemSceneCanvas?.SetActive(false);
        }

        public void OnSceneResume() {
            SystemSceneCanvas?.SetActive(true);
            Time.timeScale = 1.0f;
            GameEngine.Instance.MouseInput.Enabled = true;
        }
    }
}