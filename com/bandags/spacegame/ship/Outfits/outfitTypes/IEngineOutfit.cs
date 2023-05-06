using com.bandags.spacegame.data;

namespace com.bandags.spacegame.ship {
    public interface IEngineOutfit : IOutfit, ISerialize<EngineOutfitData> {
        int ThrustForce { get; }
        int SteeringForce { get; }
    }
}