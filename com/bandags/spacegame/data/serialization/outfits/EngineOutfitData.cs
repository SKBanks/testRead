using System;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class EngineOutfitData : OutfitData {
        public int ThrustForce;
        public int SteeringForce;

        public static EngineOutfitData CreateFromScriptableObject(EngineOutfitScriptableObject engineOutfitScriptableObject) {
            return new EngineOutfitData {
                Name = engineOutfitScriptableObject.Name,
                Cost = engineOutfitScriptableObject.Cost,
                Value = engineOutfitScriptableObject.Value,
                OutfitCategory = engineOutfitScriptableObject.OutfitCategory,
                OutfitType = engineOutfitScriptableObject.OutfitType,
                OutfitCapacity = engineOutfitScriptableObject.OutfitCapacity,
                SteeringForce = engineOutfitScriptableObject.SteeringForce,
                ThrustForce = engineOutfitScriptableObject.ThrustForce
            };
        }
    }
}