using System.Collections.Generic;
using com.bandags.spacegame.data.quests;
using com.bandags.spacegame.data.serialization.planet;
using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.quest;
using com.bandags.spacegame.system;
using TMPro;
using UnityEngine;

namespace com.bandags.spacegame.ui.planet.panels {
    public class JobPanel : MonoBehaviour {
        public TextMeshProUGUI TitleText;
        public TextMeshProUGUI DescriptionText;
        public TextMeshProUGUI TargetPlanetText;
        public TextMeshProUGUI RewardText;
        
        private string _description;
        private int _cargoSize;
        private CargoType _cargoType;
        private PlanetType _targetPlanet;
        private SystemType _targetSystem;
        private int _rewardAmount;

        public void SetJobDetails(int cargoSize, CargoType cargoType, PlanetType targetPlanet, SystemType targetSystem, int rewardAmount) {
            _cargoSize = cargoSize;
            _cargoType = cargoType;
            _targetPlanet = targetPlanet;
            _targetSystem = targetSystem;
            _rewardAmount = rewardAmount;
            UpdateUI();
        }

        private void UpdateUI() {
            TitleText.text = $"Delivery To {_targetPlanet}";
            DescriptionText.text = _description = $"Deliver {_cargoSize} tons of {_cargoType} to {_targetPlanet} in the {_targetSystem} System.  You will receive {_rewardAmount} credits upon completion.";
            TargetPlanetText.text = $"{_targetPlanet} ({_targetSystem})";
            RewardText.text = $"${_rewardAmount}";
        }

        public void OnAccept() {
            var job = new DeliverItemToNeighborJob(new JobData {
                JobDescription = _description,
                CargoAmount = _cargoSize,
                CargoType = _cargoType,
                TargetPlanet = _targetPlanet,
                TargetSystem = _targetSystem,
                RewardAmount = _rewardAmount
            });
            GameEngine.Instance.CurrentPlayer.JobManager.AddJob(job);
        }
    }
}