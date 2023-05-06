using com.bandags.spacegame.player;
using com.bandags.spacegame.ship;
using TMPro;
using UnityEngine;

namespace com.bandags.spacegame.UI {
    public class HostileTargetWindow : MonoBehaviour {
        public TextMeshProUGUI CurrentHealthText;
        public TextMeshProUGUI MaxHealthText;
        public TextMeshProUGUI CurrentShieldText;
        public TextMeshProUGUI MaxShieldText;

        private Player _currentPlayer;
        private Ship _currentTarget;

        public void Awake() {
            _currentPlayer = GameEngine.Instance.CurrentPlayer;
        }

        private void Reset() {
            _currentTarget = null;
        }

        private void Hide() {
            transform.localPosition = new Vector3(0,-680,0);
        }

        private void Show() {
            transform.localPosition = new Vector3(0,-540,0);
        }

        private void Update() {
            var hostileTarget = _currentPlayer?.CurrentShip?.Sensors?.HostileTarget;
            if (hostileTarget == null) {
                if (_currentTarget == null) return;
                Reset();
                Hide();
                return;
            }

            if (_currentTarget != hostileTarget) {
                _currentTarget = hostileTarget;
                Show(); //todo: refactor this to not be in an update method.
            }
            CurrentHealthText.text = _currentTarget.Tactical.TacticalProperties.CurrentHullStrength.ToString();
            MaxHealthText.text = _currentTarget.Tactical.TacticalProperties.CurrentHullStrength.ToString();
            CurrentShieldText.text = _currentTarget.Tactical.TacticalProperties.CurrentShieldStrength.ToString();
            MaxShieldText.text = _currentTarget.Tactical.TacticalProperties.CurrentShieldStrength.ToString();
        }
    }
}