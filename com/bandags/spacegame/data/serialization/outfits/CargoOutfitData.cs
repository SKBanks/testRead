using System;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class CargoOutfitData : OutfitData {
        public int CargoCapacity;
        public int HullStrength;
        public int Mass;

        public static CargoOutfitData CreateFromScriptableObject(CargoOutfitScriptableObject cargoOutfitScriptable) {
            return new CargoOutfitData {
                Name = cargoOutfitScriptable.Name,
                Cost = cargoOutfitScriptable.Cost,
                Value = cargoOutfitScriptable.Value,
                OutfitCategory = cargoOutfitScriptable.OutfitCategory,
                OutfitType = cargoOutfitScriptable.OutfitType,
                OutfitCapacity = cargoOutfitScriptable.OutfitCapacity,
                CargoCapacity = cargoOutfitScriptable.CargoCapacity,
                HullStrength = cargoOutfitScriptable.HullStrength,
                Mass = cargoOutfitScriptable.Mass
            };
        }
    }
}