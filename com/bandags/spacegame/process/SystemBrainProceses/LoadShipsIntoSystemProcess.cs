using System.Collections;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.system;
using UnityEngine;

namespace com.bandags.spacegame.process {
    public class LoadShipsIntoSystemProcess : Process {
        private readonly SystemLayer _systemLayer;
        public LoadShipsIntoSystemProcess(SystemLayer systemLayer) : base(ProcessType.LOAD_SHIPS_INTO_SYSTEM_PROCESS) {
            _systemLayer = systemLayer;
        }
        protected override IEnumerator Update() {
            var shipCollection = _systemLayer.SystemLayerData.ShipGroupCollection;
            var desiredShipInZone = shipCollection.ShipGroupOptions[Random.Range(0, shipCollection.ShipGroupOptions.Count - 1)];
            
            desiredShipInZone.ShipsInGroup.ForEach(shipScriptableObject => {
                var startingPosition = new Vector3(-90, 30,0);
                //var createdShip = GameEngine.Instance.Factory.ShipFactory.CreateShip(shipScriptableObject, startingPosition, _systemLayer.ParentGameObjects.Ships.transform);
                
                var createdShip = GameEngine.Instance.Factory.ShipFactory.CreateShip(ShipData.CreateFromShipScriptableObject(shipScriptableObject), "RandomShipName" + Random.value, _systemLayer.ParentGameObjects.Ships.transform);
                _systemLayer.AddShip(createdShip);
                createdShip.Land(_systemLayer.GetRandomPlanet());  //Todo: Find a better way to set the initial AI?  Maybe the brain just needs an init and it can find a priority?  that would require its own logic system in place.
            });
            
            yield return null;
        }
    }
}