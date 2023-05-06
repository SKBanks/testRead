using System;
using com.bandags.spacegame.ship;

namespace com.bandags.spacegame.data {
    [Serializable]
    public class OutfitData {
        public string Name;
        public int Cost;
        public int Value;
        public int OutfitCapacity;
        public OutfitCategory OutfitCategory;
        public OutfitType OutfitType;
    }
}