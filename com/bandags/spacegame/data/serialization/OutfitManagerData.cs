using System;
using System.Collections.Generic;
using com.bandags.spacegame.ship;
using UnityEngine;

namespace com.bandags.spacegame.data.Serialization {
    [Serializable]
    public class OutfitManagerData {
        public List<GeneralOutfitData> GeneralOutfits;

        public static OutfitManagerData CreateFromScriptableObject(OutfitManagerScriptableObject outfitManagerScriptableObject) {
            var outfitManagerData = new OutfitManagerData {
                GeneralOutfits = new List<GeneralOutfitData>(outfitManagerScriptableObject.AllOutfits.Count)
            };
            outfitManagerScriptableObject.AllOutfits.ForEach(generalOutfit => {
                switch (generalOutfit.OutfitType) {
                    case OutfitType.Engine:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = generalOutfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(EngineOutfitData.CreateFromScriptableObject(generalOutfit as EngineOutfitScriptableObject))
                        });
                        break;
                    case OutfitType.Hull:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = generalOutfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(HullOutfitData.CreateFromScriptableObject(generalOutfit as HullOutfitScriptableObject))
                        });
                        break;
                    case OutfitType.Mass:
                        break;
                    case OutfitType.Sensor:
                        break;
                    case OutfitType.Shield:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = generalOutfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(ShieldOutfitData.CreateFromScriptableObject(generalOutfit as ShieldOutfitScriptableObject))
                        });
                        break;
                    case OutfitType.LaserBlaster:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = generalOutfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(WeaponOutfitData.CreateFromScriptableObject(generalOutfit as WeaponOutfitScriptableObject))
                        });
                        break;
                    case OutfitType.Cargo:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = generalOutfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(CargoOutfitData.CreateFromScriptableObject(generalOutfit as CargoOutfitScriptableObject))
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            return outfitManagerData;
        }
    }
}