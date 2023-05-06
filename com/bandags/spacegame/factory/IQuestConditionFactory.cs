using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.factory {
    public interface IQuestConditionFactory {
        IQuestCondition CreateQuestCondition(QuestConditionScriptableObject questConditionScriptableObject);
    }
}