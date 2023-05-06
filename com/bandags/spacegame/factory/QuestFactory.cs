using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;

namespace com.bandags.spacegame.factory {
    public class QuestFactory : IQuestFactory {
        private readonly IDialogFactory _dialogFactory; 
        private readonly IQuestConditionFactory _questConditionFactory; 
        
        public QuestFactory(IDialogFactory dialogFactory, IQuestConditionFactory questConditionFactory) {
            _dialogFactory = dialogFactory;
            _questConditionFactory = questConditionFactory;
        }
        public IQuest CreateQuest(QuestScriptableObject questScriptableObject) {
            return new Quest(questScriptableObject.QuestType, 
                _dialogFactory.CreateDialog(questScriptableObject.StartingDialogType, questScriptableObject.StartingDialog),
                _dialogFactory.CreateDialog(questScriptableObject.CompletionDialogType, questScriptableObject.CompletionDialog), 
                _questConditionFactory.CreateQuestCondition(questScriptableObject.StartingQuestCondition), _questConditionFactory.CreateQuestCondition(questScriptableObject.CompletionQuestCondition));
        }
    }
}