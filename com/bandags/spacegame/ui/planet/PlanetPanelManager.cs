using System;
using System.Collections.Generic;
using com.bandags.spacegame.data.serialization;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ui.planet.panels;
using UnityEngine;

namespace com.bandags.spacegame.ui.planet {
    public class PlanetPanelManager : MonoBehaviour {
        public GameObject PanelParent;
        
        public PlanetDetailsPanel PlanetDetailsPanel;
        public JobsPanel JobsPanel;
        public ShipyardPanel ShipyardPanel;
        public OutfitterPanel OutfitterPanel;

        private Dictionary<PlanetFeatureType, IPanel> _panelsByFeature;
        private IPanel _activePanel;

        private void Awake() {
            _panelsByFeature = new Dictionary<PlanetFeatureType, IPanel> {
                {PlanetFeatureType.PlanetDetails, PlanetDetailsPanel},
                { PlanetFeatureType.Jobs, JobsPanel},
                { PlanetFeatureType.Outfitter , OutfitterPanel},
                { PlanetFeatureType.Shipyard , ShipyardPanel},
            };
            _activePanel = PlanetDetailsPanel;
        }

        public void ChangePanel(PlanetFeatureType panelFeatureTypeToLoad) {
            _activePanel.Hide();
            _activePanel = _panelsByFeature[panelFeatureTypeToLoad];
            _activePanel.Show();
        }

        public void LoadPanels(PlanetData planetData) {
            planetData.PlanetFeatures.ForEach(planetFeatureData => {
                switch (planetFeatureData.PlanetFeatureType) {
                    case PlanetFeatureType.Trade:
                        break;
                    case PlanetFeatureType.Jobs:
                        var jobData = planetFeatureData as JobPFData;
                        LoadJobsPanel(planetData, jobData);
                        break;
                    case PlanetFeatureType.Shipyard:
                        break;
                    case PlanetFeatureType.Outfitter:
                        break;
                    case PlanetFeatureType.PlanetDetails:
                        LoadPlanetDetailsPanel(planetData);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            
            ChangePanel(PlanetFeatureType.PlanetDetails);
        }

        private void LoadPlanetDetailsPanel(PlanetData planetData) {
            PlanetDetailsPanel.LoadPlanetDetails(planetData);
        }

        private void LoadJobsPanel(PlanetData planetData, JobPFData jobPfData) {
            JobsPanel.LoadJobsPanel(planetData, jobPfData);
        }
    }
}