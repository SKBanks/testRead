using System;
using System.Collections;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.process {
    public class LoadSystemSceneProcess : Process {
        private readonly GalaxyData _galaxyData;
        private readonly PlayerData _playerData;
        private readonly Action<SystemLayer> _onComplete;
        
        public LoadSystemSceneProcess(GalaxyData galaxyData, PlayerData playerData, Action<SystemLayer> onComplete) : base(ProcessType.START_GAME_PROCESS) {
            _galaxyData = galaxyData;
            _playerData = playerData;
            _onComplete = onComplete;
        }
        protected override IEnumerator Update() {
            yield return new DeserializeGalaxyProcess(_galaxyData).Run();

            //Create the player
            yield return new DeserializePlayerProcess(_playerData, player => {
                GameEngine.Instance.PlayerManager.CurrentPlayer = player;
            }).Run();
            
            _onComplete?.Invoke(GameEngine.Instance.Galaxy.ActiveSystem);
        }
    }
}