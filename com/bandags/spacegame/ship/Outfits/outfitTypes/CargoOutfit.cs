using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public class CargoOutfit : ICargoOutfit {
        public string Name {
            get => _cargoOutfitData.Name;
            set => _cargoOutfitData.Name = value;
        }
        public int Cost {
            get => _cargoOutfitData.Cost;
            set => _cargoOutfitData.Cost = value;
        }
        public int Value {
            get => _cargoOutfitData.Value;
            set => _cargoOutfitData.Value = value;
        }
        public int OutfitCapacity {
            get => _cargoOutfitData.OutfitCapacity;
            set => _cargoOutfitData.OutfitCapacity = value;
        }
        public int CargoCapacity {
            get => _cargoOutfitData.CargoCapacity;
            set => _cargoOutfitData.CargoCapacity = value;
        }
        public int HullStrength {
            get => _cargoOutfitData.HullStrength;
            set => _cargoOutfitData.HullStrength = value;
        }
        public int Mass {
            get => _cargoOutfitData.Mass;
            set => _cargoOutfitData.Mass = value;
        }
        public OutfitCategory OutfitCategory { get; }
        public OutfitType OutfitType { get; }

        private CargoOutfitData _cargoOutfitData;

        public CargoOutfit(CargoOutfitData cargoOutfitData) {
            Deserialize(cargoOutfitData);
        }
        public T Upcast<T>() {
            return (T)(object)this;
        }

        public CargoOutfitData Serialize() {
            return _cargoOutfitData;
        }

        public void Deserialize(CargoOutfitData data) {
            _cargoOutfitData = data;
        }
    }
}