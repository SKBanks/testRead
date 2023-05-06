using System;
using com.bandags.spacegame.player;
using UnityEngine.UI;

namespace com.bandags.spacegame.quest.dialog {
    [Serializable]
    public class Choice : IChoice {
        public Button Button;
        public string choiceText;
        public IQuestAction choiceAction;

        private IDialog _dialog;
        private PlayerQuest _playerQuest;

        public void SetButton(Button button) {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ChoiceClicked);
        }

        public void SetData(IDialog dialog, PlayerQuest quest) {
            _dialog = dialog;
            _playerQuest = quest;
        }
        
        public void ChoiceClicked() {
            _dialog.CloseDialog();
            if (choiceAction is IQuestAction questAction) {
                questAction.PlayerQuest = _playerQuest;
            }
            if (choiceAction != null) {
                choiceAction.Execute();
            } else {
                if (_playerQuest.StartingQuestState == QuestState.Active) {
                    _playerQuest.StartingQuestState = QuestState.Completed;
                } else if (_playerQuest.CompleteQuestState == QuestState.Active) {
                    GameEngine.Instance.CurrentPlayer.QuestManager.CompleteQuest(_playerQuest);
                }
            }
        }
    }
}