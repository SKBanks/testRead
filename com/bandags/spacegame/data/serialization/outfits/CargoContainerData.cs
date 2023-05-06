using System;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class CargoContainerData {
        public string CargoContents { get; set; }
        public int CargoCapacity { get; set; }

        public static CargoContainerData CreateCargoContainerDataFromScriptableObject(CargoContainerOutfitScriptableObject cargoContainerOutfitScriptableObject) {
            return new CargoContainerData {
                CargoContents = cargoContainerOutfitScriptableObject.CargoContents,
                CargoCapacity = cargoContainerOutfitScriptableObject.CargoCapacity
            };
        }
    }
}