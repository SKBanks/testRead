using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.data.serialization.planet;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.quest.condition;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.job {
    [Serializable]
    public class Job : ISerialize<JobData> {
        private JobType _jobType => _jobData.JobType;
        private string _jobDescription => _jobData.JobDescription;
        private int _cargoAmount => _jobData.CargoAmount;
        private CargoType _cargoType => _jobData.CargoType;
        private PlanetType _targetPlanet => _jobData.TargetPlanet;
        private SystemType _targetSystem => _jobData.TargetSystem;
        private int _rewardAmount => _jobData.RewardAmount;
        
        private JobData _jobData;

        private List<IQuestCondition> _completionConditions;
        private IQuestAction _completionAction;

        public Job(JobData jobData) {
            Deserialize(jobData);
            CreateCompletion();
        }

        public void CreateCompletion() {
            var creditRewardSo = ScriptableObject.CreateInstance<CreditRewardChoiceScriptableObject>();
            creditRewardSo.RewardCredits = _rewardAmount;
            
            var okDialogData = ScriptableObject.CreateInstance<OkDialogDataScriptableObject>();
            okDialogData.QuestText = $"You Drop off your cargo of {_cargoType} and collect your payment of {_rewardAmount} credits";
            okDialogData.OkButtonChoice = creditRewardSo;
            
            _completionConditions = new List<IQuestCondition> { new OnPlanetQuestCondition(_targetPlanet) };
            _completionAction = GameEngine.Instance.Factory.DialogFactory.CreateDialog(DialogType.OkDialog, okDialogData) as OKDialog;
        }

        public bool CompletionRequirementsMet() {
            return _completionConditions.All(condition => condition.ConditionsMet());
        }

        public void CompleteJob() {
            _completionAction?.Execute();
        }

        public JobData Serialize() {
            return _jobData;
        }

        public void Deserialize(JobData data) {
            _jobData = data;
            CreateCompletion();
        }
    }
}