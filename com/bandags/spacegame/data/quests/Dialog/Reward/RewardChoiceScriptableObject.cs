using System;

namespace com.bandags.spacegame.data.quests {
    [Serializable]
    public class RewardChoiceScriptableObject : ChoiceScriptableObject {
        public override DialogChoiceType DialogChoiceType => DialogChoiceType.Reward;
        public QuestRewardType QuestRewardType;
    }
}