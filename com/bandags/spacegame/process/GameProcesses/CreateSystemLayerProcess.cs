using System;
using System.Collections;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.process {
    public class CreateSystemLayerProcess : Process {
        private readonly SystemType _systemType;
        private readonly Action<SystemLayer> _onSystemLayerLoadComplete;
        public CreateSystemLayerProcess(SystemType systemType, Action<SystemLayer> onSystemLayerLoadComplete) : base(ProcessType.LOAD_SYSTEM_LAYER_PROCESS) {
            _systemType = systemType;
            _onSystemLayerLoadComplete = onSystemLayerLoadComplete;
        }
        protected override IEnumerator Update() {
            var systemLayer = GameEngine.Instance.Factory.SystemFactory.CreateSystemLayer(GameEngine.Instance.Galaxy.SystemLayerOffset, GameEngine.Instance.Galaxy.GetSystemDataByType(_systemType));
            systemLayer.gameObject.SetActive(false);
            _onSystemLayerLoadComplete?.Invoke(systemLayer);
            yield return null;
        }
    }
}