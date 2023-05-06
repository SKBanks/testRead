using System;
using com.bandags.spacegame.quest.condition;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "NullQuestCondition_ScriptableObject", menuName = "ScriptableObjects/Quest/Condition/None", order = 1)]
    [Serializable]
    public class NullQuestConditionScriptableObject : QuestConditionScriptableObject {
        public override QuestConditionType QuestConditionType => QuestConditionType.None;
    }
}