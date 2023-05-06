using System;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class ShieldOutfitData : OutfitData {
        public int ShieldStrength;

        public static ShieldOutfitData CreateFromScriptableObject(ShieldOutfitScriptableObject scriptableObject) {
            return new ShieldOutfitData {
                Name = scriptableObject.Name,
                Cost = scriptableObject.Cost,
                Value = scriptableObject.Value,
                OutfitCategory = scriptableObject.OutfitCategory,
                OutfitType = scriptableObject.OutfitType,
                OutfitCapacity = scriptableObject.OutfitCapacity,
                ShieldStrength = scriptableObject.ShieldStrength
            };
        }
    }
}