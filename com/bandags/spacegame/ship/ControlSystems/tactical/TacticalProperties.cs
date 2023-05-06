using System.Linq;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    public class TacticalProperties : ITacticalProperties {
        public int MaxShieldStrength { get; private set; }
        public int CurrentShieldStrength { get; private set; }
        public int MaxHullStrength { get; private set; }
        public int CurrentHullStrength { get; private set; }

        public void UpdateOutfits(IOutfitManager outfitManager) {
            MaxShieldStrength = outfitManager.GetOutfits<ShieldOutfit>().Sum(shipOutfit => shipOutfit.ShieldStrength);
            CurrentShieldStrength = MaxShieldStrength;
            MaxHullStrength = outfitManager.GetOutfits<IHullOutfit>().Sum(shipOutfit =>  shipOutfit.HullStrength);
            CurrentHullStrength = MaxHullStrength;
        }
        
        public void UpdateCurrentHullStrength(int value) {
            CurrentHullStrength += value;
            Mathf.Clamp(CurrentHullStrength, 0, MaxHullStrength);
        }
        public void UpdateCurrentShieldStrength(int value) {
            CurrentShieldStrength += value;
            Mathf.Clamp(CurrentShieldStrength, 0, MaxShieldStrength);
        }
    }
}