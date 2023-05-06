using System.Collections.Generic;
using com.bandags.spacegame.data.serialization;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ui.planet.panels;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.ui.planet {
    public class PanelButtonHandler {
        private readonly GameObject _panelParent;
        private readonly List<GameObject> _panelButtons;

        public PanelButtonHandler(GameObject panelParent) {
            _panelParent = panelParent;
            _panelButtons = new List<GameObject>();
        }
        public void GenerateButtonMenu(List<PlanetFeatureType> planetFeaturesList, PlanetPanelManager planetPanelManager) {
            ClearPanelButtons();
            _panelButtons.Add(CreateLargeSpacer());
            _panelButtons.Add(CreatePanelButton("Planet Details", planetPanelManager, PlanetFeatureType.PlanetDetails));
            planetFeaturesList.ForEach(planetFeature => {
                _panelButtons.Add(CreateLargeSpacer());
                _panelButtons.Add(CreatePanelButton(planetFeature.ToString(), planetPanelManager, planetFeature));
            });
        }
        
        public void GenerateButtonMenu2(List<PlanetFeatureData> planetFeatures, PlanetPanelManager planetPanelManager) {
            ClearPanelButtons();
            _panelButtons.Add(CreateLargeSpacer());
            _panelButtons.Add(CreatePanelButton("Planet Details", planetPanelManager, PlanetFeatureType.PlanetDetails));
            planetFeatures.ForEach(planetFeature => {
                if (planetFeature.PlanetFeatureType == PlanetFeatureType.PlanetDetails) return;
                _panelButtons.Add(CreateLargeSpacer());
                _panelButtons.Add(CreatePanelButton(planetFeature.PlanetFeatureType.ToString(), planetPanelManager, planetFeature.PlanetFeatureType));
            });
        }
        private GameObject CreatePanelButton(string buttonName, PlanetPanelManager planetPanelManager, PlanetFeatureType planetFeatureType) {
            var panelButton = Instantiation.InstantiatePrefab<PanelButton>("Prefabs/Planets/PlanetButtonMenuButton");
            panelButton.transform.SetParent(_panelParent.transform);
            panelButton.ButtonText.SetText(buttonName);
            panelButton.Button.onClick.RemoveAllListeners();
            panelButton.Button.onClick.AddListener(() => {
                planetPanelManager.ChangePanel(planetFeatureType);
            });
            return panelButton.gameObject;
        }
        private void ClearPanelButtons() {
            _panelButtons.ForEach(GameObject.Destroy);
            _panelButtons.Clear();
        }
        private GameObject CreateLargeSpacer() {
            var spacer = Instantiation.InstantiatePrefab("Prefabs/Planets/PlanetButtonMenuLargeSpacer");
            spacer.transform.SetParent(_panelParent.transform);
            return spacer;
        }
    }
}