using System;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class ShipData {
        public ShipType ShipType;
        public FactionType FactionType;
        public GameObject Prefab;
        public Vector3 Position;
        public OutfitManagerData OutfitManagerData;

        //Hardpoints
        public int LargeHardpoints;
        public int MediumHardpoints;
        public int SmallHardpoints;

        public static ShipData CreateFromShipScriptableObject(ShipScriptableObject shipScriptableObject) {
            var shipData = new ShipData {
                ShipType = shipScriptableObject.ShipType,
                FactionType = shipScriptableObject.FactionType,
                Prefab = shipScriptableObject.Prefab,
                OutfitManagerData = OutfitManagerData.CreateFromScriptableObject(shipScriptableObject.OutfitManager),
                LargeHardpoints = shipScriptableObject.LargeHardpoints,
                MediumHardpoints = shipScriptableObject.MediumHardpoints,
                SmallHardpoints = shipScriptableObject.SmallHardpoints
            };
            return shipData;
        }
    }
}