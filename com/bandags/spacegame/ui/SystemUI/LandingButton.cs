using com.bandags.spacegame.input;
using com.bandags.spacegame.planet;
using UnityEngine;

namespace com.bandags.spacegame.ui {
    public class LandingButton : MonoBehaviour {
        public void LandingButtonClicked() {
            var currentPlayerShip = GameEngine.Instance.CurrentPlayer.CurrentShip;
            var currentSelection = currentPlayerShip.Sensors.Selection;
            
            if (currentSelection != null && currentSelection.GetSelectableType() == SelectableType.Planet) {
                Debug.Log("Selection: " + currentSelection.GetSelectableName());
                currentPlayerShip.Land((Planet)currentSelection);
                return;
            }

            var systemPlanets = GameEngine.Instance.Galaxy.ActiveSystem.Planets;
            if (systemPlanets.Count == 0) return;
            currentPlayerShip.Land(systemPlanets[0]);
        }
    }
}