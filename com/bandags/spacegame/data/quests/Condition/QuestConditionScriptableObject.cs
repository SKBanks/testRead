using com.bandags.spacegame.quest.condition;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    public abstract class QuestConditionScriptableObject : ScriptableObject {
        public abstract QuestConditionType QuestConditionType { get; }
    }
}