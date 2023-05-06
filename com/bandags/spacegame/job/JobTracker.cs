using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.quest;
using UnityEngine;

namespace com.bandags.spacegame.job {
    [Serializable]
    public class JobTracker {
        private readonly List<IQuestCondition> _completionConditions;
        private readonly IQuestAction _completionAction;

        public JobTracker(IQuestAction completionAction, List<IQuestCondition> completionConditions) {
            _completionAction = completionAction;
            _completionConditions = completionConditions;
        }

        public bool CompletionRequirementsMet() {
            var conditionsMet = _completionConditions.Any(condition => !condition.ConditionsMet());
            Debug.Log($"Conditions Met: {conditionsMet}");
            return conditionsMet;
        }

        public void CompleteJob() {
            _completionAction?.Execute();
        }
    }
}