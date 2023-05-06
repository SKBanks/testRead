using com.bandags.spacegame.ship;
using com.bandags.spacegame.UI;

namespace com.bandags.spacegame.ui {
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class TargetSelectionWindow : BaseSelectionWindow {
        public Button AttackButton;
        public Button DisengageButton;
        public Button DisableButton;
        public Button BoardButton;
        public Button HailButton;

        public TextMeshProUGUI PilotNameText;
        public TextMeshProUGUI HullValueText;
        public TextMeshProUGUI ShieldsValueText;

        public Ship Target;
        public HostileTargetWindow HostileTargetWindow;

        private void Update() {
            if (Target == null) return;
            var hullStrength = Target?.Tactical?.TacticalProperties?.CurrentHullStrength ?? 0;
            var shieldStrength = Target?.Tactical?.TacticalProperties?.CurrentShieldStrength ?? 0;
            var pilotName = Target?.name ?? "Unknown Pilot";
            HullValueText?.SetText(hullStrength.ToString());
            ShieldsValueText?.SetText(shieldStrength.ToString());
            PilotNameText?.SetText(pilotName);
        }

        public void SetTarget(Ship target, bool showWindow = true) {
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

        public void Attack() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Sensors.HostileTarget = Target;
            GameEngine.Instance.CurrentPlayer.CurrentShip.Attack(Target);
            FlipButton(AttackButton, DisengageButton);
            HostileTargetWindow.gameObject.SetActive(true);
        }

        public void Disengage() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Sensors.HostileTarget = null;
            FlipButton(DisengageButton, AttackButton);
        }

        public void Disable() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Attack(Target);
            FlipButton(DisableButton, BoardButton);
        }

        public void Board() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.BoardShip(Target);
            FlipButton(BoardButton, DisableButton);
        }

        public void Hail() {
            GameEngine.Instance.CurrentPlayer.CurrentShip.HailShip(Target);
        }

        private void ResetWindow() {
            Target = null;
            AttackButton.gameObject.SetActive(true);
            DisengageButton.gameObject.SetActive(false);
            DisableButton.gameObject.SetActive(true);
            BoardButton.gameObject.SetActive(false);
            HailButton.gameObject.SetActive(true);
        }
        
        private void SetIfNotNull(TMP_Text uiElement, string text) {
            if (uiElement != null) {
                uiElement.SetText(text);
            }
        }
    }
}