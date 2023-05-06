using System;
using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.ui {
    [Serializable]
    public class UIManager : MonoBehaviour {
        public SystemType SelectedSystemType;
        
        public TargetSelectionWindow PrimaryTargetSelectionWindow;
        public PlanetSelectionWindow PlanetSelectionWindow;
        private SelectionWindowManager SelectionWindowManager;

        private void Awake() {
            SelectionWindowManager = new SelectionWindowManager(PrimaryTargetSelectionWindow, PlanetSelectionWindow);
        }

        public void OnSelectShip(Ship selectedShip) {
            SelectionWindowManager.OnSelectShip(selectedShip);
        }

        public void OnSelectPlanet(Planet selectedPlanet) {
            SelectionWindowManager.OnSelectPlanet(selectedPlanet);
        }

        public void OnSelectNothing() {
            SelectionWindowManager.ClearAllTargets();
        }
    }
}