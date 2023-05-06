using System;
using System.Collections;
using com.bandags.spacegame.camera;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.player;

namespace com.bandags.spacegame.process {
    public class DeserializePlayerProcess : Process {
        private readonly Action<Player> _onPlayerLoadComplete;
        private readonly PlayerData _playerData;

        public DeserializePlayerProcess(PlayerData playerData, Action<Player> onPlayerLoadComplete) : base(ProcessType.CREATE_PLAYER_PROCESS) {
            _playerData = playerData;
            _onPlayerLoadComplete = onPlayerLoadComplete;
        }
        protected override IEnumerator Update() {
            var player = new Player();
            player.Deserialize(_playerData);
            GameEngine.Instance.MainCamera.GetComponent<FollowTarget>().Target = player.CurrentShip.transform;
            _onPlayerLoadComplete.Invoke(player);
            yield return null;
        }
    }
}