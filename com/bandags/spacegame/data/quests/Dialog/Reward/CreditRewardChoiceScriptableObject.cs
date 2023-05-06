using System;
using UnityEngine;

namespace com.bandags.spacegame.data.quests {
    [CreateAssetMenu(fileName = "_Credit_QuestReward_DialogChoice_ScriptableObject", menuName = "ScriptableObjects/Quest/Reward/CreditScriptableObject", order = 1)]
    [Serializable]
    public class CreditRewardChoiceScriptableObject : RewardChoiceScriptableObject {
        public int RewardCredits;
    }
}