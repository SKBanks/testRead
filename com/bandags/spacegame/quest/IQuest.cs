using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest {
    public interface IQuest {
        QuestType QuestType { get; }
        bool StartingRequirementsMet();
        bool CompletionRequirementsMet();
        void BeginStartingDialog(PlayerQuest playerQuest);
        void BeginCompletionDialog(PlayerQuest playerQuest);
    }
}