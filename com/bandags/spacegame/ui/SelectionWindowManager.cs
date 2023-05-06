using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;

namespace com.bandags.spacegame.ui {
    public class SelectionWindowManager {
        private readonly TargetSelectionWindow _primaryTargetSelectionWindow;
        private readonly PlanetSelectionWindow _planetSelectionWindow;

        public SelectionWindowManager(TargetSelectionWindow primaryTargetSelectionWindow, PlanetSelectionWindow planetSelectionWindow) {
            _primaryTargetSelectionWindow = primaryTargetSelectionWindow;
            _planetSelectionWindow = planetSelectionWindow;
        }

        public void ClearAllTargets() {
            _planetSelectionWindow.HideWindow();
            _primaryTargetSelectionWindow.HideWindow();
        }

        public void OnSelectShip(Ship selectedShip) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Sensors.Selection = selectedShip;
            _primaryTargetSelectionWindow.SetTarget(selectedShip);
            _primaryTargetSelectionWindow.ShowWindow();
            _planetSelectionWindow.HideWindow();
        }

        public void OnSelectPlanet(Planet selectedPlanet) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Sensors.Selection = selectedPlanet;
            _planetSelectionWindow.SetTarget(selectedPlanet);
            _planetSelectionWindow.ShowWindow();
            _primaryTargetSelectionWindow.HideWindow();
        }
    }
}