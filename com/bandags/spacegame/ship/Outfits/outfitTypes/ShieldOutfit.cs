using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public class ShieldOutfit : IShieldOutfit {
        public string Name {
            get => _shieldOutfitData.Name;
            set => _shieldOutfitData.Name = value;
        }

        public int Cost {
            get => _shieldOutfitData.Cost;
            set => _shieldOutfitData.Cost = value;
        }

        public int Value {
            get => _shieldOutfitData.Value;
            set => _shieldOutfitData.Value = value;
        }
        public int OutfitCapacity {
            get => _shieldOutfitData.OutfitCapacity;
            set => _shieldOutfitData.OutfitCapacity = value;
        }
        public OutfitCategory OutfitCategory => _shieldOutfitData.OutfitCategory;
        public OutfitType OutfitType => _shieldOutfitData.OutfitType;
        public int ShieldStrength {
            get => _shieldOutfitData.ShieldStrength;
            internal set => _shieldOutfitData.ShieldStrength = value;
        }

        private ShieldOutfitData _shieldOutfitData { get; set; }

        public ShieldOutfit(ShieldOutfitData shieldOutfitData) {
            Deserialize(shieldOutfitData);
        }
        public T Upcast<T>() {
            return (T)(object)this;
        }
        public ShieldOutfitData Serialize() {
            return _shieldOutfitData;
        }
        public void Deserialize(ShieldOutfitData data) {
            _shieldOutfitData = data;
        }
    }
}