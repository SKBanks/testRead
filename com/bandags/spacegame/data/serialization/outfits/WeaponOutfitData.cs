using System;
using com.bandags.spacegame.ship;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class WeaponOutfitData : OutfitData {
        public int Damage;
        public int Range;
        public float FireRateInSeconds;
        public HardpointSize RequiredHardpointSize;
        public WeaponStyle WeaponStyle;
        
        public static WeaponOutfitData CreateFromScriptableObject(WeaponOutfitScriptableObject scriptableObject) {
            return new WeaponOutfitData {
                Name = scriptableObject.Name,
                Cost = scriptableObject.Cost,
                Value = scriptableObject.Value,
                OutfitCategory = scriptableObject.OutfitCategory,
                OutfitType = scriptableObject.OutfitType,
                OutfitCapacity = scriptableObject.OutfitCapacity,
                Damage = scriptableObject.Damage,
                Range = scriptableObject.Range,
                FireRateInSeconds = scriptableObject.FireRateInSeconds,
                RequiredHardpointSize = scriptableObject.RequiredHardpointSize,
                WeaponStyle = scriptableObject.WeaponStyle
            };
        }
    }
}