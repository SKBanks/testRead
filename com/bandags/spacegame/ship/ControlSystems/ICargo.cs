namespace com.bandags.spacegame.ship {
    public interface ICargo : IControlSystem {
        int CurrentCargoCapacity { get; }
        int MaxCargoCapacity { get; }
    }
}