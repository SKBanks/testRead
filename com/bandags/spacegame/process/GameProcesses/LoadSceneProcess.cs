using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace com.bandags.spacegame.process {
    public class LoadSceneProcess : Process {
        private readonly Action<Scene> _onSceneLoadComplete;
        private readonly string _sceneName;

        public LoadSceneProcess(string sceneName, Action<Scene> onSceneLoadComplete) : base(ProcessType.LOAD_SCENE_PROCESS) {
            _sceneName = sceneName;
            _onSceneLoadComplete = onSceneLoadComplete;
        }
        protected override IEnumerator Update() {
            var asyncOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);

            while (!asyncOperation.isDone) {
                yield return null;
            }

            var loadedScene = SceneManager.GetSceneByName(_sceneName);
            _onSceneLoadComplete?.Invoke(loadedScene);
        }
    }
}