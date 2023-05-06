using System;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.quest.condition;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_OnPlant_QuestCondition_ScriptableObject", menuName = "ScriptableObjects/Quest/Condition/OnPlanet", order = 1)]
    [Serializable]
    public class OnPlanetQuestConditionScriptableObject : QuestConditionScriptableObject {
        public override QuestConditionType QuestConditionType => QuestConditionType.OnPlanet;
        public PlanetType TargetPlanet;
    }
}