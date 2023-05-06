using System;
using System.Collections;
using com.bandags.spacegame.camera;
using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.player;
using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.process {
    public class CreatePlayerProcess : Process {
        private readonly PlayerScriptableObject _playerScriptableObject;
        private readonly Action<Player> _onPlayerCreateCallback;

        public CreatePlayerProcess(PlayerScriptableObject playerScriptableObject, Action<Player> onPlayerCreateCallback) : base(ProcessType.CREATE_PLANET_PROCESS) {
            _playerScriptableObject = playerScriptableObject;
            _onPlayerCreateCallback = onPlayerCreateCallback;
        }
        protected override IEnumerator Update() {
            var player = new Player();
            player.Deserialize(PlayerData.CreateFromScriptableObject(_playerScriptableObject));
            GameEngine.Instance.MainCamera.GetComponent<FollowTarget>().Target = player.CurrentShip.transform;
            _onPlayerCreateCallback.Invoke(player);
            yield return null;
        }
    }
}