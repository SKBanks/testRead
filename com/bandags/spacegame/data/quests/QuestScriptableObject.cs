using System;
using com.bandags.spacegame.quest;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_Quest_ScriptableObject", menuName = "ScriptableObjects/Quest/QuestScriptableObject", order = 1)]
    [Serializable]
    public class QuestScriptableObject : ScriptableObject {
        public QuestType QuestType;
        public QuestConditionScriptableObject StartingQuestCondition;   //todo: convert to a list
        public DialogDataScriptableObject StartingDialog;
        public DialogType StartingDialogType;
        public QuestConditionScriptableObject CompletionQuestCondition; //todo: convert to a list
        public DialogDataScriptableObject CompletionDialog;
        public DialogType CompletionDialogType;
    }
}