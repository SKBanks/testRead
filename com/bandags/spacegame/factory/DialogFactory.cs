using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.quest.dialog;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public class DialogFactory : IDialogFactory {
        private readonly IQuestRewardFactory _questRewardFactory;
        public DialogFactory(IQuestRewardFactory questRewardFactory) {
            _questRewardFactory = questRewardFactory;
        }
        public IDialog CreateDialog(DialogType dialogType, ScriptableObject dialogScriptableObject) {
            switch (dialogType) {
                case DialogType.OkDialog:
                    var okDialog = CreateOkDialog(dialogScriptableObject as OkDialogDataScriptableObject);
                    okDialog.transform.SetParent(GameEngine.Instance.QuestDialogParent.transform);
                    return okDialog;
                case DialogType.MultiChoiceDialog:
                    var multiChoiceDialog = CreateMultiChoiceDialog(dialogScriptableObject as MultiChoiceDialogDataScriptableObject);
                    multiChoiceDialog.transform.SetParent(GameEngine.Instance.QuestDialogParent.transform);
                    return multiChoiceDialog;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dialogType), dialogType, null);
            }
        }
        private Choice HandleDialogChoice(DialogChoiceType dialogChoiceType, ScriptableObject choiceScriptableObject) {
            switch (dialogChoiceType) {
                case DialogChoiceType.Dialog:
                    var dialogChoice = choiceScriptableObject as DialogChoiceScriptableObject;
                    return new Choice {
                        choiceAction = CreateDialog(dialogChoice.DialogType, dialogChoice.Dialog),
                        choiceText = dialogChoice.ChoiceButtonText
                    };
                case DialogChoiceType.Reward:
                    var rewardChoice = choiceScriptableObject as RewardChoiceScriptableObject;
                    return new Choice {
                        choiceAction = _questRewardFactory.CreateQuestReward(rewardChoice.QuestRewardType, rewardChoice),
                        choiceText = "Reward"
                    };
                case DialogChoiceType.QuestCompletion:
                    var questCompletionChoice = choiceScriptableObject as QuestCompletionChoiceScriptableObject;
                    return new Choice {
                        choiceAction = CreateQuestCompletion(questCompletionChoice),
                        choiceText = "QuestCompletion"
                    };
                case DialogChoiceType.Null:
                default:
                    return new Choice();
            }
        }

        private OKDialog CreateOkDialog(OkDialogDataScriptableObject okDialogDataScriptableObject) {
            var okDialog = Instantiation.InstantiatePrefab<OKDialog>("Prefabs/Dialog/OkDialog");
            okDialog.SetData(okDialogDataScriptableObject.QuestText, HandleDialogChoice(okDialogDataScriptableObject.OkButtonChoice.DialogChoiceType, okDialogDataScriptableObject.OkButtonChoice));
            return okDialog;
        }
        
        private MultiChoiceDialog CreateMultiChoiceDialog(MultiChoiceDialogDataScriptableObject multiChoiceDialogDataScriptableObject) {
            var multiChoiceDialog = Instantiation.InstantiatePrefab<MultiChoiceDialog>("Prefabs/Dialog/MultiChoiceDialog");
            var multiChoiceDialogData = new List<MultiChoiceDialogData>();
            multiChoiceDialogDataScriptableObject.Choices.ForEach(choiceScriptableObject => {
                
                multiChoiceDialogData.Add(new MultiChoiceDialogData {
                    ButtonAction = HandleDialogChoice(choiceScriptableObject.DialogChoiceType, choiceScriptableObject),
                    ButtonText = choiceScriptableObject.ChoiceButtonText
                });
            });
            multiChoiceDialog.SetData(multiChoiceDialogDataScriptableObject.QuestText, multiChoiceDialogData);
            return multiChoiceDialog;
        }
        
        private QuestCompletion CreateQuestCompletion(QuestCompletionChoiceScriptableObject questCompletionChoiceScriptableObject) {
            return new QuestCompletion(questCompletionChoiceScriptableObject.StartingQuestState, questCompletionChoiceScriptableObject.CompletionQuestState);
        }
    }
}