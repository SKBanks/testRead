using System;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.job;
using UnityEngine;

namespace com.bandags.spacegame.data.jobs {
    [CreateAssetMenu(fileName = "_Job_ScriptableObject", menuName = "ScriptableObjects/Jobs/JobScriptableObject", order = 1)]
    [Serializable]
    public class JobScriptableObject : ScriptableObject {
        public JobType JobType;
        public string JobDescription;
        public QuestConditionScriptableObject CompletionCondition;
        public DialogChoiceType CompletionActionType;
        public ChoiceScriptableObject CompletionAction;
    }
}