using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public interface IQuestRewardFactory {
        IQuestReward CreateQuestReward(QuestRewardType questRewardType, ScriptableObject questRewardScriptableObject);
    }
}