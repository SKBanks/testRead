using UnityEngine;
using UnityEngine.UI;

namespace com.bandags.spacegame.ship {
    public class ShipSelectionMenu : MonoBehaviour {
        public Ship Ship;

        public GameObject RootUIObject;
        public GameObject CanvasGO;

        public Button AttackButton;
        public Button BoardButton;
        public Button HailButton;

        private Camera mainCamera;

        private void Update() {
            UpdateMenuPositionToShipPosition();
        }

        public void ShowMenu(Ship playerShip) {
            AttackButton.interactable = playerShip.CanAttackShip(Ship);
            BoardButton.interactable = playerShip.CanBoardShip(Ship);
            HailButton.interactable = true;
            mainCamera = Camera.main;
            UpdateMenuPositionToShipPosition();
            CanvasGO.SetActive(true);
        }

        public void HideMenu() {
            CanvasGO.SetActive(false);
        }

        public void AttackShip(Ship targetShip) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.Attack(targetShip);
        }

        public void BoardShip(Ship targetShip) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.BoardShip(targetShip);
        }

        public void HailShip(Ship targetShip) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.HailShip(targetShip);
        }

        private void UpdateMenuPositionToShipPosition() {
            RootUIObject.transform.position = mainCamera.WorldToScreenPoint(Ship.transform.position);
        }
    }
}