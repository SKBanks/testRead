using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public class HullOutfit : IHullOutfit {
        public string Name {
            get => _hullOutfitData.Name;
            set => _hullOutfitData.Name = value;
        }
        public int Cost {
            get => _hullOutfitData.Cost;
            set => _hullOutfitData.Cost = value;
        }
        public int Value {
            get => _hullOutfitData.Value;
            set => _hullOutfitData.Value = value;
        }
        public int OutfitCapacity {
            get => _hullOutfitData.OutfitCapacity;
            set => _hullOutfitData.OutfitCapacity = value;
        }
        public OutfitCategory OutfitCategory => _hullOutfitData.OutfitCategory;
        public OutfitType OutfitType => _hullOutfitData.OutfitType;
        public int HullStrength {
            get => _hullOutfitData.HullStrength;
            internal set => _hullOutfitData.HullStrength = value;
        }

        public int Mass {
            get => _hullOutfitData.Mass;
            internal set => _hullOutfitData.Mass = value;
        }

        private HullOutfitData _hullOutfitData { get; set; }
        public HullOutfit(HullOutfitData hullOutfitData) {
            Deserialize(hullOutfitData);
        }
        public T Upcast<T>() {
            return (T)(object)this;
        }
        public HullOutfitData Serialize() {
            return _hullOutfitData;
        }
        public void Deserialize(HullOutfitData data) {
            _hullOutfitData = data;
        }
    }
}