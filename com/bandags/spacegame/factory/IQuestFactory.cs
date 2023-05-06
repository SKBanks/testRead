using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.factory {
    public interface IQuestFactory {
        IQuest CreateQuest(QuestScriptableObject questScriptableObject);
    }
}