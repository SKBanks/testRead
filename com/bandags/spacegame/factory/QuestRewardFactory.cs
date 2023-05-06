using System;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.quest.dialog;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public class QuestRewardFactory : IQuestRewardFactory {
        public IQuestReward CreateQuestReward(QuestRewardType questRewardType, ScriptableObject questRewardScriptableObject) {
            switch (questRewardType) {
                case QuestRewardType.Credit:
                    return CreateCreditQuestReward(questRewardScriptableObject as CreditRewardChoiceScriptableObject);
                default:
                    throw new ArgumentOutOfRangeException(nameof(questRewardType), questRewardType, null);
            }
        }

        private IQuestReward CreateCreditQuestReward(CreditRewardChoiceScriptableObject creditRewardChoiceScriptableObject) {
            return new CreditQuestReward(creditRewardChoiceScriptableObject.RewardCredits);
        }
    }
}