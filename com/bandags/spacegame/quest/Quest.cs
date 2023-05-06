using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest {
    public class Quest : IQuest {
        public QuestType QuestType { get; }
        private readonly IDialog _startingDialog;
        private readonly IDialog _completionDialog;
        private readonly IQuestCondition _startingRequirements;
        private readonly IQuestCondition _completionRequirements;

        public Quest(QuestType questType, IDialog startingDialog, IDialog completionDialog, IQuestCondition startingRequirements, IQuestCondition completionRequirements) {
            QuestType = questType;
            _startingDialog = startingDialog;
            _completionDialog = completionDialog;
            _startingRequirements = startingRequirements;
            _completionRequirements = completionRequirements;
        }
        public bool StartingRequirementsMet() {
            return _startingRequirements.ConditionsMet();
        }

        public bool CompletionRequirementsMet() {
            return _completionRequirements.ConditionsMet();
        }

        /// <summary>
        /// Starts the Starting Dialog
        /// </summary>
        public void BeginStartingDialog(PlayerQuest playerQuest) {
            if (playerQuest.StartingQuestState != QuestState.Not_Started) return;
            playerQuest.StartingQuestState = QuestState.Active;
            _startingDialog.PlayerQuest = playerQuest;
            _startingDialog.Execute();
        }

        /// <summary>
        /// Starts the Completion Dialog
        /// </summary>
        public void BeginCompletionDialog(PlayerQuest playerQuest) {
            if (playerQuest.CompleteQuestState != QuestState.Not_Started) return;
            playerQuest.CompleteQuestState = QuestState.Active;
            _completionDialog.PlayerQuest = playerQuest;
            _completionDialog.Execute();
        }
    }
}