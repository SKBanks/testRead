using com.bandags.spacegame.data;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;
using UnityEngine;

namespace com.bandags.spacegame.quest {
    public class CreditQuestReward : IQuestReward {
        public QuestRewardType QuestRewardType => QuestRewardType.Credit;
        public PlayerQuest PlayerQuest { get; set; }
        private readonly int _amount;
        public CreditQuestReward(int amount) {
            _amount = amount;
        }        
        public void Execute() {
            Debug.Log($"User gets a {_amount} {QuestRewardType} Quest Reward now");
            GameEngine.Instance.CurrentPlayer.CurrentPlayerState.Credit += _amount;

            if (PlayerQuest == null) return;
            GameEngine.Instance.CurrentPlayer.QuestManager.CompleteQuest(PlayerQuest);
        }
    }
}