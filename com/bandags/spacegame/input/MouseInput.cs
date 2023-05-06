using com.bandags.spacegame.planet;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.system;

namespace com.bandags.spacegame.input{
    using UnityEngine;

    public class MouseInput {
        private const int ShipLayer = 8;
        private const int PlanetLayer = 9;
        private const int MapSystemLayer = 10;
        
        private readonly Camera _playerCamera;

        public bool Enabled { get; set; }

        public MouseInput(Camera playerCamera) {
            _playerCamera = playerCamera;
        }

        public void Update() {
            if (!Enabled) return;
            if (!Input.GetMouseButtonDown(0)) return;
            var mouse = Input.mousePosition;
            var castPoint = _playerCamera.ScreenPointToRay(mouse);

            //Dont check for clicks if the mouse is on a UI Element.  Let the element handle the click
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
                return;
            }
            
            var raycast = Physics.Raycast(castPoint, out var hit, Mathf.Infinity);
            if (raycast) {
                switch (hit.transform.gameObject.layer) {
                    case ShipLayer:
                        GameEngine.Instance.UIManager.OnSelectShip( GetComponentFromHit<Ship>(hit));
                        break;
                    case PlanetLayer:
                        GameEngine.Instance.UIManager.OnSelectPlanet(GetComponentFromHit<Planet>(hit));
                        break;
                }
            } else {
                GameEngine.Instance.UIManager.OnSelectNothing();
                MoveShipToPosition(new Vector3(mouse.x, mouse.y, -_playerCamera.transform.position.z));
            }
        }

        private static T GetComponentFromHit<T>(RaycastHit hit) {
            return hit.transform.gameObject.GetComponentInParent<T>();
        }

        private void MoveShipToPosition(Vector3 position) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.MoveToPosition(_playerCamera.ScreenToWorldPoint(position));
        }
        
        private void MoveShipAndStopAtPosition(Vector3 position) {
            GameEngine.Instance.CurrentPlayer.CurrentShip.MoveToPosition(_playerCamera.ScreenToWorldPoint(position));
        }
    }
}