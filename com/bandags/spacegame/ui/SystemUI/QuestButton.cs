using System;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.ui {
    [Serializable]
    public class QuestButton : MonoBehaviour {
        [field: SerializeReference] private IQuest _playerStartQuest1;
        public void QuestButtonClicked() {
            //QuestButtonClickedUpdated();
            
            
            
            /*
            var playerStartQuest_1_Dialog1 = Instantiation.InstantiatePrefab<OKDialog>("Prefabs/Dialog/OkDialog");
            var dialog1Meta = GameEngine.Instance.DialogDataScriptableObjects[0];
            //var dialog1Meta = Instantiation.InstantiatePrefab<OkDialogDataScriptableObject>("ScriptableObjects/Quests/PlayerStartQuest_1_Dialog1_QuestDialog_ScriptableObject");
            
            var playerStartQuest_1_Dialog2 = Instantiation.InstantiatePrefab<OKDialog>("Prefabs/Dialog/OkDialog");
            var dialog2Meta = GameEngine.Instance.DialogDataScriptableObjects[1];
            //var dialog2Meta = Instantiation.InstantiatePrefab<OkDialogDataScriptableObject>("ScriptableObjects/Quests/PlayerStartQuest_1_Dialog2_QuestDialog_ScriptableObject");
            
            var endingDialog = Instantiation.InstantiatePrefab<OKDialog>("Prefabs/Dialog/OkDialog");
            var dialog3Meta = GameEngine.Instance.DialogDataScriptableObjects[2];
            //var dialog3Meta = Instantiation.InstantiatePrefab<OkDialogDataScriptableObject>("ScriptableObjects/Quests/PlayerStartQuest_1_Dialog3_QuestDialog_ScriptableObject");
            
            var questReward = new QuestReward();
            var questCondition = new NullQuestCondition();
            _playerStartQuest1 = new Quest(QuestType.PlayerStartQuest1, playerStartQuest_1_Dialog1, endingDialog, questCondition, questCondition, questReward);
            
            //dialog1Meta.OkButtonAction = playerStartQuest_1_Dialog2;

            /*playerStartQuest_1_Dialog1.SetMeta(dialog1Meta);
            playerStartQuest_1_Dialog2.SetMeta(dialog2Meta);
            endingDialog.SetMeta(dialog3Meta);#1#
            
            _playerStartQuest1.StartQuest();*/
        }

        public void QuestButtonClickedUpdated() {
            //_playerStartQuest1 = GameEngine.Instance.Factory.QuestFactory.CreateQuest(GameEngine.Instance.QuestScriptableObjects[0]);
            //_playerStartQuest1 = GameEngine.Instance.QuestLibrary.GetQuestByType(QuestType.PlayerStartQuest1);
            //int i = 0;
            //_playerStartQuest1.BeginStartingDialog();
        }
        
        public void QuestButtonClicked2() {
            //_playerStartQuest1.BeginCompletionDialog();
        }
    }
}