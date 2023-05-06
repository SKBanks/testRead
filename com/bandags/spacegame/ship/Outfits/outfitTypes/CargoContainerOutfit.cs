using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public class CargoContainerOutfit : ICargoContainerOutfit {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
        public OutfitCategory OutfitCategory => OutfitCategory.Cargo;
        public OutfitType OutfitType => OutfitType.CargoContainer;
        public string CargoContents { get; }
        public int CargoCapacity { get; }

        private CargoContainerData _cargoOutfitData;
        
        public T Upcast<T>() {
            return (T)(object)this;
        }

        public CargoContainerData Serialize() {
            return _cargoOutfitData;
        }

        public void Deserialize(CargoContainerData data) {
            _cargoOutfitData = data;
        }

        
    }
}