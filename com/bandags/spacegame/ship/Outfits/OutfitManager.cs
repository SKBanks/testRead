using System;
using System.Collections.Generic;
using System.Linq;
using com.bandags.spacegame.data;
using com.bandags.spacegame.data.Serialization;
using UnityEngine;

namespace com.bandags.spacegame.ship {
    [Serializable]
    public class OutfitManager : IOutfitManager {
        [field: SerializeReference] public List<IOutfit> _Outfits;
        public OutfitManager() {
            _Outfits = new List<IOutfit>();
        }

        public List<T> GetOutfits<T> () {
            return _Outfits.Where(outfit => outfit is T).Cast<T>().ToList();
        }

        public void AddOutfits(IOutfit outfit) {
            _Outfits.Add(outfit);
        }

        public OutfitManagerData Serialize() {
            var outfitManagerData = new OutfitManagerData {
                GeneralOutfits = new List<GeneralOutfitData>()
            };

            _Outfits.ForEach(outfit => {
                switch (outfit.OutfitType) {
                    case OutfitType.Engine:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = outfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(outfit.Upcast<EngineOutfit>().Serialize())
                        });
                        break;
                    case OutfitType.Hull:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = outfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(outfit.Upcast<HullOutfit>().Serialize())
                        });
                        break;
                    case OutfitType.Mass:
                        break;
                    case OutfitType.Sensor:
                        break;
                    case OutfitType.Shield:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = outfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(outfit.Upcast<ShieldOutfit>().Serialize())
                        });
                        break;
                    case OutfitType.LaserBlaster:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = outfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(outfit.Upcast<LaserBlasterWeaponOutfit>().Serialize())
                        });
                        break;
                    case OutfitType.Cargo:
                        outfitManagerData.GeneralOutfits.Add(new GeneralOutfitData {
                            OutfitType = outfit.OutfitType,
                            OutfitData = JsonUtility.ToJson(outfit.Upcast<CargoOutfit>().Serialize())
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            return outfitManagerData;
        }

        public void Deserialize(OutfitManagerData data, Ship owner) {
            _Outfits.Clear();
            data.GeneralOutfits.ForEach(generalOutfit => {
                switch (generalOutfit.OutfitType) {
                    case OutfitType.Engine:
                        _Outfits.Add(new EngineOutfit(JsonUtility.FromJson<EngineOutfitData>(generalOutfit.OutfitData)));
                        break;
                    case OutfitType.Hull:
                        _Outfits.Add(new HullOutfit(JsonUtility.FromJson<HullOutfitData>(generalOutfit.OutfitData)));
                        break;
                    case OutfitType.Mass:
                        break;
                    case OutfitType.Sensor:
                        break;
                    case OutfitType.Shield:
                        _Outfits.Add(new ShieldOutfit(JsonUtility.FromJson<ShieldOutfitData>(generalOutfit.OutfitData)));
                        break;
                    case OutfitType.LaserBlaster:
                        var outfit = new LaserBlasterWeaponOutfit(JsonUtility.FromJson<WeaponOutfitData>(generalOutfit.OutfitData), owner);
                        _Outfits.Add(outfit);
                        owner.Tactical.HardpointManager.AddWeaponToHardpoint(outfit);   //todo: this seems like something is wrong.  maybe this should happen in constructor?
                        break;
                    case OutfitType.Cargo:
                        _Outfits.Add(new CargoOutfit(JsonUtility.FromJson<CargoOutfitData>(generalOutfit.OutfitData)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        public void Deserialize(OutfitManagerData data) {
            throw new NotImplementedException("Use: Deserialize(SOutfitManager data, Ship owner)");
        }
    }
}