using com.bandags.spacegame.data;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.player;
using com.bandags.spacegame.process;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    public class PlanetGameScene : IGameScene {
        private const string SceneName = "PlanetScene";
        private const string CanvasName = "PlanetCanvas";
        private const string PlanetSceneDataName = "PlanetSceneData";
        public Scene Scene { get; private set; }
        public SceneType SceneType => SceneType.Planet;
        private GameObject _canvas;
        private PlanetSceneData _planetSceneData;
        
        public void Create() {
            GameEngine.Instance.ProcessManager.RunProcess(new LoadSceneProcess(SceneName, scene => {
                Scene = scene;
                _canvas = GameObject.Find(CanvasName);
                _canvas.SetActive(false);
                _planetSceneData = GameObject.Find(PlanetSceneDataName).GetComponent<PlanetSceneData>();
            }));
        }

        public void OnSceneStart(PlanetType currentPlanet, Player currentPlayer) {
            GameEngine.Instance.Galaxy.ActiveSystem.GetPlanetByType(currentPlanet).Visited = true;
            _planetSceneData.LoadPlanet(currentPlanet);
            currentPlayer.CurrentPlayerState.CurrentPlanet = currentPlanet;
            GameDataWriter.SaveGame();
            OnSceneStart();
            currentPlayer.QuestManager.QuestUpdate();
            currentPlayer.JobManager.UpdateActiveJobs();
        }
        
        public void OnSceneStart() {
            SceneManager.SetActiveScene(Scene);
            _canvas?.SetActive(true);
        }
        public void OnSceneExit() {
            GameEngine.Instance.CurrentPlayer.CurrentPlayerState.CurrentPlanet = PlanetType.None;
            GameDataWriter.SaveGame();
            _canvas?.SetActive(false);
        }
    }
}