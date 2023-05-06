using com.bandags.spacegame.data.quests;

namespace com.bandags.spacegame.quest {
    public interface IQuestReward : IQuestAction {
        QuestRewardType QuestRewardType { get; }
    }
}