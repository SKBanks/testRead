using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.ship;
using com.bandags.spacegame.utilities;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public class ShipFactory : IShipFactory {
        /// <summary>
        /// Used to create new ships from ShipData templates.  Source can be ScriptableObjects or SerializedData
        /// </summary>
        /// <returns>Ship</returns>
        public Ship CreateShip(ShipData shipData, string name, Transform parentTransform) {
            var ship = Instantiation.InstantiatePrefab<Ship>(shipData.Prefab);
            ship.Deserialize(shipData);
            ship.transform.SetParent(parentTransform, false);
            ship.name = name;
            return ship;
        }
    }
}