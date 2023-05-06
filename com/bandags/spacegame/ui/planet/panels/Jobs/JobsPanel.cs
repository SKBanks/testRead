using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.serialization;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.job;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.system;
using com.bandags.spacegame.utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.bandags.spacegame.ui.planet.panels {
    public class JobsPanel : Panel {
        public override PlanetFeatureType PlanetFeatureTypeType => PlanetFeatureType.Jobs;
        public GameObject JobPanelParent;

        private readonly List<JobPanel> _planetJobs = new List<JobPanel>();

        public void LoadJobsPanel(PlanetData planetData, JobPFData jobPfData) {
            ClearJobsPanel();
            jobPfData.JobTypes.ForEach(jobType => {
                switch (jobType) {
                    case JobType.DeliverItemToNeighbor:
                        for (var x = 0; x < Random.Range(2, 4); x++) {
                            //Todo: Fix hardcoded values
                            _planetJobs.Add(CreateDeliverItemJob(planetData.PlanetType, planetData.SystemType, 25, CargoType.Food, 500));
                        }
                        break;
                    case JobType.PickupItemFromNeighbor:
                        break;
                    case JobType.SellSuppliesToNeighbor:
                        break;
                    case JobType.BuySuppliesFromNeighbor:
                        break;
                    case JobType.FerryPassengersToDestination:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(jobType), jobType, null);
                }
            });
        }

        private JobPanel CreateDeliverItemJob(PlanetType targetPlanet, SystemType targetSystem, int cargoSize, CargoType cargoType, int creditReward) {
            var jobPanel = Instantiation.InstantiatePrefab<JobPanel>("Prefabs/Planets/Panels/JobPanelItem");
            jobPanel.SetJobDetails(cargoSize, cargoType, targetPlanet, targetSystem, creditReward);
            jobPanel.transform.SetParent(JobPanelParent.transform);
            //jobPanel.gameObject.SetActive(false);
            return jobPanel;

        }

        private void ClearJobsPanel() {
            if (_planetJobs != null && _planetJobs.Count > 0) {
                _planetJobs.ForEach(planetJob => {
                    Destroy(planetJob.gameObject);
                });
            }
            _planetJobs.Clear();
        }
    }
}