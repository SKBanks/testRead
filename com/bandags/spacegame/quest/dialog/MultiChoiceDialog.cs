using System.Collections.Generic;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;
using com.bandags.spacegame.utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace com.bandags.spacegame.quest.dialog {
    public class MultiChoiceDialog : MonoBehaviour, IDialog {
        public Canvas Canvas;
        public GameObject DialogChoicesParent;
        public TMP_Text DescriptionText;

        public DialogType DialogType => DialogType.MultiChoiceDialog;
        public PlayerQuest PlayerQuest { get; set; }
        private List<Choice> Choices;
        private Dictionary<Button, Choice> buttonMap;

        public void Execute() {
            Canvas.gameObject.SetActive(true);
        }

        public void SetData(string descriptionText, List<MultiChoiceDialogData> choices) {
            DescriptionText.SetText(descriptionText.Replace("\\n", "\n"));
            choices.ForEach(choiceData => {
                var choiceButton = Instantiation.InstantiatePrefab<Button>("Prefabs/Dialog/ChoiceButton");
                choiceButton.transform.SetParent(DialogChoicesParent.transform, false);
                choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choiceData.ButtonText;
                choiceButton.onClick.RemoveAllListeners();
                choiceButton.onClick.AddListener(() => {
                    ButtonClicked(choiceData.ButtonAction);
                });
            });
        }
        
        public void ButtonClicked(Choice choice) {
            choice.SetData(this, PlayerQuest);
            choice.ChoiceClicked();
        }

        public void CloseDialog() {
            Canvas.gameObject.SetActive(false);
        }
    }
}