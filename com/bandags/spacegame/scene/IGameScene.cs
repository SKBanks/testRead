using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.scene {
    public interface IGameScene {
        Scene Scene { get; }
        SceneType SceneType { get; }
        void Create();
        void OnSceneStart();
        void OnSceneExit();
    }
}