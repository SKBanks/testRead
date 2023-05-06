using System;
using com.bandags.spacegame.quest;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "QuestCompletion_ScriptableObject", menuName = "ScriptableObjects/Quest/QuestCompletionChoiceScriptableObject", order = 1)]
    [Serializable]
    public class QuestCompletionChoiceScriptableObject : ChoiceScriptableObject {
        public override DialogChoiceType DialogChoiceType => DialogChoiceType.QuestCompletion;
        public QuestState StartingQuestState;
        public QuestState CompletionQuestState;
    }
}