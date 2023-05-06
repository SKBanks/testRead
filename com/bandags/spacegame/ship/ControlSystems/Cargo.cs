using System.Collections.Generic;

namespace com.bandags.spacegame.ship {
    public class Cargo : ICargo {
        public int CurrentCargoCapacity { get; }
        public int MaxCargoCapacity { get; }

        private Dictionary<OutfitCategory, List<IOutfit>> CargoItems;

        private readonly IOutfitManager _outfitManager;

        public Cargo(IOutfitManager outfitManager) {
            _outfitManager = outfitManager;
        }

        public void AddCargo(OutfitCategory outfitCategory, IOutfit outfit) {
            CargoItems[outfitCategory].Add(outfit);
        }

        public void RemoveCargo(OutfitCategory outfitCategory, IOutfit outfit) {
            CargoItems[outfitCategory].Remove(outfit);
        }

        public List<IOutfit> GetCargoByCategory(OutfitCategory outfitCategory) {
            return CargoItems[outfitCategory];
        }
        
        public void UpdateOutfits() {
            
        }
    }
}