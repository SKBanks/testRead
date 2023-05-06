using System;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class HullOutfitData : OutfitData {
        public int HullStrength;
        public int Mass;
        
        public static HullOutfitData CreateFromScriptableObject(HullOutfitScriptableObject scriptableObject) {
            return new HullOutfitData {
                Name = scriptableObject.Name,
                Cost = scriptableObject.Cost,
                Value = scriptableObject.Value,
                OutfitCategory = scriptableObject.OutfitCategory,
                OutfitType = scriptableObject.OutfitType,
                OutfitCapacity = scriptableObject.OutfitCapacity,
                Mass = scriptableObject.Mass,
                HullStrength = scriptableObject.HullStrength
            };
        }
    }
}