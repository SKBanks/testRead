using System;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.job;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.player {
    [Serializable]
    public class Player : ISerialize<PlayerData> {
        public Ship CurrentShip;
        public QuestManager QuestManager;
        public JobManager JobManager;
        public PlayerState CurrentPlayerState;
        public string Name {
            get => _playerData.Name;
            set => _playerData.Name = value;
        }
        
        [field: SerializeReference] private PlayerData _playerData;
        public PlayerData Serialize() {
            if (CurrentShip != null) {
                _playerData.CurrentShip = CurrentShip.Serialize();
            }
            _playerData.QuestData = QuestManager.Serialize();
            _playerData.JobManagerData = JobManager.Serialize();
            _playerData.PlayerState = CurrentPlayerState.Serialize();
            return _playerData;
        }
        public void Deserialize(PlayerData data) {
            _playerData = data;
            CurrentShip = GameEngine.Instance.Factory.ShipFactory.CreateShip(data.CurrentShip, $"{Name}-Ship", GameEngine.Instance.Galaxy.ActiveSystem.ParentGameObjects.Ships.transform);
            CurrentShip.Deserialize(_playerData.CurrentShip);
            QuestManager = new QuestManager();
            QuestManager.Deserialize(data.QuestData);
            CurrentPlayerState = new PlayerState();
            CurrentPlayerState.Deserialize(data.PlayerState);
            JobManager = new JobManager();
            JobManager.Deserialize(data.JobManagerData);
        }
    }
}