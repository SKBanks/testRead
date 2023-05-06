using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface IHullOutfit : IOutfit, ISerialize<HullOutfitData> {
        int HullStrength { get; }
        int Mass { get; }
    }
}