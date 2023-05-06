using System;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.player;
using com.bandags.spacegame.quest.dialog;
using TMPro;
using UnityEngine;

namespace com.bandags.spacegame.quest {
    [Serializable]
    public class OKDialog : MonoBehaviour, IDialog {
        public Canvas Canvas;
        public TMP_Text DescriptionText;
        public DialogType DialogType => DialogType.OkDialog;
        public PlayerQuest PlayerQuest { get; set; }

        [field:SerializeReference] private Choice _choice;
        
        public void Execute() {
            Canvas.gameObject.SetActive(true);
        }

        public void SetData(string questText, Choice choice) {
            DescriptionText.SetText(questText.Replace("\\n", "\n"));
            _choice = choice;
            _choice.choiceText = "Ok";
        }
        public void CloseDialog() {
            Canvas.gameObject.SetActive(false);
        }
        public void ButtonClicked() {
            _choice.SetData(this, PlayerQuest);
            _choice.ChoiceClicked();
        }
    }
}