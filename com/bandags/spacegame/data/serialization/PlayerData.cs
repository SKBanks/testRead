using System;
using com.bandags.spacegame.data.jobs;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class PlayerData {
        public string Name;
        public ShipData CurrentShip;
        public QuestData QuestData;
        public JobManagerData JobManagerData;
        public PlayerStateData PlayerState;

        public static PlayerData CreateFromScriptableObject(PlayerScriptableObject playerScriptableObject) {
            return new PlayerData {
                Name = playerScriptableObject.Name,
                CurrentShip = ShipData.CreateFromShipScriptableObject(playerScriptableObject.CurrentShip),
                QuestData = QuestData.CreateQuestData(),
                PlayerState = new PlayerStateData(),
                JobManagerData = new JobManagerData()
            };
        }
    }
}