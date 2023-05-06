using com.bandags.spacegame.player;

namespace com.bandags.spacegame.quest.dialog {
    public class QuestCompletion : IQuestAction {
        private readonly QuestState _startingQuestState;
        private readonly QuestState _completionQuestState;
        public PlayerQuest PlayerQuest { get; set; }
        public QuestCompletion(QuestState startingQuestState, QuestState completionQuestState) {
            _startingQuestState = startingQuestState;
            _completionQuestState = completionQuestState;
        }        
        public void Execute() {
            PlayerQuest.StartingQuestState = _startingQuestState;
            PlayerQuest.CompleteQuestState = _completionQuestState;
            GameEngine.Instance.CurrentPlayer.QuestManager.MoveQuestToCompleted(PlayerQuest);
        }
    }
}