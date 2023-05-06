using com.bandags.spacegame.planet;

namespace com.bandags.spacegame.scene {
    public interface IGameSceneManager {
        void Initialize();
        void LoadMainMenu();
        void LoadSystem();
        void LoadPlanet(PlanetType planetType);
        void LoadMap();
        void HideMap();
    }
}