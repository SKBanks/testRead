using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface ICargoOutfit : IOutfit, ISerialize<CargoOutfitData> {
        int CargoCapacity { get; }
        int HullStrength { get; }
        int Mass { get; }
    }
}