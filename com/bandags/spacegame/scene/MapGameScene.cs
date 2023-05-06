using com.bandags.spacegame.process;
using com.bandags.spacegame.ui.map;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    //Todo: Refactor all gameScenes and move boiler plate code into protected base class methods (Create: Abstract GameScene class which serves as base class)
    public class MapGameScene : IGameScene {
        private const string SceneName = "MapScene";
        private const string CanvasName = "MapCanvas";
        private const string MapPlanetManagerName = "PlanetsParent";
        public Scene Scene { get; private set; }
        public SceneType SceneType => SceneType.Planet;
        private GameObject _canvas;
        private MapDataManager _mapDataManager;
        
        public void Create() {
            GameEngine.Instance.ProcessManager.RunProcess(new LoadSceneProcess(SceneName, scene => {
                Scene = scene;
                _canvas = GameObject.Find(CanvasName);
                _mapDataManager = _canvas.transform.Find(MapPlanetManagerName).GetComponent<MapDataManager>();
                _canvas.SetActive(false);
            }));
        }
        public void OnSceneStart() {
            SceneManager.SetActiveScene(Scene);
            _mapDataManager.LoadSystems(GameEngine.Instance.Galaxy.GetAllSystemData());
            _canvas?.SetActive(true);
        }
        public void OnSceneExit() {
            _canvas?.SetActive(false);
        }
    }
}