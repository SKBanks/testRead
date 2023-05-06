using System;
using com.bandags.spacegame.quest.condition;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "InSystemCondition_ScriptableObject", menuName = "ScriptableObjects/Quest/Condition/InSystem", order = 1)]
    [Serializable]
    public class InSystemConditionScriptableObject : QuestConditionScriptableObject {
        public override QuestConditionType QuestConditionType => QuestConditionType.InSystem;
        public SystemType TargetSystem;
    }
}