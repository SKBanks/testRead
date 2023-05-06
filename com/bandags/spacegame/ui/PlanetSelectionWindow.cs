using com.bandags.spacegame.planet;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.bandags.spacegame.ui {
    public class PlanetSelectionWindow : BaseSelectionWindow {
        public Button LandButton;
        public Button AttackButton;
        public Button HailButton;

        public TextMeshProUGUI PlanetNameText;
        public TextMeshProUGUI GovernmentText;
        public TextMeshProUGUI RelationShipText;

        public Planet Target;

        private void Update() {
            var planetName = Target != null ? name : "Unknown Planet";
            var government = Target != null ? name : "Not Implemented";
            var relationShip = Target != null ? name : "Not Implemented";
            SetIfNotNull(PlanetNameText, planetName);
            SetIfNotNull(GovernmentText, government);
            SetIfNotNull(RelationShipText, relationShip);
        }
        public void SetTarget(Planet target, bool showWindow = true) {
            Target = target;
            if (showWindow) {
                ShowWindow();
            }
        }

        public void ShowWindow() {
            gameObject.SetActive(true);
        }

        public void HideWindow() {
            gameObject.SetActive(false);
            ResetWindow();
        }

        public void Land() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Land(Target);
        }

        public void Attack() {
            Debug.Log("Not Implemented");
        }

        public void Hail() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.HailPlanet(Target);
        }

        private void ResetWindow() {
            Target = null;
            LandButton.gameObject.SetActive(true);
            AttackButton.gameObject.SetActive(true);
            HailButton.gameObject.SetActive(true);
        }
        
        private void SetIfNotNull(TMP_Text uiElement, string text) {
            if (uiElement != null) {
                uiElement.SetText(text);
            }
        }
    }
}