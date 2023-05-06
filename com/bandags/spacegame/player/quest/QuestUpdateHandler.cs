using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.player {
    public static class QuestUpdateHandler {
        public static void HandleActiveQuest(QuestManager questManager, IQuest quest, PlayerQuest playerQuest) {
            if (playerQuest.StartingQuestState == QuestState.Not_Started) {
                quest.BeginStartingDialog(playerQuest);
                return;
            }
            
            if (playerQuest.CompleteQuestState == QuestState.Not_Started && quest.CompletionRequirementsMet()) {
                quest.BeginCompletionDialog(playerQuest);
            }
        }
    }
}