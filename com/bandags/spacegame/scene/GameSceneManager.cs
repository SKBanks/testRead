using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.scene {
    public class GameSceneManager : IGameSceneManager {
        private IGameScene _currentGameScene;
        private SceneType CurrentSceneType => _currentGameScene.SceneType;

        private LauncherGameScene _launcherGameScene;
        private MainMenuGameScene _mainMenuGameScene;
        private SystemGameScene _systemGameScene;
        private PlanetGameScene _planetGameScene;
        private MapGameScene _mapGameScene;

        public void Initialize() {
            _launcherGameScene = new LauncherGameScene();
            _mainMenuGameScene = new MainMenuGameScene();
            _systemGameScene = new SystemGameScene();
            _planetGameScene = new PlanetGameScene();
            _mapGameScene = new MapGameScene();
            _launcherGameScene.Create();
            _mainMenuGameScene.Create();
            _systemGameScene.Create();
            _planetGameScene.Create();
            _mapGameScene.Create();
            _currentGameScene = _mainMenuGameScene;
        }

        public void LoadMainMenu() {
            ExitCurrentScene();
            EnterNewScene(_mainMenuGameScene);
        }

        public void LoadSystem() {
            ExitCurrentScene();
            EnterNewScene(_systemGameScene);
        }

        public void LoadPlanet(PlanetType planetType) {
            ExitCurrentScene();
            //EnterNewScene(_planetGameScene);
            _planetGameScene.OnSceneStart(planetType, GameEngine.Instance.CurrentPlayer);
            _currentGameScene = _planetGameScene;
        }

        public void LoadMap() {
            _systemGameScene.OnScenePause();
            _mapGameScene.OnSceneStart();
        }

        public void HideMap() {
            _mapGameScene.OnSceneExit();
            _systemGameScene.OnSceneResume();
        }

        private void ExitCurrentScene() {
            if (CurrentSceneType != SceneType.Launcher) {
                _currentGameScene.OnSceneExit();
            }
        }

        private void EnterNewScene(IGameScene newGameScene) {
            newGameScene.OnSceneStart();
            _currentGameScene = newGameScene;
        }
    }
}