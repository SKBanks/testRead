using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface IShieldOutfit : IOutfit, ISerialize<ShieldOutfitData> {
        int ShieldStrength { get; }
    }
}