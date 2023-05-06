using System;
using com.bandags.spacegame.quest.condition;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_HasCreditCondition_ScriptableObject", menuName = "ScriptableObjects/Quest/Condition/HasCredit", order = 1)]
    [Serializable]
    public class HasCreditConditionScriptableObject : QuestConditionScriptableObject {
        public override QuestConditionType QuestConditionType => QuestConditionType.HasCredits;
        public int TargetAmount;
    }
}