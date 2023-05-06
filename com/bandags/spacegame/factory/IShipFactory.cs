using com.bandags.spacegame.data.Serialization;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.factory {
    public interface IShipFactory {
        Ship CreateShip(ShipData shipData, string name, Transform parentTransform);
    }
}